using Jpp.DesignCalculations.Calculations.DataTypes;

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
        public void Run(CalculationContext context)
        {
            RunBegin(context.Output);
            ContextualRunInit(context);

            int i = 0;
            foreach (Combination contextCombination in context.Combinations)
            {
                RunCombination(i, contextCombination, context);
                i++;
            }

            RunEnd(context.Output);
        }

        public virtual void ContextualRunInit(CalculationContext context)
        {
        }

        public abstract void RunCombination(int combinationIndex, Combination combination, CalculationContext context);
    }
}
