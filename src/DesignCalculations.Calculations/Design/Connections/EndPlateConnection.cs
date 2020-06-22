using System;
using System.Collections.Generic;
using Jpp.DesignCalculations.Calculations.DataTypes;
using Jpp.DesignCalculations.Calculations.DataTypes.Connections;
using Jpp.DesignCalculations.Calculations.Design.Connections.Parts;

namespace Jpp.DesignCalculations.Calculations.Design.Connections
{
    // TODO: Verify incoming resistance at notch
    class EndPlateConnection : SteelConnection
    {
        public Plate IncomingEndPlate { get; set; }
        public List<BoltRow> BoltRows { get; private set; }

        public EndPlateConnection() : base()
        {
            BoltRows = new List<BoltRow>();
        }

        public override void ContextualRunInit(CalculationContext context)
        {
            
            base.ContextualRunInit(context);
        }

        public override void RunCombination(int combinationIndex, Combination combination, CalculationContext context)
        {
            base.RunCombination(combinationIndex, combination, context);
            ShearChecks(combinationIndex, combination);
        }

        /// <summary>
        /// Verify detailing requirements against Check 1 of SCI P358
        /// </summary>
        /// <returns></returns>
        public override bool CheckDetailRequirements()
        {
            //Verify plate dimensions
            if (IncomingCrossSection.Height * 0.6 > IncomingEndPlate.MajorDimension)
            {
                return false;
            }

            if (IncomingEndPlate.Thickness < 10 || IncomingEndPlate.Thickness > 12)
            {
                return false;
            }

            // TODO: Add bolt checks

            return true;
        }

        

        public override void CheckTying()
        {
            double tensionResistance = 0;
            foreach (BoltRow boltRow in BoltRows)
            {
                tensionResistance += boltRow.TensionResistance;
            }

            TyingUsage = TyingForce / tensionResistance;
        }

        private void ShearChecks(int combinationIndex, Combination combination)
        {
            double resultantShear = Math.Sqrt(Math.Pow(MajorShearForce[combinationIndex], 2) +
                                              Math.Pow(MinorShearForce[combinationIndex], 2));

            /*double shearUsage = resultantShear / BoltGroup.ShearResistance;
            double majorBearingUsage = Math.Max(MajorShearForce[combinationIndex] / BoltGroup.Member1MajorBearingResistance, MajorShearForce[combinationIndex] / BoltGroup.Member2MajorBearingResistance);
            double minorBearingUsage = Math.Max(MinorShearForce[combinationIndex] / BoltGroup.Member1MinorBearingResistance, MinorShearForce[combinationIndex] / BoltGroup.Member2MinorBearingResistance);
            
            
            MajorShearUsage[combinationIndex] = Math.Min(majorBearingUsage, MajorShearForce[combinationIndex] / BoltGroup.ShearResistance);
            MinorShearUsage[combinationIndex] = Math.Min(majorBearingUsage, MajorShearForce[combinationIndex] / BoltGroup.ShearResistance);

            OverallShearUsage[combinationIndex] = new double[]
            {
                shearUsage,
                minorBearingUsage,
                minorBearingUsage
            }.Max();*/
        }
    }
}
