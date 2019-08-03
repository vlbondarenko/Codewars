using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnAndAnn
{
    public class Johnann
    {
        public static List<long> John(long n)
        {
            var johnKata = new List<long> { 0 };
            var annKata = new List<long> { 1 };            
            for (int i = 1; i < n; i++)
            {
                var item = i - CalculationNumOfKata((int)johnKata[i - 1], annKata, johnKata);
                johnKata.Add(item);
            }

            return johnKata;
        }
        public static List<long> Ann(long n)
        {
            var annKata = new List<long> { 1 };
            var johnKata = new List<long> { 0 };
            for (int i = 1; i < n; i++)
            {
                var item = i - CalculationNumOfKata((int)annKata[i - 1], johnKata, annKata);
                annKata.Add(item);
            }

            return annKata;
        }



        public static long SumJohn(long n)
        {
            return John(n).Sum();
        }
        public static long SumAnn(long n)
        {
            return Ann(n).Sum();
        }

        public static long CalculationNumOfKata(int day,IList<long> first,IList<long> second)
        {
            if (first.Count <= day)
            {
                var item = day - second[(int)first[day - 1]];
                first.Add(item);
            }
            return first[day];
        }
    }
}
