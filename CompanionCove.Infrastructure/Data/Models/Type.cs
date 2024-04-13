using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CompanionCove.Infrastructure.Constants.DataConstants;

namespace CompanionCove.Infrastructure.Data.Models
{
    [Comment("Animal type")]
    public class Type
    {
        [Key]
        [Comment("Type identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        [Comment("Type name")]
        public string Name { get; set; } = string.Empty;

        public List<Animal> Animals { get; set; } = new List<Animal>();


    }
}
