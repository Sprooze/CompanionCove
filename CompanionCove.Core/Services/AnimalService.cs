using CompanionCove.Core.Contracts;
using CompanionCove.Core.Enumerations;
using CompanionCove.Core.Exceptions;
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

        public async Task<IEnumerable<AnimalServiceModel>> AllAnimalsByAgentIdAsync(int agentId)
        {
            return await repository.AllReadOnly<Animal>().Where(x => x.AgentId == agentId).ProjectAnimal().ToListAsync();
        }

        public async Task<IEnumerable<AnimalServiceModel>> AllAnimalsByUserId(string userId)
        {
            return await repository.AllReadOnly<Animal>().Where(x => x.GuardianId == userId).ProjectAnimal().ToListAsync();
        }

        public async Task<AnimalQueryServiceModel> AllAsync(string? type = null, string? searchTerm = null,
            AnimalSorting sorting = AnimalSorting.Newest, int currentPage = 1, int animalsPerPage = 1)
        {
            var animalsToShow = repository.AllReadOnly<Animal>();
            
            if(type != null)
            {
                animalsToShow = animalsToShow.Where(x => x.Type.Name == type);
            }

            if(searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                animalsToShow = animalsToShow.Where(x => (x.Name.ToLower().Contains(normalizedSearchTerm)
                || x.Address.ToLower().Contains(normalizedSearchTerm)
                || x.Description.ToLower().Contains(normalizedSearchTerm))); 
            }

            animalsToShow = sorting switch
            {
               AnimalSorting.NotAdoptedFirst => animalsToShow.OrderBy(x=> x.GuardianId!= null).ThenByDescending(x=>x.Id),
                _ =>animalsToShow.OrderByDescending(x=>x.Id)
            };

            var animals = await animalsToShow.Skip((currentPage-1) * animalsPerPage).Take(animalsPerPage).ProjectAnimal().ToListAsync();

            int totalAnimals = await animalsToShow.CountAsync();

            return new AnimalQueryServiceModel()
            {
                Animals = animals,
                TotalAnimalsCount = totalAnimals
            };
        }

        public async Task<IEnumerable<AnimalTypeServiceModel>> AllTypesAsync()
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Type>().Select(x => new AnimalTypeServiceModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync(); 
        }

        public async Task<IEnumerable<string>> AllTypesNamesAsync()
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Type>().Select(x=>x.Name).Distinct().ToListAsync();
        }

		public async Task<AnimalDetailsServiceModel> AnimalDetailsByIdAsync(int id)
		{
            return await repository.AllReadOnly<Animal>().Where(x => x.Id == id).Select(x => new AnimalDetailsServiceModel()
            {
                Id= x.Id,
                Address = x.Address,
                Agent = new Models.Agent.AgentServiceModel()
                {
                    Email = x.Agent.User.Email,
                    PhoneNumber = x.Agent.PhoneNumber
                },
                Type = x.Type.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                IsAdopted = x.GuardianId !=null,
                Name = x.Name
            }).FirstAsync(); 
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

		public async Task DeleteAsync(int animalId)
		{
           await repository.DeleteAsync<Animal>(animalId);
            await repository.SaveChangesAsync();
		}

		public async Task EditAsync(int animalId, AnimalFormModel model)
        {
            var animal = await repository.GetByIdAsync<Animal>(animalId);

            if(animal != null)
            {
                animal.Address = model.Address;
                animal.TypeId = model.TypeId;
                animal.Description = model.Description;
                animal.ImageUrl = model.ImageUrl; 
                animal.Name = model.Name;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
		{
		   return await repository.AllReadOnly<Animal>().AnyAsync(x=>x.Id == id);
		}

        public async Task<AnimalFormModel?> GetAnimalFormModelByIdAsync(int id)
        {
            var animal = await repository.AllReadOnly<Animal>().Where(x => x.Id == id).Select(x => new AnimalFormModel()
            {
                Address = x.Address,
                TypeId = x.TypeId,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Name = x.Name

            }).FirstOrDefaultAsync();

            if(animal != null)
            {
                animal.Types = await AllTypesAsync();
            }


            return animal;
        }

        public async Task<bool> HasAgentWithIdAsync(int animalId, string userId)
        {
            return await repository.AllReadOnly<Animal>().AnyAsync(x => x.Id == animalId && x.Agent.UserId == userId);
        }

        public async Task<bool> IsAdoptedAsync(int animalId)
        {
            bool result = false;

            var animal = await repository.GetByIdAsync<Animal>(animalId);

            if(animal != null)
            {
                result =animal.GuardianId != null;
            }
            return result;

        }

        public async Task<bool> IsAdoptedByUserWithIdAsync(int animalId, string userId)
        {
            bool result = false;

            var animal = await repository.GetByIdAsync<Animal>(animalId);
                
            if (animal != null)
            {
                result = animal.GuardianId == userId;
            }
            return result;
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

        public async Task AdoptAsync(int id, string userId)
        {
            var animal = await repository.GetByIdAsync<Animal>(id);

            if (animal != null)
            {
                 animal.GuardianId = userId;
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> TypeExistsAsync(int typeId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Type>().AnyAsync(x => x.Id == typeId);
        }

        public async Task LeaveAsync(int animalId, string userId)
        {
            var animal = await repository.GetByIdAsync<Animal>(animalId);

            if (animal != null)
            {
                if(animal.GuardianId != userId)
                {
                    throw new UnauthorizedActionException("The user is not the guardian");
                }
                animal.GuardianId = null;
                await repository.SaveChangesAsync();
            }
        }
    }
}
