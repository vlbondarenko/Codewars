using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Evaluator
    {
        public double Evaluate(string expression)
        {
            return 0.0;
        }

        public IEnumerable<string> SplitExpressionIntoLexemеs(string expression)
        {
            var operators = new List<string>(new string[] { "(", ")", "+", "-", "*", "/", "^" });
            var lexemes = new List<string>();
            var index = 0;
            expression = expression.Replace(" ", "");

            while (index < expression.Length)
            {
                var lexema = string.Empty + expression[index];

                if (Char.IsDigit(expression[index]))
                {
                    for (int nextIndex = index + 1; nextIndex < expression.Length && (Char.IsDigit(expression[nextIndex]) || expression[nextIndex] == '.'); nextIndex++)
                    {
                        lexema += expression[nextIndex];
                    }
                } else if (operators.Contains(expression[index].ToString()))
                {
                    lexema = expression[index].ToString();
                }

                lexemes.Add(lexema);
                index += lexema.Length;
            }

            return lexemes;
        }
    }
}
