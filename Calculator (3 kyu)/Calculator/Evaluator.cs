using System;
using System.Globalization;
using System.Text.RegularExpressions;


namespace Calculator
{
    public class Evaluator
    {

        private static readonly NumberFormatInfo format = CultureInfo.InvariantCulture.NumberFormat;

        private static readonly Regex subexpression = new Regex(@"\((?<subexpression>[^()]+)\)");

        private static readonly string num = @"(\d|\.)";
        private static readonly string leftOperand = $"(?<left>-?{num}+)";
        private static readonly string rightOperand = $"(?<right>-?{num}+)";
        private static readonly string mulOrDiv = @"(\*|/)";
        private static readonly string addOrSub = @"(\+|-)";

        public double Evaluate(string expression)
        {
            
            expression = Regex.Replace(expression, " +", "");


            while (subexpression.IsMatch(expression))
                expression = subexpression.Replace(expression, match => Evaluate(match.Groups["subexpression"].Value).ToString(format));

            double result;

            //As long as the expression is not a singular number we perform the following
            while (!double.TryParse(expression, NumberStyles.Number, format, out result))
            {
                //Removing duplicate of negative. 
                expression = Regex.Replace(expression, $"(?<!{num})--(?<right>{num}+)", operand => Right(operand).ToString());

                //Calculate the leftmost multiplication
                expression = Regex.Replace(expression, $"(?<!{mulOrDiv}{num}*){leftOperand}\\*{rightOperand}", operand => (Left(operand) * Right(operand)).ToString(format));


                //Calculate the leftmost division
                expression = Regex.Replace(expression, $"(?<!{mulOrDiv}{num}*){leftOperand}/{rightOperand}", operand => (Left(operand) / Right(operand)).ToString(format));

                //Calculate the leftmost addition. The operation of multiplication or division take precedence
                expression = Regex.Replace(expression, $"(?<!{addOrSub}|{mulOrDiv}{num}*){leftOperand}\\+{rightOperand}(?!{num}*{mulOrDiv})", operand => (Left(operand) + Right(operand)).ToString(format));

                //Calculate the leftmost substraction. The operation of multiplication or division take precedence
                expression = Regex.Replace(expression, $"(?<!{addOrSub}|{mulOrDiv}{num}*){leftOperand}-{rightOperand}(?!{num}*{mulOrDiv})", operand => (Left(operand) - Right(operand)).ToString(format));
            }
            return result;

            double Left(Match operand) => double.Parse(operand.Groups["left"].Value, format);
            double Right(Match operand) => double.Parse(operand.Groups["right"].Value, format);
        }
    }
}
