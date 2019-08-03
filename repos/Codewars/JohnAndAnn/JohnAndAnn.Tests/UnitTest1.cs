using System;
using System.Collections.Generic;
using NUnit.Framework;
using JohnAndAnn;

namespace JohnAndAnn
{
    [TestFixture]
    public static class JohannTests
    {

        private static string Array2String(List<long> list)
        {
            return "[" + string.Join(", ", list) + "]";
        }
        private static void testJohn(long n, string res)
        {
            Assert.AreEqual(res, Array2String(Johnann.John(n)));
        }
        private static void testAnn(long n, string res)
        {
            Assert.AreEqual(res, Array2String(Johnann.Ann(n)));
        }
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests John");
            testJohn(11, "[0, 0, 1, 2, 2, 3, 4, 4, 5, 6, 6]");
        }
        [Test]
        public static void test2()
        {
            Console.WriteLine("Basic Tests Ann");
            testAnn(6, "[1, 1, 2, 2, 3, 3]");

        }
        private static void testSumAnn(long n, long res)
        {
            Assert.AreEqual(res, Johnann.SumAnn(n));
        }
        private static void testSumJohn(long n, long res)
        {
            Assert.AreEqual(res, Johnann.SumJohn(n));
        }
        [Test]
        public static void test3()
        {
            Console.WriteLine("Basic Tests SumAnn");
            testSumAnn(115, 4070);
        }
        [Test]
        public static void test4()
        {
            Console.WriteLine("Basic Tests SumJohn");
            testSumJohn(75, 1720);
        }
    }
}

