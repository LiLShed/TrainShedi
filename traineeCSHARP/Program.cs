using System;
using System.IO;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using System.Linq;
using traineeCSHARP;

namespace TraineeCSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "D:\\traineeCSHARP\\Test.txt";
            var recorder = new FileRecorder();
            Console.Write("Hello, This is a Game Info Logger,\n" +
            "Where you can text and save info about game u want.\n");

            Console.WriteLine("____________________________________________________");
            bool keyMainMenu = true;
            do
            {
                Console.WriteLine("Enter name of Game: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Company name of " + name);
                string Company = Console.ReadLine();
                Console.WriteLine("Enter Count Of Copies " + name);
                int count;
                    try
                    {
                        count = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                        throw;
                    }

                Console.WriteLine("Enter ReleaseDate of " + name + " from " + Company + " like 30.12.2002 without '.'\n");
                string DateRelease = Console.ReadLine();
                DateTime ReleaseDate;
                bool success = DateTime.TryParseExact(DateRelease, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ReleaseDate);

                    if (success)
                    {
                        Console.WriteLine("Entered Date: " + ReleaseDate.ToString("dd/MM/yyyy"));
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid date format entered.");
                    }

                FileRecorder.ShowData(name, ReleaseDate, count, Company);

                recorder.WriteDataInFile(path, name, ReleaseDate, count, Company);

                Console.ReadLine();
                Console.Write("\nThat`s all! Do u want to continue, close - c:  ");
                if (Console.ReadKey().KeyChar == 'c')
                {
                    keyMainMenu = false;
                }
                Console.Clear();
            } while (keyMainMenu);
            Console.Write("\nDo you want to see whole file, Yes - y:    ");
            if (Console.ReadKey().KeyChar == 'y')
            {
                Console.Clear();
                recorder.ShowFile(path);
            }
        }
    }
}
