using CompanionCove.Core.Models.Animal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanionCove.Controllers
{
    [Authorize]
    public class AnimalController : Controller
    {
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
		public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(AnimalFormModel model)
        {
            return RedirectToAction(nameof(Details), new {id = 1});
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
