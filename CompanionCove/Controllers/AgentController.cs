using CompanionCove.Attributes;
using CompanionCove.Core.Contracts;
using CompanionCove.Core.Models.Agent;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CompanionCove.Core.Constants.MessageConstants;
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
		[NotAgent]
		public IActionResult Become()
		{
			
		var model = new BecomeAgentFormModel();

			return View(model);
		}
		[HttpPost]
		[NotAgent]
		public async Task<IActionResult> Become(BecomeAgentFormModel model)
		{
			if(await agentService.UserWithPhoneNumberExistsAsync(User.Id()))
			{
				ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
			}

			if(await agentService.UserIsAGuardianAsync(User.Id()))
			{
				ModelState.AddModelError("Error", IsGuardian);
			}
			if (ModelState.IsValid == false)
			{
				return View(model);
			}

			await agentService.CreateAsync(User.Id(), model.PhoneNumber);
			return RedirectToAction(nameof(AnimalController.All), "Animal");
		}
	}
}
