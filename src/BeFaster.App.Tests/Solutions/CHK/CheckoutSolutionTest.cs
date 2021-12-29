﻿using BeFaster.App.Solutions.CHK;
using NUnit.Framework;
using System;

namespace BeFaster.App.Tests.Solutions.SUM
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
    }
}

