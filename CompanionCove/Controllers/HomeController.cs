using CompanionCove.Core.Contracts;
using CompanionCove.Core.Models.Home;
using CompanionCove.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanionCove.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnimalService animalService;
        public HomeController(
            ILogger<HomeController> logger,
            IAnimalService _animalService)
        {
            _logger = logger;
            animalService = _animalService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await animalService.LastThreeAnimals();

            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
