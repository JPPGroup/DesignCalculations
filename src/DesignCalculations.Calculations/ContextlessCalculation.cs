namespace Jpp.DesignCalculations.Calculations
{
    /// <summary>
    /// Base class for calculations that do not require a context to run with
    /// </summary>
    public abstract class ContextlessCalculation : Calculation
    {
        /// <summary>
        /// Call to run calculation and set outputs
        /// </summary>
        public abstract void Run();
    }
}
