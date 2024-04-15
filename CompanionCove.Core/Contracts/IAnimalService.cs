using CompanionCove.Core.Enumerations;
using CompanionCove.Core.Models.Animal;
using CompanionCove.Core.Models.Home;

namespace CompanionCove.Core.Contracts
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalIndexServiceModel>> LastThreeAnimalsAsync();

        Task<IEnumerable<AnimalTypeServiceModel>> AllTypesAsync();

        Task<bool> TypeExistsAsync(int typeId);

        Task<int> CreateAsync(AnimalFormModel model, int agentId);

        Task<AnimalQueryServiceModel> AllAsync(string? type = null, string? searchTerm= null,
            AnimalSorting sorting = AnimalSorting.Newest, int currentPage =1, int animalsPerPage = 1);

        Task<IEnumerable<string>> AllTypesNamesAsync();

        Task<IEnumerable<AnimalServiceModel>> AllAnimalsByAgentIdAsync(int agentId);

        Task<IEnumerable<AnimalServiceModel>> AllAnimalsByUserId(string userId);

        Task<bool> ExistsAsync(int id);

        Task<AnimalDetailsServiceModel> AnimalDetailsByIdAsync(int id);

        Task EditAsync(int animalId, AnimalFormModel model);

        Task<bool> HasAgentWithIdAsync(int animalId, string userId);

        Task<AnimalFormModel?> GetAnimalFormModelByIdAsync(int id);
    }
}
