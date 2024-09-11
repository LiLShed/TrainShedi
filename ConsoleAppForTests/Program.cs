using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using String = System.String;
namespace TraineeCSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            String a = Console.ReadLine();
            a.ToUpper().Replace("123", "Suka?");
            Console.WriteLine(a);

            StringBuilder sb = new StringBuilder();
            sb.Append(a);
            Console.WriteLine(sb);
        }
    }
}