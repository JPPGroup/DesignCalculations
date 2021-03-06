﻿using System;
using System.Collections.Generic;
using System.Text;
using Jpp.DesignCalculations.Calculations.Properties;

namespace Jpp.DesignCalculations.Calculations.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyAttribute : Attribute
    {
        public string FriendlyName { get; protected set; }
        public string Description { get; protected set; }
        public string Group { get; protected set; }
        public UnitTypes Units { get; protected set; }

        public PropertyAttribute(string name, string description, string group, UnitTypes units = UnitTypes.Undefined)
        {
            FriendlyName = Resources.ResourceManager.GetString(name);
            Description = Resources.ResourceManager.GetString(description);
            Group = Resources.ResourceManager.GetString(group);
            Units = units;
        }
    }
}
