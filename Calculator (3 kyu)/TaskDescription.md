## Calculator

Create a simple calculator that given a string of operators (), +, -, *, / and numbers separated by spaces returns the value of that expression

### Example:

    Calculator().evaluate("2 / 2 + 3 * 4 - 6") # => 7

Remember about the order of operations! Multiplications and divisions have a higher priority and should be performed left-to-right. Additions and subtractions have a lower priority and should also be performed left-to-right.


### P.S.
После долгих мучений при создании собственных велосипедов, после безуспешных попыток адаптировать обратную польскую нотацию для решения данной задачи, мне все таки не удалось решить проблему с дублирующимися минусами, или минусами, следующими сразу после какого-нибудь другого оператора. Например, первый вариант алгоритма не могу решить выражение "12 * -123", а алгоритм, использующий обратную польскую нотацию, не способен был вычислить выражение "1 -- (-(-(-4)))" (эти выражения были в тестах к этой задаче на сайте codewars.com). 
В итоге, решение было найдено при помощи регулярных выражений. Оказывается это очень мощная и полезная штука! Ранее я видел мемы о регулярных выражениях, и то в том духе, что это очень сложный механизм и познать его могут только избранные 😁. На деле же оказалось, что не все так печально, и что, разобравшьсь в этом механизме, можно с помощью них даже реализовать калькулятор))

Ах, да.. Есть еще решение этой задачи в одну строку, но это уже совсем просто 🙂
    
    
    using System;
    using System.Data;

    public class Evaluator
    {
        public double Evaluate(string expression)
        {
            return Math.Round(Convert.ToDouble(new DataTable().Compute(expression, "")), 6);
        }
    }