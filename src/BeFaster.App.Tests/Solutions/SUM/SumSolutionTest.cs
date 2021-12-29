using BeFaster.App.Solutions.SUM;
using NUnit.Framework;
using System;

namespace BeFaster.App.Tests.Solutions.SUM
{
    [TestFixture]
    public class SumSolutionTest
    {

        [TestCase(-1, 0)]
        [TestCase(101, 0)]
        [TestCase(0, -1)]
        [TestCase(0, 101)]
        public void WhenInputIsInvalid_ThrowError(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => SumSolution.Sum(x, y));
        }
    }
}


