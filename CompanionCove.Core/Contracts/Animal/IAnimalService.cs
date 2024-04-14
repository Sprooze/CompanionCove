using CompanionCove.Core.Models.Home;

namespace CompanionCove.Core.Contracts.Animal
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalIndexServiceModel>> LastThreeAnimals();
    }
}
