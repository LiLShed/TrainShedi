using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClasses
{
    internal abstract class Breeds
    {
        public string BreedType { get; set; }

        public Breeds(string BreedType)
        {
            this.BreedType = BreedType;
        }
    }
}
