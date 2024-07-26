using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClasses
{
    abstract internal class AnimalAbstractClass
    {
        public int Age { get { return Age; }  set { Age = 0; } }
        public string BreedName { get { return BreedName; }  set { BreedName = ""; } }
        public string Name { get { return Name; }  set { Name = ""; } }
        public string Sex { get { return Sex; }  set { Sex = ""; } }

        public AnimalAbstractClass(string name, int? age, string sex,string breed = "No Breed")
        {
            Name = name;
            Age = age ?? 0;
            BreedName = breed;
            Sex = sex;
        }
        public AnimalAbstractClass() { }
        public void Running ()
        {
            Console.WriteLine($"{Name} is running");
        }

        public void Eating()
        {
            Console.WriteLine($"{Name} is eating food");
        }

        public override string ToString()
        {
            return $"{Name} is {Age} years old, it is {Sex}, {BreedName}";
        }
    }
}
