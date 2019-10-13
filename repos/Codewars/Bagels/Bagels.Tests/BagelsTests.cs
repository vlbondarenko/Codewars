using NUnit.Framework;
using Bagels;

namespace Bagels.Tests
{
    [TestFixture]
    public class BagelsTests
    {
        [Test]
        public void TestBagel()
        {
            Bagel bagel = BagelSolver.Bagel;
            Assert.AreEqual(4, bagel.Value);
        }
    }
}