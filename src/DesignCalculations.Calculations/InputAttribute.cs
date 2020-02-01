using System;

namespace Jpp.DesignCalculations.Calculations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class InputAttribute : Attribute
    {
        public string FriendlyName { get; }
        public string Description { get; }
        public string Group { get; }

        public InputAttribute(string name, string description = "", string group = "Inputs")
        {
            FriendlyName = name;
            Description = description;
            Group = group;
        }
    }
}
