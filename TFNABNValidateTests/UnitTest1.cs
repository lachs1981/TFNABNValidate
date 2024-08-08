using TFNABNValidate;

namespace TFNABNValidateTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestABN()
        {
            //valid ABN: 91 141 447 207
            string abnTestStringTrue = "91 141 447 207";
            string abnTestStringFalse = "91 141 447 208";
            Assert.True(abnTestStringTrue.IsValidABN());
            Assert.False(abnTestStringFalse.IsValidABN());
        }
        [Fact]
        public void TestTFN()
        {
            //valid 8 digit TFN: 44 930 800
            //valid 9 digit TFN: 955 027 654
            string tfnTestString8 = "44 930 800";
            string tfnTestString9 = "955 027 654";
            string tfnTestString8False = "44 930 801";
            string tfnTestString9False = "955 027 655";
            Assert.True(tfnTestString8.IsValidTFN());
            Assert.True(tfnTestString9.IsValidTFN());
            Assert.False(tfnTestString8False.IsValidTFN());
            Assert.False(tfnTestString9False.IsValidTFN());
        }
    }

}