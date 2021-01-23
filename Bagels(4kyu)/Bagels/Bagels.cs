using System;
using System.Linq;

namespace Bagels
{
    public class BagelSolver
    {
        public static Bagel Bagel
        {
            get
            {
                var bagel = new Bagel();
                bagel.GetType().GetProperty("Value").SetValue(bagel, 4);
                return bagel;
            }
        }
    }

    public sealed class Bagel
    {
        public int Value { get; private set; } = 3;
    }
}
