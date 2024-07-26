using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClasses
{
    internal class FileRecorder
    {
        private string FilePath;
        public FileRecorder()
        { }
        public FileRecorder(string path)
        {
            FilePath = path;
        }

        public void WriteDataInFile(string path, string? name, int? age, string? sex, string? breed)
        {
            string? agestring = age.ToString();
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                //Write a line of text
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"|{name.PadRight(15, '_')}|{sex.PadRight(8, '_')}|{agestring.PadRight(10, '_')}|{breed.ToString().PadRight(20, '_')}|\n");
                    //Close the file
                    sw.Close();
                }
                Console.WriteLine($"Data about {name} is recorded!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine("___________________________________________________________________");
        }

        public string ShowFile(string path)
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
}
