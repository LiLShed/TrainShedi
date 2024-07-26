using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClasses
{
    internal class Cats : AnimalAbstractClass
    {
        public Cats(string name, int age, string sex, string breed = "No Breed") : base(name, age, sex, breed)
        {
        }
        public Cats() { }

        public override string ToString()
        {
            return $"Cat {Name} is {Age} year/`s old, it is {Sex}, {BreedName}";
        }
    }
}
