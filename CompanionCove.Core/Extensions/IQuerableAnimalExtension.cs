using CompanionCove.Core.Models.Animal;
using CompanionCove.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableAnimalExtension
    {
        public static IQueryable<AnimalServiceModel> ProjectAnimal(this IQueryable<Animal> animals)
        {
            return animals.Select(x => new AnimalServiceModel()
            {
                Id = x.Id,
                Address = x.Address,
                ImageUrl = x.ImageUrl,
                IsAdopted = x.GuardianId != null,
                Name = x.Name
            });
        }
    }
}
