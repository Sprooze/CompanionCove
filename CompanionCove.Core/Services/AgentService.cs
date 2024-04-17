using CompanionCove.Core.Contracts;
using CompanionCove.Infrastructure.Data.Common;
using CompanionCove.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanionCove.Core.Services
{
	public class AgentService : IAgentService
	{
		private readonly IRepository repository;
        public AgentService(IRepository _repository)
        {
			repository = _repository;		
        }

		public async Task CreateAsync(string userId, string phoneNumber)
		{
			await repository.AddAsync(new Agent()
			{
				UserId = userId,
				PhoneNumber = phoneNumber,
			});

			await repository.SaveChangesAsync();
		}

		public async Task<bool> ExistsByIdAsync(string userid)
		{
			return await repository.AllReadOnly<Agent>().AnyAsync(x=>x.UserId == userid);
		}

        public async Task<int?> GetAgentIdAsync(string userId)
        {
           return (await repository.AllReadOnly<Agent>()
				.FirstOrDefaultAsync(x=>x.UserId == userId))?.Id;
        }

        public async Task<bool> UserIsAGuardianAsync(string useriId)
		{
			return await repository.AllReadOnly<Animal>().AnyAsync(x => x.GuardianId == useriId);	
		}

		public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
		{
			return await repository.AllReadOnly<Agent>().AnyAsync(x=>x.PhoneNumber == phoneNumber);
		}
	}
}
