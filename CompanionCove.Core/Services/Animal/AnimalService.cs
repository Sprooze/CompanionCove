using CompanionCove.Core.Contracts.Animal;
using CompanionCove.Core.Models.Home;
using CompanionCove.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CompanionCove.Core.Services.Animal
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository repository;

        public AnimalService(IRepository _repository)
        {
          repository = _repository;
        }
        public async Task<IEnumerable<AnimalIndexServiceModel>> LastThreeAnimals()
        {
            return await repository
                 .AllReadOnly<Infrastructure.Data.Models.Animal>()
                 .OrderByDescending(x => x.Id)
                 .Take(3)
                 .Select(x => new AnimalIndexServiceModel()
                 {
                     Id = x.Id,
                     ImageUrl = x.ImageUrl,
                     Name = x.Name
                 }).ToListAsync();
        }
    }
}
