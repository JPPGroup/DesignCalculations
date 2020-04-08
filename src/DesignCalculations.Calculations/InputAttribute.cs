using System;
using Jpp.DesignCalculations.Calculations.Properties;

namespace Jpp.DesignCalculations.Calculations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class InputAttribute : Attribute
    {
        public string FriendlyName { get; }
        public string Description { get; }
        public string Group { get; }
        public bool Required { get;  }

        public InputAttribute(string name, string description, string group, bool required = false)
        {
            FriendlyName = Resources.ResourceManager.GetString(name);
            Description = Resources.ResourceManager.GetString(description);
            Group = Resources.ResourceManager.GetString(group);
            Required = required;
        }

        public InputAttribute(string name, bool required = false)
        {
            FriendlyName = Resources.ResourceManager.GetString(name);
            Description = "";
            Group = "Inputs";
            Required = required;
        }
    }
}
