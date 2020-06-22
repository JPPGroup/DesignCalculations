namespace Jpp.DesignCalculations.Calculations.Design.Connections.Parts
{
    // TODO: Consider block tearing (3.10.2)
    public abstract class Plate : ContextualCalculation
    {
        public double MajorDimension { get; set; }
        public double MinorDimension { get; set; }

        public double Thickness { get; set; }
    }
}
