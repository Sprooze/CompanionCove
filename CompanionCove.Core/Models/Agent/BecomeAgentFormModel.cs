using System.ComponentModel.DataAnnotations;
using static CompanionCove.Core.Constants.MessageConstants;
using static CompanionCove.Infrastructure.Constants.DataConstants;
namespace CompanionCove.Core.Models.Agent
{
	public class BecomeAgentFormModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(MaxAgentPhoneLength, MinimumLength = MinAgentPhoneLength,ErrorMessage = LengthMessage)]
		[Display(Name = "Phone number")]
		[Phone]
		public string PhoneNumber { get; set; } = null!;
	}
}
