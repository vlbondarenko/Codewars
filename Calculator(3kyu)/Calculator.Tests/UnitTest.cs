using NUnit.Framework;
using Calculator;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace Calculator.Tests
{

    [TestFixture]
    public class UnitTest
    {
        Evaluator Evaluator { get; set; } = new Evaluator();


        [Test]
        [TestCase("1-1", ExpectedResult = 0)]
        [TestCase("1+1", ExpectedResult = 2)]
        [TestCase("1 - 1", ExpectedResult = 0)]
        [TestCase("1* 1", ExpectedResult = 1)]
        [TestCase("1 /1", ExpectedResult = 1)]
        [TestCase("12*-1", ExpectedResult = -12)]
        [TestCase("12* 123/-(-5 + 2)", ExpectedResult = 492)]
        [TestCase("((80 - (19)))", ExpectedResult = 61)]
        [TestCase("(1 - 2) + -(-(-(-4)))", ExpectedResult = 3)]
        [TestCase("1 -- (-(-(-4)))", ExpectedResult = -3)]
        [TestCase("(1 - 2)-(-(-(-4)))", ExpectedResult = 3)]
        [TestCase("1 + (-(-(-4)))", ExpectedResult = -3)]
        [TestCase("12* 123/(-5 + 2)", ExpectedResult = -492)]
        [TestCase("(123.45*(678.90 / (-2.5+ 11.5)-(((80 -(19))) *33.25)) / 20) - (123.45*(678.90 / (-2.5+ 11.5)-(((80 -(19))) *33.25)) / 20) + (13 - 2)/ -(-11) ", ExpectedResult = 1)]
        [TestCase("-123", ExpectedResult = -123)]
        [TestCase("2 /2+3 * 4.75- -6", ExpectedResult = 21.25)]
        [TestCase("123", ExpectedResult = 123)]
        [TestCase("12* 123", ExpectedResult = 1476)]
        [TestCase("12 * -123", ExpectedResult = -1476)]
        [TestCase("2 / (2 + 3) * 4.33 - -6", ExpectedResult = 7.7320000000000002d)]
        [TestCase("2 / (2 + 3) * 4.33 + 6", ExpectedResult = 7.7320000000000002d)]
        [TestCase("((2.33 / (2.9+3.5)*4) - -6)", ExpectedResult = 7.4562499999999998d)]
        [TestCase("123.45*(678.90 / (-2.5+ 11.5)-(80 -19) *33.25) / 20 + 11", ExpectedResult = -12042.760875d)]
        [TestCase("2*(-(-1))+3-(-4)", ExpectedResult = 9)]
        [TestCase("((2.33 / (2.9+3.5)*4)+6)", ExpectedResult = 7.4562499999999998d)]
        [TestCase("123/-(-5 + 2)", ExpectedResult = 41)]
        public double TestEvaluation(string expression)
        { 
            return Evaluator.Evaluate(expression);
        }     
    }
}