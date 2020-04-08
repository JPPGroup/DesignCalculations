using System;
using Jpp.DesignCalculations.Calculations.Properties;

namespace Jpp.DesignCalculations.Calculations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OutputAttribute : Attribute
    {
        public string FriendlyName { get;}
        public string Description { get; }
        public string Group { get; }

        public OutputAttribute(string name, string description, string group)
        {
            FriendlyName = Resources.ResourceManager.GetString(name);
            Description = Resources.ResourceManager.GetString(description);
            Group = Resources.ResourceManager.GetString(group);
        }

        public OutputAttribute(string name)
        {
            FriendlyName = Resources.ResourceManager.GetString(name);
            Description = "";
            Group = "Outputs";
        }
    }
}
