using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClasses
{
    internal class Dogs : AnimalAbstractClass
    {
        public override void ReturnData()
        {
            Console.WriteLine($"Dog {Name} is {Age} year/`s old, it is {Sex}, {BreedName}");
        }

    }
}
