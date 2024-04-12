using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CompanionCove.Infrastructure.Constants.DataConstants;

namespace CompanionCove.Infrastructure.Data.Models
{
    [Comment("Adoption Agent")]
    public class Agent
    {
        [Key]
        [Comment("Agent Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxAgentPhoneLength)]
        [Comment("Agent's phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public List<Animal> Animals { get; set; } = new List<Animal>(); 


    }
}
