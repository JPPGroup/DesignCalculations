using System;
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


        public override void Run(CalculationContext context)
        {
            throw new NotImplementedException();
        }

        public abstract bool CheckDetailRequirements();
    }
}
