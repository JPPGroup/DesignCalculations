using System;
using Jpp.DesignCalculations.Calculations.Tests.TestObjects;
using NUnit.Framework;

namespace Jpp.DesignCalculations.Calculations.Tests
{
    [TestFixture]
    internal class CalculationTests
    {
        [Test]
        public void ResetCalculationCheck()
        {
            BaseCalculation calc = new BaseCalculation();
            calc.Run(new OutputBuilder());
            
            Assert.IsTrue(calc.TestOutput);
            Assert.IsTrue(calc.Calculated);

            calc.ResetCalculation();

            Assert.IsNull(calc.TestOutput);
            Assert.IsFalse(calc.Calculated);
        }

        [Test]
        public void VerifyInputsCheck()
        {
            BaseCalculation calc = new BaseCalculation();
            
            Assert.Throws(typeof(ArgumentNullException), () => calc.VerifyInputs());
        }
    }
}
