using Jpp.DesignCalculations.Calculations.DataTypes.Connections;
using NUnit.Framework;

namespace Jpp.DesignCalculations.Calculations.Tests.DataTypes.Connections
{
    [TestFixture]
    class BoltTests
    {
        [TestCase(0.020, 0.022, 0.000245, 0.010, 410000, 0.040, 0.030, 0.0131, 410000, 0.09, null, 0.070, 0.140, 94.08)] //SCI P358, pg 42 Beam 1 //SCI P358, pg 38
        public void CalculateShearResistance(double Diameter, double HoleDiameter, double TensileStressArea, double Member1Thickness,
            double Member1Ultimate, double? Member1MajorEdgeDistance, double? Member1MinorEdgeDistance, double Member2Thickness,
            double Member2Ultimate, double? Member2MajorEdgeDistance, double? Member2MinorEdgeDistance, double? MajorSpacing, double? MinorSpacing, double Result)
        {
            Bolt bolt = new Bolt();
            bolt.Diameter = Diameter;
            bolt.HoleDiameter = HoleDiameter;
            bolt.TensileStressArea = TensileStressArea;
            bolt.Member1Thickness = Member1Thickness;
            bolt.Member1UltimateStrength = Member1Ultimate;
            bolt.Member1MajorEdgeDistance = Member1MajorEdgeDistance;
            bolt.Member1MinorEdgeDistance = Member1MinorEdgeDistance;
            bolt.Member2Thickness = Member2Thickness;
            bolt.Member2UltimateStrength = Member2Ultimate;
            bolt.Member2MajorEdgeDistance = Member2MajorEdgeDistance;
            bolt.Member2MinorEdgeDistance = Member2MinorEdgeDistance;
            bolt.MajorSpacing = MajorSpacing;
            bolt.MinorSpacing = MinorSpacing;

            bolt.Run(new OutputBuilder());
            Assert.IsTrue(bolt.Calculated, "Calculation failed to complete successfully");

            Assert.AreEqual(Result, bolt.ShearResistance, 0.1);
            
        }

        [TestCase(0.020, 0.022, 0.000245, 0.010, 410000, 0.040, 0.030, 0.0131, 410000, 0.09, null, 0.070, 0.140, 84.2)] //SCI P358, pg 42 Beam 1
        [TestCase(0.020, 0.022, 0.000245, 0.012, 410000, 0.040, 0.030, 0.0131, 410000, 0.09, null, 0.070, 0.140, 101)] //SCI P358, pg 42 Beam 2
        public void CalculateMember1BearingResistances(double Diameter, double HoleDiameter, double TensileStressArea, double Member1Thickness,
            double Member1Ultimate, double? Member1MajorEdgeDistance, double? Member1MinorEdgeDistance, double Member2Thickness,
            double Member2Ultimate, double? Member2MajorEdgeDistance, double? Member2MinorEdgeDistance, double? MajorSpacing, double? MinorSpacing, double Result)
        {
            Bolt bolt = new Bolt();
            bolt.Diameter = Diameter;
            bolt.HoleDiameter = HoleDiameter;
            bolt.TensileStressArea = TensileStressArea;
            bolt.Member1Thickness = Member1Thickness;
            bolt.Member1UltimateStrength = Member1Ultimate;
            bolt.Member1MajorEdgeDistance = Member1MajorEdgeDistance;
            bolt.Member1MinorEdgeDistance = Member1MinorEdgeDistance;
            bolt.Member2Thickness = Member2Thickness;
            bolt.Member2UltimateStrength = Member2Ultimate;
            bolt.Member2MajorEdgeDistance = Member2MajorEdgeDistance;
            bolt.Member2MinorEdgeDistance = Member2MinorEdgeDistance;
            bolt.MajorSpacing = MajorSpacing;
            bolt.MinorSpacing = MinorSpacing;

            bolt.Run(new OutputBuilder());
            Assert.IsTrue(bolt.Calculated, "Calculation failed to complete successfully");

            // TODO: Change delta to a percentage? 1%?
            Assert.AreEqual(Result, bolt.Member1MajorBearingResistance, 0.1);
        }

        [TestCase(0.020, 0.022, 0.000245, 0.010, 410000, 0.040, 0.030, 0.0131, 410000, 0.09, null, 0.070, 0.140, 174)] //SCI P358, pg 42 Beam 1
        [TestCase(0.020, 0.022, 0.000245, 0.012, 410000, 0.040, 0.030, 0.0131, 410000, 0.09, null, 0.070, 0.140, 174)] //SCI P358, pg 42 Beam 2
        public void CalculateMember2BearingResistances(double Diameter, double HoleDiameter, double TensileStressArea, double Member1Thickness,
            double Member1Ultimate, double? Member1MajorEdgeDistance, double? Member1MinorEdgeDistance, double Member2Thickness,
            double Member2Ultimate, double? Member2MajorEdgeDistance, double? Member2MinorEdgeDistance, double? MajorSpacing, double? MinorSpacing, double Result)
        {
            Bolt bolt = new Bolt();
            bolt.Diameter = Diameter;
            bolt.HoleDiameter = HoleDiameter;
            bolt.TensileStressArea = TensileStressArea;
            bolt.Member1Thickness = Member1Thickness;
            bolt.Member1UltimateStrength = Member1Ultimate;
            bolt.Member1MajorEdgeDistance = Member1MajorEdgeDistance;
            bolt.Member1MinorEdgeDistance = Member1MinorEdgeDistance;
            bolt.Member2Thickness = Member2Thickness;
            bolt.Member2UltimateStrength = Member2Ultimate;
            bolt.Member2MajorEdgeDistance = Member2MajorEdgeDistance;
            bolt.Member2MinorEdgeDistance = Member2MinorEdgeDistance;
            bolt.MajorSpacing = MajorSpacing;
            bolt.MinorSpacing = MinorSpacing;

            bolt.Run(new OutputBuilder());
            Assert.IsTrue(bolt.Calculated, "Calculation failed to complete successfully");

            // TODO: Change delta to a percentage? 1%?
            Assert.AreEqual(Result, bolt.Member2MajorBearingResistance, 1);
        }

        [Test]
        public void CheckRequired()
        {
            // TODO: Implement fully
            Assert.Pass();
        }
    }
}
