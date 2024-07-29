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
        public string Name { get; set; }
        public string Sex { get; set; }
        public string BreedName { get; set; }

        public AnimalAbstractClass(string name, short? age, string sex)
        {
            Name = name;
            Age = age ?? 0;
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

        public void InputData(string animalType)
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

            Console.Write($"Choose your {animalType} breed by entering it number: ");
            if (animalType.ToLower() == "cat")
            {
                CatBreeds.ShowAllCatBreeds();
            }
            else DogBreeds.ShowAllDogBreeds();
            short num = short.Parse(Console.ReadLine());
            if (animalType.ToLower() == "cat")
            {
                BreedName = CatBreeds.GetSelectedCatBreed(num);
            }
            else BreedName = DogBreeds.GetSelectedDogBreed(num);
            
            Console.Write("Enter sex m/f: ");
            Sex = Console.ReadLine();
            switch (Sex.ToLower())
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
