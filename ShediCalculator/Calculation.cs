using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShediCalculator
{
    internal class Calculation
    {
        public static double Calculate(string input)
        {
            Lexer lexer = new Lexer();
            var tokens = lexer.Tokenize(input);  // Розбиваємо рядок на токени
            return EvaluateTokens(tokens);  // Обчислюємо значення виразу на основі токенів
        }

        private static double EvaluateTokens(List<Token> tokens)
        {
            Stack<double> numbers = new Stack<double>();  // Стек для чисел
            Stack<string> operators = new Stack<string>();  // Стек для операторів

            int i = 0;
            while (i < tokens.Count)
            {
                if (tokens[i].Type == TokenType.Number)
                {
                    numbers.Push(double.Parse(tokens[i].Value, CultureInfo.InvariantCulture));  // Додаємо число до стека
                }
                else if (tokens[i].Type == TokenType.Operator)
                {
                    while (operators.Count > 0 && GetPrecedence(operators.Peek()) >= GetPrecedence(tokens[i].Value))
                    {
                        ProcessOperator(numbers, operators.Pop());  // Обробляємо оператор з вищим або рівним пріоритетом
                    }
                    operators.Push(tokens[i].Value);  // Додаємо оператор до стека
                }
                else if (tokens[i].Type == TokenType.LeftParenthesis)
                {
                    operators.Push(tokens[i].Value);  // Додаємо ліву дужку до стека
                }
                else if (tokens[i].Type == TokenType.RightParenthesis)
                {
                    while (operators.Peek() != "(")
                    {
                        ProcessOperator(numbers, operators.Pop());  // Обробляємо оператори до лівої дужки
                    }
                    operators.Pop();  // Видаляємо ліву дужку з стека
                }
                i++;
            }

            while (operators.Count > 0)
            {
                ProcessOperator(numbers, operators.Pop());  // Обробляємо всі залишкові оператори
            }

            return numbers.Pop();  // Повертаємо кінцевий результат
        }

        private static int GetPrecedence(string op)
        {
            return op switch
            {
                "+" or "-" => 1,
                "*" or "/" => 2,
                "^" => 3,
                _ => 0
            };
        }

        private static void ProcessOperator(Stack<double> numbers, string op)
        {
            double b = numbers.Pop();
            double a = numbers.Pop();
            switch (op)
            {
                case "+":
                    numbers.Push(a + b);
                    break;
                case "-":
                    numbers.Push(a - b);
                    break;
                case "*":
                    numbers.Push(a * b);
                    break;
                case "/":
                    numbers.Push(a / b);
                    break;
                case "^":
                    numbers.Push(Math.Pow(a, b));
                    break;
            }
        }
    }
}
