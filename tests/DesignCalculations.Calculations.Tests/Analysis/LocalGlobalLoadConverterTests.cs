using System;
using Jpp.DesignCalculations.Calculations.Analysis;
using NUnit.Framework;

namespace Jpp.DesignCalculations.Calculations.Tests.Analysis
{
    [TestFixture]
    public class LocalGlobalLoadConverterTests
    {
        [TestCase(0, 0, 50, 0, 0, 50, 0)]
        [TestCase(0, 0, -50, 0, 0, -50, 0)]
        [TestCase(0, 0, 0, -50, 0, 0, -50)]
        [TestCase(0, 0, 0, 50, 0, 0, 50)]
        [TestCase(10, 0, 50, 0, 0, 49.2, -8.68)]
        [TestCase(-10, 0, 50, 0, 0, -49.2, 8.68)]
        [TestCase(10, 0, -50, 0, 0, -49.2, 8.68)]
        [TestCase(-10, 0, -50, 0, 0, 49.2, -8.68)]
        [TestCase(10, 0, 0, 50, 0, 8.68, 49.2)]
        [TestCase(10, 0, 0, -50, 0, -8.68, -49.2)]
        [TestCase(-10, 0, 0, 50, 0, -8.68, 49.2)]
        [TestCase(-10, 0, 0, -50, 0, 8.68, -49.2)]
        [TestCase(10, 0, 50, 50, 0, 57.88, 40.52)]
        [TestCase(10, 0, -50, -50, 0, -57.88, -40.52)]
        public void TestConversion(double bearing, double localMajorShear, double localMinorShear, double localAxial, double expectedMajorShear, double expectedMinorShear, double expectedAxial)
        {
            LocalGlobalLoadConverter calc = new LocalGlobalLoadConverter();
            calc.Bearing = bearing;
            calc.LocalMajorShear = localMajorShear;
            calc.LocalMinorShear = localMinorShear;
            calc.LocalAxial = localAxial;

            calc.Run(new OutputBuilder());

            Assert.IsTrue(calc.Calculated, "Calc failed to complete.");
            Assert.AreEqual(expectedMajorShear, calc.GlobalMajorShear, Math.Abs(expectedMajorShear) * 0.001);
            Assert.AreEqual(expectedMinorShear, calc.GlobalMinorShear, Math.Abs(expectedMinorShear) * 0.001);
            Assert.AreEqual(expectedAxial, calc.GlobalAxial, Math.Abs(expectedAxial) * 0.001);
        }
    }
}
