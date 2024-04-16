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
            var model = await animalService.LastThreeAnimalsAsync();

            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 400)
            {
                return View("Error400");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
