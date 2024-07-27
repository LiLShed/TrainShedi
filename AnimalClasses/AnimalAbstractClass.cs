using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClasses
{
    abstract internal class AnimalAbstractClass
    {
        public short Age { get; set; }
        public string BreedName { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public AnimalAbstractClass(string name, short? age, string sex,string breed = "No Breed")
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

        public abstract void ReturnData();

        public void InputData()
        {

            Console.Write("Enter name of your pet: ");
            
            Name = Console.ReadLine();

            Console.Write("Enter age: ");
            try
            {
                Age = short.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                throw;
            }

            Console.Write("Enter breed name: ");
            BreedName = Console.ReadLine();

            Console.Write("Enter sex m/f: ");
            Sex = Console.ReadLine();
            switch (Sex)
            {
                case "f":
                    Sex = "female";break;
                case "m":
                    Sex = "male"; break;
                default:
                    break;
            }
        }
    }
}
