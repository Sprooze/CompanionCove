using CompanionCove.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static CompanionCove.Core.Constants.MessageConstants;
using static CompanionCove.Infrastructure.Constants.DataConstants;
namespace CompanionCove.Core.Models.Animal
{
    public class AnimalServiceModel : IAnimalModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxAddressLength, MinimumLength = MinAddressLength, ErrorMessage = LengthMessage)]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
        [Display(Name = "Is Adopted")]
        public bool IsAdopted { get; set; }

    }
}