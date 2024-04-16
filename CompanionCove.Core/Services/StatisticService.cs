using CompanionCove.Core.Contracts;
using CompanionCove.Core.Models.Statistics;
using CompanionCove.Infrastructure.Data.Common;
using CompanionCove.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionCove.Core.Services
{
	public class StatisticService : IStatisticService
	{
		private readonly IRepository repository;
        public StatisticService(IRepository _repository)
        {
				repository = _repository;
        }
        public async Task<StatisticServiceModel> TotalAsync()
		{
			int totalAnimals = await repository.AllReadOnly<Animal>().CountAsync();

			int totalAdoptions = await repository.AllReadOnly<Animal>().Where(x=>x.GuardianId != null).CountAsync();

			return new StatisticServiceModel() 
			{ 
				TotalAnimals = totalAnimals, 
				TotalAdoptions = totalAdoptions 
			};
		}
	}
}
