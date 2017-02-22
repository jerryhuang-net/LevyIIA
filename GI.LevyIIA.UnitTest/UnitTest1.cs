using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GI.LevyIIA.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var levy = LevyIIA.Calculate(new DateTime(2018, 5, 1),
                10000);
            Assert.AreEqual(levy.LevyAmount, 4.0M, "LevyAmount not correct");

        }

        [TestMethod]
        public void TestMethod2()
        {
            var levy = LevyIIA.CalculateWithPromoDiscount(new DateTime(2018, 5, 1),
                10000, 1000);
            Assert.AreEqual(levy.LevyAmount, 3.6M, "LevyAmount not correct");

        }

        [TestMethod]
        public void TestMethod3()
        {
            var levy = LevyIIA.CalculateWithChannelDiscount(new DateTime(2018, 5, 1),
                10000, 4000);
            Assert.AreEqual(levy.LevyAmount, 2.4M, "LevyAmount not correct");
            Assert.AreEqual(levy.LevyAmountChannel, 1.6M, "channel LevyAmount not correct");
        }


    
    }
}
