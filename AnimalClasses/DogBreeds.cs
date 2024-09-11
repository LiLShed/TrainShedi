using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClasses
{
    internal class DogBreeds : Breeds
    {
        public DogBreeds(string BreedType):base(BreedType)
        {
            this.BreedType = BreedType; 
        }
        public static List<DogBreeds> GetDogBreeds()
        {
            return new List<DogBreeds>
        {
            new DogBreeds("Labrador Retriever"),
            new DogBreeds("German Shepherd"),
            new DogBreeds("Golden Retriever"),
            new DogBreeds("Bulldog"),
            new DogBreeds("Poodle"),
            new DogBreeds("Beagle"),
            new DogBreeds("Rottweiler"),
            new DogBreeds("Yorkshire Terrier"),
            new DogBreeds("Boxer"),
            new DogBreeds("Dachshund"),
            new DogBreeds("Siberian Husky"),
            new DogBreeds("Great Dane"),
            new DogBreeds("Doberman Pinscher"),
            new DogBreeds("Shih Tzu"),
            new DogBreeds("Australian Shepherd")
        };
        }
        public static void ShowAllDogBreeds()
        {
            List<DogBreeds> dogBreeds = DogBreeds.GetDogBreeds();
            Console.WriteLine("\nDog Breeds:");
            short i=0;
            foreach (var breed in dogBreeds)
            {
                i++;
                Console.WriteLine($"{i}. {breed.BreedType}");
            }
        }
        public static string GetSelectedDogBreed(short num)
        {
            List<DogBreeds> dogBreeds = DogBreeds.GetDogBreeds();
            if (num > 0 && num <= dogBreeds.Count)
            {
                return dogBreeds[num - 1].BreedType;
            }
            else
            {
                return "Invalid number.";
            }
        }
    }
}
