namespace Jpp.DesignCalculations.Calculations
{
    /// <summary>
    /// Base class for calculations requiring a context to run
    /// </summary>
    public abstract class ContextualCalculation : Calculation
    {
        /// <summary>
        /// Call to run calculation and set outputs
        /// </summary>
        public abstract void Run(CalculationContext context);
    }
}
