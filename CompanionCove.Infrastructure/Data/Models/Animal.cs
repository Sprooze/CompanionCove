using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CompanionCove.Infrastructure.Constants.DataConstants;

namespace CompanionCove.Infrastructure.Data.Models
{
    [Comment("Animal for adoption")]
    public class Animal
    {
        [Key]
        [Comment("Animal Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        [Comment("Animal name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxAddressLength)]
        [Comment("Animal address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxDescriptionLength)]
        [Comment("Animal description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Animal image url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Type identifier")]
        public int TypeId { get; set; }

        [Required]
        [Comment("Agent identifier")]
        public int AgentId { get; set; }

        [Comment("User id of the foster parent")]
        public string? GuardianId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; } = null!;
        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;
    }
}
