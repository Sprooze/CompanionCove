using CompanionCove.Attributes;
using CompanionCove.Core.Contracts;
using CompanionCove.Core.Exceptions;
using CompanionCove.Core.Models.Animal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompanionCove.Controllers
{
    
    public class AnimalController : BaseController
    {
        private readonly IAnimalService animalService;
        private readonly IAgentService agentService;
        private readonly ILogger logger;
        public AnimalController(IAnimalService _animalService, IAgentService _agentService, ILogger<AnimalController> _logger)
        {
            animalService = _animalService;
            agentService = _agentService;
            logger = _logger;
        }
        [AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All([FromQuery]AllAnimalsQueryModel query)
        {
            var model = await animalService.AllAsync(
                query.Type,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.AnimalsPerPage);

            query.TotalAnimalsCount = model.TotalAnimalsCount;
            query.Animals = model.Animals;
            query.Types = await animalService.AllTypesNamesAsync();
            return View(query);
        }
		[HttpGet]
		public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<AnimalServiceModel> model;
            if(await agentService.ExistsByIdAsync(userId))
            {
                var agentId = await agentService.GetAgentIdAsync(userId) ?? 0;
                model = await animalService.AllAnimalsByAgentIdAsync(agentId);
            }
            else
            {
                model = await animalService.AllAnimalsByUserId(userId);
            }
            return View(model);
        }
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
            if(await animalService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
			var model = await animalService.AnimalDetailsByIdAsync(id);
			return View(model);
		}
		[HttpGet]
        [MustBeAgent]
		public async Task<IActionResult> Add()
        {
         
            var model = new AnimalFormModel()
            {
                Types = await animalService.AllTypesAsync()
            };

            return View(model);
        }
        
        [HttpPost]
        [MustBeAgent]
        public async Task<IActionResult> Add(AnimalFormModel model)
        {
            if(await animalService.TypeExistsAsync(model.TypeId) == false)
            {
                ModelState.AddModelError(nameof(model.TypeId), "Type does not exist!");
            }

            if(ModelState.IsValid == false)
            {
                model.Types = await animalService.AllTypesAsync(); 
                return View(model);
            }

            int? agentId = await agentService.GetAgentIdAsync(User.Id());

            int newAnimalId = await animalService.CreateAsync(model, agentId ?? 0);
           
            return RedirectToAction(nameof(Details), new {id = newAnimalId});
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
           if(await animalService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

           if(await animalService.HasAgentWithIdAsync(id,User.Id()) == false)
            {
                return Unauthorized();
            }
            var model = await animalService.GetAnimalFormModelByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,AnimalFormModel model)
        {
            if (await animalService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await animalService.HasAgentWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await animalService.TypeExistsAsync(model.TypeId) == false)
            {
                ModelState.AddModelError(nameof(model.TypeId), "Type does not exist!");
            }

            if (ModelState.IsValid == false)
            {
                model.Types = await animalService.AllTypesAsync();

                return View(model);
            }

            await animalService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id});
		}
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			
            if(await animalService.ExistsAsync(id) ==false)
            {
                return BadRequest();
            }

            if(await animalService.HasAgentWithIdAsync(id,User.Id()) == false)
            {
                return Unauthorized();
            }
			
            var animal = await animalService.AnimalDetailsByIdAsync(id);
            
            var model = new AnimalDetailsViewModel()
            { 
                Id = id,
                Address = animal.Address,
                ImageUrl = animal.ImageUrl,
                Name = animal.Name
            };

           
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(AnimalDetailsViewModel model)
		{
			if (await animalService.ExistsAsync(model.Id) == false)
			{
				return BadRequest();
			}

			if (await animalService.HasAgentWithIdAsync(model.Id, User.Id()) == false)
			{
				return Unauthorized();
			}
            await animalService.DeleteAsync(model.Id);

			return RedirectToAction(nameof(All));
		}

        [HttpPost]
        public async Task<IActionResult> Adopt(int id)
        {
            if (await animalService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            if(await agentService.ExistsByIdAsync(User.Id()))
            {
                return Unauthorized();
            }
            if(await animalService.IsAdoptedAsync(id))
            {
                return BadRequest();
            }

            await animalService.AdoptAsync(id, User.Id());
            return RedirectToAction(nameof(All));
		}
		[HttpPost]
		public async Task<IActionResult> Leave(int id, string userId)
		{
            if (await animalService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            if(await animalService.IsAdoptedByUserWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }
            try
            {
                await animalService.LeaveAsync(id, User.Id());
            }
            catch (UnauthorizedActionException uae)
            {
                logger.LogError(uae, "AnimalController/Leave");
                return Unauthorized();
            }
            
            return RedirectToAction(nameof(All));
		}
	}
}
