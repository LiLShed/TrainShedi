using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClasses
{
    internal class Dogs : AnimalAbstractClass
    {
        public Dogs(string name, int age, string sex, string breed = "No Breed") : base(name, age, sex, breed)
        {

        }
        public Dogs() { }
        public override string ToString()
        {
            return $"Dog {Name} is {Age} year/`s old, it is {Sex}, {BreedName}";
        }

    }
}
