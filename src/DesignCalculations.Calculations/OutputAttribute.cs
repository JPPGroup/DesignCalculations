using System;

namespace Jpp.DesignCalculations.Calculations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OutputAttribute : Attribute
    {
        public string FriendlyName { get;}
        public string Description { get; }
        public string Group { get; }

        public OutputAttribute(string name, string description = "", string group = "Outputs")
        {
            FriendlyName = name;
            Description = description;
            Group = group;
        }
    }
}
