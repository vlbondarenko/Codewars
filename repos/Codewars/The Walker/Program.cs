using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Walker
{

   
    class Program
    {

        static void Main(string[] args)
        {
            foreach(var res in Solve(11, 24, 16, 40, 28, 62))
            {
                Console.WriteLine(res+" ");
            }
            Console.ReadKey();
        }
        public static int[] Solve(int oa,int ab,int bc,int alpha,int beta,int gamma)
        {

            int boaAngle = 90 - alpha + beta;
            double vectorOB = VectorAddition(oa,ab,boaAngle);
            double tauAngle = Math.Round( beta - (boaAngle - AngleUnderVectors(ab, vectorOB, (180-boaAngle))),6);
            double vectorCO =VectorAddition(vectorOB, bc, (90-tauAngle+gamma));
            double tettaAngle = AngleUnderVectors(bc,vectorCO, (90+tauAngle-gamma));
            double resultAngle = 90 + tauAngle + tettaAngle;
            return (new int[] { (int)Math.Round(vectorCO) }).Concat(DegreeToMinAndSec(resultAngle)).ToArray();

        }

        private static double VectorAddition(double firstVector,double secondVector,double angle)
        {
            double result;
            result = Math.Sqrt(Math.Pow(firstVector, 2) + Math.Pow(secondVector, 2) + 2 * firstVector * secondVector * Math.Cos(angle * Math.PI / 180));
            return Math.Round(result, 6);
        }

        private static double AngleUnderVectors(double firstVector, double secondVector, double angle) =>
            Math.Round((Math.Asin((firstVector*Math.Sin(angle * Math.PI / 180))/secondVector)*180/Math.PI),6);
      
        private static int[] DegreeToMinAndSec(double degrees)
        {
            int resultDegree = (int)degrees;
            var minAsDouble = 60 * (degrees - resultDegree);
            var secAsDouble =Math.Round(60 * (minAsDouble - (int)minAsDouble));
            return  new int[]{resultDegree,(int)minAsDouble, (int)secAsDouble};
           
        }
        
    }


    