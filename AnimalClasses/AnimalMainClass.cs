using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalClasses;
using System.Diagnostics;
namespace TraineeCSHARP
{
    class AnimalMainClass
    {
        static void Main(string[] args)
        {
            var path = "D:\\traineeCSHARP\\TestAnimals.txt";
            var recorder = new FileRecorder();
            Console.Write("Hello, This is a Animal logger,\n" +
                "Where you can text and save info about ur pet.\n");

            Console.WriteLine("____________________________________________________");
            bool keyMainMenu = true;
            AnimalAbstractClass animalAbstract;
            do
            {
                Console.Write("Who is your pet? dog/cat ");
                string animalType = Console.ReadLine().ToLower();
                switch (animalType)
                {
                    case "cat": 
                        animalAbstract = new Cats();
                        animalAbstract.InputData(animalType);
                        animalAbstract.ReturnData();
                        recorder.WriteDataInFile(path, animalAbstract.Name, animalAbstract.Age, animalAbstract.Sex, animalAbstract.BreedName, animalType);
                        break;
                    case "dog":
                        animalAbstract = new Dogs();
                        animalAbstract.InputData(animalType);
                        animalAbstract.ReturnData();
                        recorder.WriteDataInFile(path, animalAbstract.Name, animalAbstract.Age, animalAbstract.Sex, animalAbstract.BreedName, animalType);
                        break;
                    default: return;
                }
                Console.ReadLine();
                Console.Write("\nThat`s all! Do u want to continue, close - c:  ");
                if (Console.ReadKey().KeyChar == 'c')
                {
                    keyMainMenu = false;
                }
                Console.Clear();
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