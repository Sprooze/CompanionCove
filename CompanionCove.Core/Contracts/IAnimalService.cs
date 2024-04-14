using CompanionCove.Core.Models.Home;

namespace CompanionCove.Core.Contracts
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalIndexServiceModel>> LastThreeAnimalsAsync();
    }
}
