using BeFaster.App.Solutions.CHK;
using NUnit.Framework;
using System;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CheckoutSolutionTest
    {
        [Test]
        public void WhenPassedAnEmptyString_ReturnZero()
        {
            var result = CheckoutSolution.ComputePrice("");

            Assert.AreEqual(0, result);
        }


        [TestCase(null, ExpectedResult = CheckoutSolution.IllegalInput)]
        [TestCase("Z", ExpectedResult = CheckoutSolution.IllegalInput)]
        [TestCase("AZ", ExpectedResult = CheckoutSolution.IllegalInput)]
        public int WhenPassedAnUnknownSku_ReturnIllegalInput(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("A", ExpectedResult = 50)]
        [TestCase("B", ExpectedResult = 30)]
        [TestCase("C", ExpectedResult = 20)]
        [TestCase("D", ExpectedResult = 15)]
        [TestCase("E", ExpectedResult = 40)]
        public int WhenPassedAnSingleSku_ReturnValue(string sku)
        {
            return CheckoutSolution.ComputePrice(sku);
        }

        [TestCase("AA", ExpectedResult = 100)]
        [TestCase("AB", ExpectedResult = 80)]
        [TestCase("AABCCC", ExpectedResult = 190)]        
        public int WhenPassedMutipleSkus_ReturnTotalValue(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("AAA", ExpectedResult = 130)]
        [TestCase("AAAAA", ExpectedResult = 200)]
        [TestCase("AAAAAA", ExpectedResult = 250)]
        [TestCase("AAAAAAAA", ExpectedResult = 330)]
        [TestCase("AAAAAAAAA", ExpectedResult = 380)]
        [TestCase("AAAA", ExpectedResult = 180)]
        [TestCase("BB", ExpectedResult = 45)]
        [TestCase("AAABB", ExpectedResult = 175)]
        [TestCase("AAABBAAA", ExpectedResult = 295)]
        public int WhenPassedMutipleSkusWithDiscounts_ReturnTotalValueWithDiscountApplied(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("EEB", ExpectedResult = 80)]
        [TestCase("EEBB", ExpectedResult = 110)]
        [TestCase("EEBBB", ExpectedResult = 125)]
        public int WhenPassedMutipleSkusWithFreeItem_ReturnTotalValueWithFreeItemsApplied(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }
    }
}



