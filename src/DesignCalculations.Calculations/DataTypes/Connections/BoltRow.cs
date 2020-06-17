namespace Jpp.DesignCalculations.Calculations.DataTypes.Connections
{
    public class BoltRow : ContextlessCalculation
    {
        public double ShearResistance { get; private set; }
        public double Member1MajorBearingResistance { get; private set; }
        public double Member2MajorBearingResistance { get; private set; }

        public double Member1MinorBearingResistance { get; private set; }
        public double Member2MinorBearingResistance { get; private set; }

        public int NumberOfBolts { get; set; }
        private Bolt _bolt;

        public override void RunBody(OutputBuilder builder)
        {
            // TODO: Link varialbes including tension

            base.Run(builder);
            Member1MajorBearingResistance = NumberOfBolts * _bolt.Member1MajorBearingResistance;
            Member2MajorBearingResistance = NumberOfBolts * _bolt.Member2MajorBearingResistance;
            Member1MinorBearingResistance = NumberOfBolts * _bolt.Member1MinorBearingResistance;
            Member2MinorBearingResistance = NumberOfBolts * _bolt.Member2MinorBearingResistance;
            ShearResistance = NumberOfBolts * _bolt.ShearResistance;
        }
    }
}
