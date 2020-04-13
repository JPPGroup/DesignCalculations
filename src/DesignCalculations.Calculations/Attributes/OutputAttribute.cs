using System;
using Jpp.DesignCalculations.Calculations.Properties;

namespace Jpp.DesignCalculations.Calculations.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OutputAttribute : Attribute
    {
        public string FriendlyName { get;}
        public string Description { get; }
        public string Group { get; }
        public UnitTypes Units { get; }

        public OutputAttribute(string name, string description, string group, UnitTypes units = UnitTypes.Undefined)
        {
            FriendlyName = Resources.ResourceManager.GetString(name);
            Description = Resources.ResourceManager.GetString(description);
            Group = Resources.ResourceManager.GetString(group);
            Units = units;
        }

        public OutputAttribute(string name, UnitTypes units = UnitTypes.Undefined)
        {
            FriendlyName = Resources.ResourceManager.GetString(name);
            Description = "";
            Group = "Outputs";
            Units = units;
        }
    }
}
