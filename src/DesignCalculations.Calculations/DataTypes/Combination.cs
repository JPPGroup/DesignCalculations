namespace Jpp.DesignCalculations.Calculations.DataTypes
{
    /// <summary>
    /// Represents a single code combination
    /// </summary>
    public class Combination
    {
        /// <summary>
        /// Type of combination respresented
        /// </summary>
        public CombinationType CombinationType { get; set; }

        /// <summary>
        /// Array of Partial Factor of Safety to be used
        /// </summary>
        public double[] LoadFactor { get; set; }
    }
}
