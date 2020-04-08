using System.Collections.Generic;
using Jpp.DesignCalculations.Calculations.DataTypes;

namespace Jpp.DesignCalculations.Calculations
{
    public class CalculationContext
    {
        /// <summary>
        /// Load cases
        /// </summary>
        public List<LoadCase> LoadCases { get; }

        /// <summary>
        /// Collection of combinations
        /// </summary>
        public List<Combination> Combinations { get; }

        public CalculationContext()
        {
            LoadCases = new List<LoadCase>();
            Combinations = new List<Combination>();
        }
    }
}
