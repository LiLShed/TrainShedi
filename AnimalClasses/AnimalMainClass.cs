using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalClasses;
namespace TraineeCSHARP
{
    class AnimalMainClass
    {
        static void Main(string[] args)
        {
            var path = "D:\\AnimalClasses\\TestAnimals.txt";
            var recorder = new FileRecorder();
            Console.Write("Hello, This is a Animal logger,\n" +
                "Where you can text and save info about ur pet.\n");

            Console.WriteLine("____________________________________________________");
            bool keyMainMenu = true;
            do
            { //Write  Who is Ur Pet? Dog/Cat , make 2 functions for dogs cats by
              //Switch(string WHO):
              //case "dog" : dog.Function();
              //case "cat" : cat.Function();
              //default;
                Dogs dogs = new Dogs();
                Cats cats = new Cats();
                dogs.Running();
                cats.Running();
                cats = new Cats
                {
                    Name = "Biba",
                    BreedName = "Snus",
                    Sex = "Male",
                    Age = 10,
                };


            }
            while (keyMainMenu);
            Console.Write("\nDo you want to see whole file, Yes - y:    ");
            if (Console.ReadKey().KeyChar == 'y')
            {
                Console.Clear();
                recorder.ShowFile(path);
            }
        }
    }
}