using CompanionCove.Core.Contracts;
using System.Text.RegularExpressions;

namespace CompanionCove.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IAnimalModel animal)
        {
            string info= animal.Name.Replace(" ", "-") + GetAddress(animal.Address);

           info=  Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        private static string GetAddress(string address)
        {
           address = string.Join("-", address.Split(" ").Take(3));

            return address;
        }
    }
}
