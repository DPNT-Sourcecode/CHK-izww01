using BeFaster.App.Solutions.HLO;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.HLO
{
    [TestFixture]
    public class HelloSolutionTest
    {
        [Test]
        public void WhenCalledWithNoInputs_ReturnHelloWorld()
        {
            var result = HelloSolution.Hello("");

            Assert.AreEqual("Hello, World!", result);
        }


        [Test]
        public void WhenCalledWithName_ReturnHelloName()
        {
            var result = HelloSolution.Hello("John");

            Assert.AreEqual("Hello, John!", result);
        }

    }
}

