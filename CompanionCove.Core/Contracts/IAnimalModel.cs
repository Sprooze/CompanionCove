using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionCove.Core.Contracts
{
    public interface IAnimalModel
    {
        public string  Name { get; set; }

        public string Address { get; set; }
    }
}
