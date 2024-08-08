using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFNABNValidate;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestABN()
        {
            //valid ABN: 91 141 447 207
            string abnTestString = "91 141 447 207";
            Assert.IsTrue(abnTestString.IsValidABN());
        }

        [TestMethod]
        public void TestTFN()
        {
            //valid 8 digit TFN: 44 930 800
            //valid 9 digit TFN: 955 027 654
            string tfnTestString = "955 027 654";
            Assert.IsTrue(tfnTestString.IsValidTFN());
        }
    }
}
