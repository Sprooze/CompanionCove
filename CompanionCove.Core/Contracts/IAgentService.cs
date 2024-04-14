using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionCove.Core.Contracts
{
	public interface IAgentService
	{
		Task<bool> ExistsByIdAsync(string userid);
		Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);

		Task<bool> UserIsAGuardianAsync();

		Task CreateAsync(string userId, string phoneNumber);
	}
}
