using BeFaster.App.Solutions.HLO;
using BeFaster.App.Solutions.SUM;
using NUnit.Framework;
using System;

namespace BeFaster.App.Tests.Solutions.SUM
{
    [TestFixture]
    public class HelloSolutionTest
    {
        [Test]
        public void WhenCalled_ReturnHelloWorld()
        {
            var result = HelloSolution.Hello("");

            Assert.AreEqual("Hello, World!", result);
        }

    }
}


