﻿using System;
using Jpp.DesignCalculations.Calculations.Properties;

namespace Jpp.DesignCalculations.Calculations.Attributes
{
    
    public class OutputAttribute : PropertyAttribute
    {
        public string FriendlyName { get;}
        public string Description { get; }
        public string Group { get; }
        public UnitTypes Units { get; }

        public OutputAttribute(string name, string description, string group, UnitTypes units = UnitTypes.Undefined) :
            base(name, description, group, units)
        {

        }

        public OutputAttribute(string name, UnitTypes units = UnitTypes.Undefined) : base(name, "", "Outputs", units)
        {
        }
    }
}
