using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Jpp.DesignCalculations.Calculations;

namespace DesignCalculations.Blazor
{
    public class CalculationSessionManager
    {
        public ObservableCollection<Calculation> ActiveCalculations { get; private set; }

        public CalculationSessionManager()
        {
            ActiveCalculations = new ObservableCollection<Calculation>();
        }
    }
}
