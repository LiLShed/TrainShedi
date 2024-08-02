using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShediCalculator;
using System.Diagnostics;
namespace TraineeCSHARP
{
    class MainCalculator
    {
        static void Main(string[] args)
        {
            Lexer lexer = new Lexer();
            List<Token> tokens = lexer.Tokenize("3 + 4 * 2.24503 / ( 1 - 5 ) ^ 2 ^ 3");

            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }
        }
    }
}