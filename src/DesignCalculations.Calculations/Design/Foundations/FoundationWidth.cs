using Jpp.DesignCalculations.Calculations.Properties;
using System;

namespace Jpp.DesignCalculations.Calculations.Design.Foundations
{
    public class FoundationWidth  : FoundationDepth
    {
        [Input("FoundationWidth_GroundBearingPressure_Name", 
            "FoundationWidth_GroundBearingPressure_Description", 
            "FoundationWidth_GroundBearingPressure_Group", true)]
        public double? GroundBearingPressure { get; set; }

        [Input("FoundationWidth_AppliedLoad_Name", 
            "FoundationWidth_AppliedLoad_Description", 
            "FoundationWidth_AppliedLoad_Group", true)]
        public double? AppliedLoad { get; set; }

        [Input("FoundationWidth_WallThickness_Name", 
            "FoundationWidth_WallThickness_Description", 
            "FoundationWidth_WallThickness_Group", true)]
        public double? WallThickness { get; set; }

        [Output("FoundationWidth_RequiredWidth_Name",
            "FoundationWidth_RequiredWidth_Description",
            "FoundationWidth_RequiredWidth_Group")]
        public double? RequiredWidth { get; private set; }

        public FoundationWidth() : base()
        {
            CalculationName = Resources.FoundationWidth_CalculationName;
            Description = Resources.FoundationWidth_Description;
            Code = Resources.FoundationWidth_Code;
        }

        public override void Run()
        {
            ResetCalculation();
            VerifyInputs();

            double stepSize = 0.15d;
            double minEdgeDistance = 0.05d;

            double pressureWidth = AppliedLoad.Value / GroundBearingPressure.Value;
            double edgeWidth = WallThickness.Value + 2 * minEdgeDistance;
            double minWidth = Math.Max(pressureWidth, edgeWidth);
            
            RequiredWidth = Math.Round(Math.Ceiling(minWidth / stepSize) * stepSize, 3);

            Calculated = true;
        }
    }
}
