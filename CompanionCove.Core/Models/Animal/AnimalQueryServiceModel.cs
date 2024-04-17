using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionCove.Core.Models.Animal
{
    public class AnimalQueryServiceModel
    {
        public int TotalAnimalsCount { get; set; }

        public IEnumerable<AnimalServiceModel> Animals { get; set; } = new List<AnimalServiceModel>();
    }
}
