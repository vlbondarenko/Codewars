using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace MeanSquare
{
    public class Kata
    {
        public static double Solution(int[] firstArray, int[] secondArray)
        {
            double averageOfSquares = 0;
            double absolete = 0;
            for(int i = 0; i < firstArray.Length && i < secondArray.Length; i++)
            {
                var difference = firstArray[i] - secondArray[i];
                absolete += Pow(difference, 2);
            }
            averageOfSquares = absolete / firstArray.Length;
            return averageOfSquares; 
        }
    }
}
