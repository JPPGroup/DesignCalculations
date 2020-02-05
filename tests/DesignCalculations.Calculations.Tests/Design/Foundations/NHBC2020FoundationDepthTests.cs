using Jpp.DesignCalculations.Calculations.Design.Foundations;
using NUnit.Framework;
using System;

namespace Jpp.DesignCalculations.Calculations.Tests.Design.Foundations
{
    [TestFixture]
    class NHBC2020FoundationDepthTests
    {
        [TestCase(100, null, null, null, null, null, null, ExpectedResult = 100)]
        [TestCase(100, null, null, null, null, null, VolumeChangePotential.High, ExpectedResult = 99)]
        [TestCase(100, null, null, null, null, null, VolumeChangePotential.Medium, ExpectedResult = 99.1)]
        [TestCase(100, null, null, null, null, null, VolumeChangePotential.Low, ExpectedResult = 99.25)]
        [TestCase(100, 99, null, null, null, null, null, ExpectedResult = 99)]
        [TestCase(100, 101, null, null, null, null, null, ExpectedResult = 100)]
        [TestCase(100, 99, null, null, null, null, VolumeChangePotential.High, ExpectedResult = 98)]
        [TestCase(100, 99, null, null, null, null, VolumeChangePotential.Medium, ExpectedResult = 98.1)]
        [TestCase(100, 99, null, null, null, null, VolumeChangePotential.Low, ExpectedResult = 98.25)]
        [TestCase(100, 101, null, null, null, null, VolumeChangePotential.High, ExpectedResult = 99)]
        [TestCase(100, 101, null, null, null, null, VolumeChangePotential.Medium, ExpectedResult = 99.1)]
        [TestCase(100, 101, null, null, null, null, VolumeChangePotential.Low, ExpectedResult = 99.25)]
        [TestCase(100, null, 2, null, null, null, null, ExpectedResult = 98)]
        [TestCase(100, null, null, 2, null, null, null, ExpectedResult = 100)]
        [TestCase(100, null, null, null, 2, null, null, ExpectedResult = 98)]
        [TestCase(105, 100, 2, null, null, null, null, ExpectedResult = 98)]
        [TestCase(105, 100, null, 2, null, null, null, ExpectedResult = 98)]
        [TestCase(105, 100, null, null, 2, null, null, ExpectedResult = 100)] // Verify this one is correct, should remove affect proposed??
        [TestCase(100, null, null, null, null, 100, null, ExpectedResult = 99.85)]
        [TestCase(100, 99, null, null, null, 99, null, ExpectedResult = 98.85)]
        public double CalculateFoundationDepth(double? existingGround, double? proposedGround, double? existingTrees, double? proposedTrees, double? removedTrees, double? topOfConcrete, VolumeChangePotential? changePotential)
        {
            NHBC2020FoundationDepth calc = new NHBC2020FoundationDepth();

            calc.ExistingGroundLevel = existingGround;
            calc.ProposedGroundLevel = proposedGround;
            calc.ExistingTreeInfluence = existingTrees;
            calc.ProposedTreeInfluence = proposedTrees;
            calc.RemovedTreeInfluence = removedTrees;
            calc.TopOfConcreteLevel = topOfConcrete;
            calc.SoilPlasticity = changePotential;
            calc.Run();

            Assert.IsTrue(calc.Calculated, "Calculation failed to complete successfully");

            return calc.FoundationDepth.Value;
        }

        [Test]
        public void ExistingGroundRequired()
        {
            NHBC2020FoundationDepth calc = new NHBC2020FoundationDepth();                       

            CalculationContext context = new CalculationContext();

            Assert.Throws(typeof(ArgumentNullException), () => calc.Run());
            Assert.IsFalse(calc.Calculated, "Calculation should not have completed");
        }
    }
}
