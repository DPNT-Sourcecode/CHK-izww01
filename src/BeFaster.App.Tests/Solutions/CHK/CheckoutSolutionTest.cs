using BeFaster.App.Solutions.CHK;
using BeFaster.App.Solutions.HLO;
using BeFaster.App.Solutions.SUM;
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
    }
}

