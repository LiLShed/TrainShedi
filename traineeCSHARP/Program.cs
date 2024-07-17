using System;
using System.IO;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using System.Linq;

namespace TraineeCSHARP
{
    class Program
    {
        static List<Game> _allGames = new List<Game>();

        static void Main(string[] args)
        {
            string[] YesAnswers = ["yes","Y","y","1","Yes","YES"];
            string[] NoAnswers = ["no", "N", "n", "0", "No", "NO"];
            string line;
            string path = "D:\\traineeCSHARP\\Test.txt";
            string answer;
            Console.Write("Hello, This is a Game Info Logger,\n" +
                "Where you can text and save info about game u want.\n" +
                "Enter a number of games u want to save info about ->  ");

            int numberOfGames = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("____________________________________________________");
            while (numberOfGames > 0)
            {
                Game game = new Game(name: "BananaProject", company: "Shedi", count: 15, releaseDate: new DateTime(year: 2024, month: 12, day: 4));
                _allGames.Add(game);
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

                Console.WriteLine("Enter ReleaseDate of " + name + " from " + Company + " like 30.12.2002 without '.'");
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
                Game newGame = new Game(name: name, company: Company, count: count, releaseDate: ReleaseDate);
                _allGames.Add(newGame);
                Console.WriteLine($"ez + Game - {newGame}");

                try
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    //Write a line of text
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine(newGame + "\n");
                        //Close the file
                        sw.Close();
                    }
                    Console.WriteLine("Ez");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                Console.WriteLine("____________________________________________________");
                Console.ReadLine();
                numberOfGames--;
                if (numberOfGames == 0)
                {
                    ShowAllNotes();
                    Console.WriteLine("That`s all! Do u want to continue? Y/N");
                    answer = Console.ReadLine();
                    if (NoAnswers.Contains(answer)) break;
                    else if (YesAnswers.Contains(answer))
                    {
                        Console.Write("Enter a number of games u want to save info about ->  ");

                        numberOfGames = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("____________________________________________________");
                    }
                }
            }
            Console.WriteLine("Do you want to see whole file?");
            answer = Console.ReadLine();
            if (YesAnswers.Contains(answer))
            {
                ShowFile(path);
            }
        }

        static void ShowAllNotes()
        {
            foreach (Game game in _allGames)
            {
                Console.WriteLine(game);
            }
        }
        static string ShowFile(string path)
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(path);
            string line = File.ReadAllText(path);
            Console.WriteLine(line);
            //close the file
            sr.Close();
            return "\n";
        }

    }

    class Game
    {
        public string Name { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public long CountOfCopies { get; private set; }
        public string CompanyName { get; private set; }
        
        public Game(string name, DateTime? releaseDate, long? count, string company) 
        {
            Name = name;
            ReleaseDate = releaseDate ?? DateTime.Now;
            CountOfCopies = count ?? 0;
            CompanyName = company;
        }
        public override string ToString()
        {
            return $"{Name} of {CompanyName} is released at {ReleaseDate.ToShortDateString()} with {CountOfCopies} copies";
        }
    }

}
