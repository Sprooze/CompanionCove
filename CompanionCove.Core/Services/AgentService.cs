using CompanionCove.Core.Contracts;
using CompanionCove.Infrastructure.Data.Common;
using CompanionCove.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionCove.Core.Services
{
	public class AgentService : IAgentService
	{
		private readonly IRepository repository;
        public AgentService(IRepository _repository)
        {
			repository = _repository;		
        }

		public Task CreateAsync(string userId, string phoneNumber)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> ExistsByIdAsync(string userid)
		{
			return await repository.AllReadOnly<Agent>().AnyAsync(x=>x.UserId == userid);
		}

		public Task<bool> UserIsAGuardianAsync()
		{
			throw new NotImplementedException();
		}

		public Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
		{
			throw new NotImplementedException();
		}
	}
}
