using CompanionCove.Core.Contracts;
using CompanionCove.Core.Models.Agent;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompanionCove.Controllers
{
	public class AgentController : BaseController
	{
		private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
				agentService = _agentService;
        }
        [HttpGet]
		public async Task<IActionResult> Become()
		{
			if (await agentService.ExistsByIdAsync(User.Id()))
			{
				return BadRequest();
			}
			
		var model = new BecomeAgentFormModel();

			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Become(BecomeAgentFormModel model)
		{
			return RedirectToAction(nameof(AnimalController.All), "Animal");
		}
	}
}
