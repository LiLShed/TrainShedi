using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClasses
{
    internal class CatBreeds : Breeds
    {
        public CatBreeds(string BreedType) : base(BreedType)
        {
            this.BreedType = BreedType;
        }
        public static List<CatBreeds> GetCatBreeds()
        {
            return new List<CatBreeds>
        {
            new CatBreeds("Siamese"),
            new CatBreeds("Persian"),
            new CatBreeds("Maine Coon"),
            new CatBreeds("Ragdoll"),
            new CatBreeds("British Shorthair"),
            new CatBreeds("Bengal"),
            new CatBreeds("Sphynx"),
            new CatBreeds("Russian Blue"),
            new CatBreeds("Scottish Fold"),
            new CatBreeds("Abyssinian"),
            new CatBreeds("Birman"),
            new CatBreeds("Oriental Shorthair"),
            new CatBreeds("Devon Rex"),
            new CatBreeds("Norwegian Forest"),
            new CatBreeds("American Shorthair")
        };
        }
        public static void ShowAllCatBreeds()
        {
            List<CatBreeds> catBreeds = CatBreeds.GetCatBreeds();
            Console.WriteLine("\nCat Breeds:");
            short i = 0;
            foreach (var breed in catBreeds)
            {
                i++;
                Console.WriteLine($"{i}. {breed.BreedType}");
            }
        }
        public static string GetSelectedCatBreed(short num)
        {
            List<CatBreeds> catBreeds = CatBreeds.GetCatBreeds();
            if (num > 0 && num <= catBreeds.Count)
            {
                return catBreeds[num - 1].BreedType;
            }
            else
            {
                return "Invalid number.";
            }
        }
    }
}
