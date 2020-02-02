namespace Jpp.DesignCalculations.Calculations
{
    /// <summary>
    /// Abstract class representing a single calculation
    /// </summary>
    public abstract class Calculation
    {
        /// <summary>
        /// Human readable calculation name
        /// </summary>
        public string CalculationName { get; protected set; }

        /// <summary>
        /// Human readable description
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// Human readable reference to the corresponding design code
        /// </summary>
        public string Code { get; protected set; }

        /// <summary>
        /// Boolean indicating if calculation has run
        /// </summary>
        public bool Calculated { get; set; } = false;
        
        /// <summary>
        /// Call to run calculation and set outputs
        /// </summary>
        /// <param name="context">Calculation context to be used</param>
        /// <param name="currentCombinationIndex">Current combination</param>
        public abstract void Run(CalculationContext context, int currentCombinationIndex);

        /// <summary>
        /// Call to run calculation and set outputs for all combinations
        /// </summary>
        /// <param name="context">Calculation context to be used</param>
        public void Run(CalculationContext context)
        {
            for (int i = 0; i < context.Combinations.Count; i++)
            {
                Run(context, i);
            }
        }
    }
}
