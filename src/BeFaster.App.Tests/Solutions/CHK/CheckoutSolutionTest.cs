using BeFaster.App.Solutions.CHK;
using NUnit.Framework;
using System;

namespace BeFaster.App.Tests.Solutions.SUM
{
    [TestFixture]
    public class CheckoutSolutionTest
    {
        [Test]
        public void WhenPassedAnEmptyString_ReturnMinusOne()
        {
            var result = CheckoutSolution.ComputePrice("");

            Assert.AreEqual(CheckoutSolution.IllegalInput, result);
        }

        [TestCase("A", ExpectedResult = 50)]
        [TestCase("B", ExpectedResult = 30)]
        [TestCase("C", ExpectedResult = 20)]
        [TestCase("D", ExpectedResult = 15)]
        public int WhenPassedAnSingleSku_ReturnValue(string sku)
        {
            return CheckoutSolution.ComputePrice(sku);
        }
    }
}


