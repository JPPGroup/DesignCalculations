using System.Collections.Generic;

namespace Jpp.DesignCalculations.Calculations.DataTypes.Connections
{
    public class BoltGroup : ContextlessCalculation
    {
        // Frd
        public double ShearResistance { get; private set; }
        public double Member1BearingResistance { get; private set; }
        public double Member2BearingResistance { get; private set; }

        private List<BoltRow> _rows;

        public BoltGroup()
        {
            _rows = new List<BoltRow>();
        }

        public override void Run()
        {
            ResetCalculation();
            VerifyInputs();

            ShearResistance = 0;
            Member1BearingResistance = 0;
            Member2BearingResistance = 0;
            foreach (BoltRow boltRow in _rows)
            {
                ShearResistance += boltRow.ShearResistance;
                Member2BearingResistance += boltRow.Member2BearingResistance;
            }

            Calculated = true;
        }
    }
}
