using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traineeCSHARP
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
        public static void ShowData(string? name, DateTime? releaseDate, long? count, string? company)
        {
            string releaseDateString = releaseDate.HasValue ? releaseDate.Value.ToString("dd.MM.yyyy") : "N/A";
            Console.WriteLine($"{name} of {company} is released at {releaseDateString} with {count} copies");
        }
        public void WriteDataInFile(string path, string? name, DateTime? releaseDate, long? count, string? company)
        {
            string releaseDateString = releaseDate.HasValue ? releaseDate.Value.ToString("dd.MM.yyyy") : "N/A";
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                //Write a line of text
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"|{name.PadRight(15,'_')}|{company.PadRight(15, '_')}|{releaseDateString.PadRight(12, '_')}|{count.ToString().PadRight(15, '_')}|\n");
                    //Close the file
                    sw.Close();
                }
                Console.WriteLine($"Data about game {name} is recorded!");
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
