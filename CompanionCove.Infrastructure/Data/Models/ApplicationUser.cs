using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static CompanionCove.Infrastructure.Constants.DataConstants;

namespace CompanionCove.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(MaxUserFirstNameLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(MaxUserLastNameLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;
    }
}
