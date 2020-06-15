using Jpp.DesignCalculations.Calculations.Design.Connections.Parts;

namespace Jpp.DesignCalculations.Calculations.Design.Connections
{
    // TODO: Verify incoming resistance at notch
    class EndPlateConnection : SteelConnection
    {
        public Plate IncomingEndPlate { get; set; }

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
    }
}
