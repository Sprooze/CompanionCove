using CompanionCove.Core.Models.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionCove.Core.Models.Animal
{
	public class AnimalDetailsServiceModel :AnimalServiceModel
	{
		public string Description { get; set; } = null!;

		public string Type { get; set; } = null!;

		public AgentServiceModel Agent { get; set; } = null!;
	}
}
