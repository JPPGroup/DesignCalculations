using System.Linq;

namespace Jpp.DesignCalculations.Calculations.DataTypes.Connections
{
    public class Bolt : ContextlessCalculation
    {
        public double Diameter { get; set; }
        public double HoleDiameter { get; set; }
        public double Grade { get; private set; } = 8.8d;
        public double PartialFactorResistanceBolt { get; private set; }= 1.25;

        public double Member1Thickness { get; set; }
        public double Member1UltimateStrength { get; set; }
        public double Member2Thickness { get; set; }
        public double Member2UltimateStrength { get; set; }

        public double Member1MajorEdgeDistance { get; set; }
        public double Member2MajorEdgeDistance { get; set; }
        public double Member1MinorEdgeDistance { get; set; }
        public double Member2MinorEdgeDistance { get; set; }

        public double MajorSpacing { get; set; }
        public double MinorSpacing { get; set; }

        // Fub
        // 800 for grade 8.8 only 
        public double DesignUltimateStrength { get; private set; } = 800000;
        public double TensileStressArea { get; set; }

        public double ShearResistance { get; private set; }

        public double Member1MajorBearingResistance { get; private set; }
        public double Member2MajorBearingResistance { get; private set; }

        public double Member1MinorBearingResistance { get; private set; }
        public double Member2MinorBearingResistance { get; private set; }

        public double TensionResistance { get; private set; }

        public override void Run()
        {
            ResetCalculation();
            VerifyInputs();
            
            // 0.6 for grade 8.8 and 4.6, 0.5 for class 10.9
            // 0.8 to allow for presence of tension in bolt
            ShearResistance = 0.6 * DesignUltimateStrength * TensileStressArea / PartialFactorResistanceBolt;
            Member1MajorBearingResistance = CalculateBearingResistance(Member1MajorEdgeDistance, MajorSpacing,
                Member1MinorEdgeDistance, MinorSpacing, Member1UltimateStrength, Member1Thickness);
            Member2MajorBearingResistance = CalculateBearingResistance(Member2MajorEdgeDistance, MajorSpacing,
                Member2MinorEdgeDistance, MinorSpacing, Member2UltimateStrength, Member2Thickness);
            Member1MinorBearingResistance = CalculateBearingResistance(Member1MinorEdgeDistance, MinorSpacing,
                Member1MajorEdgeDistance, MajorSpacing, Member1UltimateStrength, Member1Thickness);
            Member2MinorBearingResistance = CalculateBearingResistance(Member2MinorEdgeDistance, MinorSpacing,
                Member2MajorEdgeDistance, MajorSpacing, Member2UltimateStrength, Member2Thickness);

            //Table 3.3
            //0.9 when not countersunk, 0.63 otherwise
            TensionResistance = 0.9 * DesignUltimateStrength * TensileStressArea / PartialFactorResistanceBolt;

            Calculated = true;
        }

        private double CalculateBearingResistance(double majorEdgeDistance, double majorSpacing, double minorEdgeDistance, double minorSpacing, double memberUltimateStrength, double memberThickness)
        {
            double Alpha = new[]
            {
                majorEdgeDistance / (3 * HoleDiameter),
                majorSpacing / (3 * HoleDiameter),
                DesignUltimateStrength / Member1UltimateStrength,
                1d
            }.Min();
            double Kappa = new[]
            {
                2.8d * minorEdgeDistance / HoleDiameter - 1.7d,
                1.4 * minorSpacing / HoleDiameter - 1.7,
                2.5d
            }.Min();
            return Kappa * Alpha * memberUltimateStrength * Diameter * memberThickness / PartialFactorResistanceBolt;
        }
    }
}
