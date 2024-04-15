using CompanionCove.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace CompanionCove.Core.Models.Animal
{
    public class AllAnimalsQueryModel
    {
        public  int AnimalsPerPage { get; }  = 3;

        public string Type { get; init; } = null!;

        [Display(Name = "Search by text")]

        public string SearchTerm { get; init; } = null!;

        public AnimalSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalAnimalsCount { get; set; }

        public IEnumerable<string> Types { get; set; } = null!;

        public IEnumerable<AnimalServiceModel> Animals { get; set; } = new List<AnimalServiceModel>();


    }
}
