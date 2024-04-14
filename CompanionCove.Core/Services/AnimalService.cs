using CompanionCove.Core.Contracts;
using CompanionCove.Core.Models.Animal;
using CompanionCove.Core.Models.Home;
using CompanionCove.Infrastructure.Data.Common;
using CompanionCove.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanionCove.Core.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository repository;

        public AnimalService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<AnimalTypeServiceModel>> AllTypesAsync()
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Type>().Select(x => new AnimalTypeServiceModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync(); 
        }

        public async Task<int> CreateAsync(AnimalFormModel model, int agentId)
        {
            Animal animal = new Animal()
            {
                Description = model.Description,
                Address = model.Address,
                AgentId = agentId,
                TypeId = model.TypeId,
                ImageUrl = model.ImageUrl,
                Name = model.Name
                
            };
            await repository.AddAsync(animal);
            await repository.SaveChangesAsync();
            return animal.Id;
        }

        public async Task<IEnumerable<AnimalIndexServiceModel>> LastThreeAnimalsAsync()
        {
            return await repository
                 .AllReadOnly<Animal>()
                 .OrderByDescending(x => x.Id)
                 .Take(3)
                 .Select(x => new AnimalIndexServiceModel()
                 {
                     Id = x.Id,
                     ImageUrl = x.ImageUrl,
                     Name = x.Name
                 }).ToListAsync();
        }

        public async Task<bool> TypeExistsAsync(int typeId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Type>().AnyAsync(x => x.Id == typeId);
        }
    }
}
