using System;
using Jpp.DesignCalculations.Calculations.Design.Foundations;
using NUnit.Framework;

namespace Jpp.DesignCalculations.Calculations.Tests.Design.Foundations
{
    [TestFixture]
    public class FoundationWidthTests
    {
        [TestCase(100, 150, 0.1, ExpectedResult = 0.75)]
        [TestCase(45, 100, 0.1, ExpectedResult = 0.45)]
        [TestCase(44, 100, 0.1, ExpectedResult = 0.45)]
        [TestCase(46, 100, 0.1, ExpectedResult = 0.6)]
        [TestCase(5, 100, 0.3, ExpectedResult = 0.45)]
        [TestCase(5, 100, 0.1, ExpectedResult = 0.30)]
        public double CalculateFoundationWidth(double? appliedLoad, double? groundBearingPressure, double? wallThickness)
        {
            FoundationWidth widthCalc = new FoundationWidth()
            {
                AppliedLoad = appliedLoad,
                GroundBearingPressure = groundBearingPressure,
                WallThickness = wallThickness
            };

            widthCalc.Run();

            Assert.IsTrue(widthCalc.Calculated, "Calculation failed to complete successfully");

            return widthCalc.RequiredWidth.Value;
        }

        [TestCase(null, 150, 0.1)]
        [TestCase(100, null, 0.1)]
        [TestCase(100, 150, null)]
        public void AppliedLoadRequired(double? appliedLoad, double? groundBearingPressure, double? wallThickness)
        {
            FoundationWidth calc = new FoundationWidth()
            {
                AppliedLoad = appliedLoad,
                GroundBearingPressure = groundBearingPressure,
                WallThickness = wallThickness
            };

            Assert.Throws(typeof(ArgumentNullException), () => calc.Run());
            Assert.IsFalse(calc.Calculated, "Calculation should not have completed");
        }
    }
}
