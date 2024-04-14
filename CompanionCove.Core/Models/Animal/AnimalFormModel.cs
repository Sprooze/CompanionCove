using System.ComponentModel.DataAnnotations;
using static CompanionCove.Core.Constants.MessageConstants;
using static CompanionCove.Infrastructure.Constants.DataConstants;
namespace CompanionCove.Core.Models.Animal
{
    public class AnimalFormModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = LengthMessage)]
		public string Name { get; set; } = null!;
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(MaxAddressLength, MinimumLength = MinAddressLength, ErrorMessage = LengthMessage)]
		public string Address { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name="Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name ="Type")]
        public int TypeId {  get; set; }

        public IEnumerable<AnimalTypeServiceModel> Types { get; set; } = new List<AnimalTypeServiceModel>();


    }
}
