using System;
using Jpp.DesignCalculations.Calculations.Properties;

namespace Jpp.DesignCalculations.Calculations.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class InputAttribute : Attribute
    {
        public string FriendlyName { get; }
        public string Description { get; }
        public string Group { get; }
        public bool Required { get;  }
        public UnitTypes Units { get; }

        public InputAttribute(string name, string description, string group, bool required = false, UnitTypes units = UnitTypes.Undefined)
        {
            FriendlyName = Resources.ResourceManager.GetString(name);
            Description = Resources.ResourceManager.GetString(description);
            Group = Resources.ResourceManager.GetString(group);
            Required = required;
            Units = units;
        }

        public InputAttribute(string name, bool required = false, UnitTypes units = UnitTypes.Undefined)
        {
            FriendlyName = Resources.ResourceManager.GetString(name);
            Description = "";
            Group = "Inputs";
            Required = required;
            Units = units;
        }
    }
}
