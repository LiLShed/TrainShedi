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
            string Viraz = "3 + 4 * 2.24503 / ( 1 - 5 ) ^ 2 ^ 3";
            Lexer lexer = new Lexer();
            List<Token> tokens = lexer.Tokenize(Viraz);

            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }
            // Викликаємо метод Calculate для обчислення значення виразу
            double result = Calculation.Calculate(Viraz);

            // Виводимо результат
            Console.WriteLine($"Result: {result}");
        }
    }
}