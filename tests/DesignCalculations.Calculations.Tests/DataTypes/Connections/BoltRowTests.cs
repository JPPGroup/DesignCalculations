using System;
using Jpp.DesignCalculations.Calculations.DataTypes.Connections;
using NUnit.Framework;

namespace Jpp.DesignCalculations.Calculations.Tests.DataTypes.Connections
{
    [TestFixture]
    class BoltRowTests
    {
        private static Bolt m24 = new Bolt()
        {
            Diameter = 0.024,
            HoleDiameter = 0.026,
            TensileStressArea = 0.000353
        };

        [TestCase(0.025, 265000, 0.05, 0.0304, 0.075, 0.075, 0.1, false, false, true, "M24", 377)] // P398 pg 89
        [TestCase(0.025, 265000, 0.0304, 0.05, 0.075, 0.075, 0.1, false, true, false, "M24", 377)] // P398 pg 89, flipped to test bottom extensions
        public void DetermineTensionResistance(double member1Thickness, double member1Yield, double majorDistanceAbove, double majorDistanceBelow, double left, double right, double gauge, bool centralStiffener, bool topStiffener, bool bottomStiffener, string bolt, double Result)
        {
            BoltRow row = new BoltRow();
            row.Member1Thickness = member1Thickness;
            row.Member1YieldStrength = member1Yield;
            row.MajorDistanceAbove = majorDistanceAbove;
            row.MajorDistanceBelow = majorDistanceBelow;
            row.MinorDistanceLeft = left;
            row.MinorDistanceRight = right;
            row.InternalGauge = gauge;
            row.CentralStiffener = centralStiffener;
            row.TopStiffener = topStiffener;
            row.BottomStiffener = bottomStiffener;

            switch (bolt)
            {
                case "M24":
                    row.Bolt = m24;
                    break;

                default:
                    throw new NotImplementedException();
            }

            row.Bolt.Run(new OutputBuilder());
            row.Run(new OutputBuilder());

            Assert.IsTrue(row.Calculated, "Calculation failed to complete successfully");
            Assert.AreEqual(Result, row.TensionResistance, 0.005 * Result);
        }

    }
}
