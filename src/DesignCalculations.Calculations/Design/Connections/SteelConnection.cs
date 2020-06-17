using System;
using System.Collections.Generic;
using Jpp.DesignCalculations.Calculations.DataTypes;

namespace Jpp.DesignCalculations.Calculations.Design.Connections
{
    public abstract class SteelConnection : ContextualCalculation
    {
        public CrossSection SupportingCrossSection { get; set; }
        public Material SupportingMaterial { get; set; }

        public CrossSection IncomingCrossSection { get; set; }
        public Material IncomingMaterial { get; set; }
        public double AngleOffHorizontal { get; set; }
        public double Bearing { get; set; }

        public List<double> MajorShearForce { get; set; }
        public List<double> MinorShearForce { get; set; }
        public List<double> MajorMoment { get; set; }
        public List<double> MinorMoment { get; set; }
        public List<double> AxialForce { get; set; }
        public double TyingForce { get; set; }

        public List<double> MajorShearUsage { get; private set; }
        public List<double> MinorShearUsage { get; private set; }
        public List<double> OverallShearUsage { get; private set; }
        public List<double> MajorMomentUsage { get; private set; }
        public List<double> MinorMomentUsage { get; private set; }
        public List<double> TyingUsage { get; private set; }

        public override void ContextualRunInit(CalculationContext context)
        {
            MajorShearUsage = new List<double>(context.Combinations.Count);
            MinorShearUsage = new List<double>(context.Combinations.Count);
            MajorMomentUsage = new List<double>(context.Combinations.Count);
            MinorMomentUsage = new List<double>(context.Combinations.Count);
            OverallShearUsage = new List<double>(context.Combinations.Count);
            TyingUsage = new List<double>(context.Combinations.Count);

            CheckDetailRequirements();

            base.ContextualRunInit(context);
        }

        public abstract bool CheckDetailRequirements();
    }
}
