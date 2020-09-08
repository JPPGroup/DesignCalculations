using System;
using System.Collections.Generic;
using Jpp.DesignCalculations.Calculations;

namespace Jpp.DesignCalculations.Engine
{
    public class CalculationContainer
    {
        public IReadOnlyList<ContextlessCalculation> ContextlessCalculations
        {
            get { return _contextlessCalculations; }
        }

        private List<ContextlessCalculation> _contextlessCalculations;

        public IReadOnlyList<ContextualCalculation> ContextualCalculations
        {
            get { return _contextualCalculations; }
        }

        private List<ContextualCalculation> _contextualCalculations;

        public CalculationContainer()
        {
            _contextlessCalculations = new List<ContextlessCalculation>();
            _contextualCalculations = new List<ContextualCalculation>();
        }

        public Calculation AddCalculation(CalculationInfo info)
        {
            Calculation calc = (Calculation)Activator.CreateInstance(info.BackingCalculationType);
            if (typeof(ContextualCalculation).IsAssignableFrom(calc.GetType()))
            {
                _contextualCalculations.Add((ContextualCalculation)calc);   
            }
            else
            {
                _contextlessCalculations.Add((ContextlessCalculation)calc);
            }

            return calc;
        }
    }
}
