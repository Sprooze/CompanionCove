using CompanionCove.Attributes;
using CompanionCove.Core.Contracts;
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
        public AnimalController(IAnimalService _animalService, IAgentService _agentService)
        {
            animalService = _animalService;
            agentService = _agentService;

        }
        [AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All()
        {
            var model = new AllAnimalsQueryModel();

            return View(model);
        }
		[HttpGet]
		public async Task<IActionResult> Mine()
        {
            var model = new AllAnimalsQueryModel();
            return View(model);
        }
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var model = new AnimalDetailsViewModel();
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
                ModelState.AddModelError(nameof(model.TypeId), "");
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
            var model = new AnimalFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,AnimalFormModel model)
        {
			return RedirectToAction(nameof(Details), new { id = 1 });
		}
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var model = new AnimalDetailsViewModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(AnimalDetailsViewModel model)
		{
			return RedirectToAction(nameof(All));
		}

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
			return RedirectToAction(nameof(Mine));
		}
		[HttpPost]
		public async Task<IActionResult> Leave(int id)
		{
			return RedirectToAction(nameof(Mine));
		}
	}
}
