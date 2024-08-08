using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShediCalculator
{
    internal class Lexer
    {
        private static readonly Regex numberRegex = new Regex(@"\d+(\.\d+)?");
        private static readonly Regex operatorRegex = new Regex(@"[\+\-\*/\^]");
        private static readonly Regex parenthesisRegex = new Regex(@"[\(\)]");

        public List<Token> Tokenize(string input)
        {
            List<Token> tokens = new List<Token>();
            int i = 0;

            while (i < input.Length)
            {
                char current = input[i];

                if (char.IsWhiteSpace(current))
                {
                    i++;
                    continue;
                }

                if (numberRegex.IsMatch(current.ToString()))
                {
                    string number = ParseNumber(input, ref i);
                    tokens.Add(new Token(TokenType.Number, number));
                    continue;
                }

                if (operatorRegex.IsMatch(current.ToString()))
                {
                    tokens.Add(new Token(TokenType.Operator, current.ToString()));
                    i++;
                    continue;
                }

                if (parenthesisRegex.IsMatch(current.ToString()))
                {
                    tokens.Add(new Token(current == '(' ? TokenType.LeftParenthesis : TokenType.RightParenthesis, current.ToString()));
                    i++;
                    continue;
                }

                throw new Exception($"Unexpected character: {current}");
            }

            return tokens;
        }

        private string ParseNumber(string input, ref int i)
        {
            int start = i;
            while (i < input.Length && (char.IsDigit(input[i]) || input[i] == '.'))
            {
                i++;
            }
            return input.Substring(start, i - start);
        }
    }
}
