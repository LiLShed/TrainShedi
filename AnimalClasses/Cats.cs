using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClasses
{
    internal class Cats : AnimalAbstractClass
    {
        public override void ReturnData()
        {
            Console.WriteLine($"Cat {Name} is {Age} year/`s old, it is {Sex}, {BreedName}");
        }
    }
}
