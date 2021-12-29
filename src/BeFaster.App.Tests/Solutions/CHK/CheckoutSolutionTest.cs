using BeFaster.App.Solutions.CHK;
using NUnit.Framework;
using System;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CheckoutSolutionTest
    {
        [Test]
        public void WhenPassedAnEmptyString_ReturnIllegalInput()
        {
            var result = CheckoutSolution.ComputePrice("");

            Assert.AreEqual(CheckoutSolution.IllegalInput, result);
        }


        [TestCase(null, ExpectedResult = CheckoutSolution.IllegalInput)]
        [TestCase("", ExpectedResult = CheckoutSolution.IllegalInput)]
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
        [TestCase("AAAA", ExpectedResult = 180)]
        [TestCase("BB", ExpectedResult = 45)]
        [TestCase("AAABB", ExpectedResult = 175)]
        public int WhenPassedMutipleSkusWithDiscounts_ReturnTotalValueWithDiscountApplied(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }
    }
}

