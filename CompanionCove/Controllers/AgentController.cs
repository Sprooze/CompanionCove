﻿using CompanionCove.Core.Contracts;
using CompanionCove.Core.Models.Agent;
using CompanionCove.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
