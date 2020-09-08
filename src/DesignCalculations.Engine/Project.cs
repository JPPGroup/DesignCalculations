using System;
using System.Collections.Generic;
using Jpp.Common;

namespace Jpp.DesignCalculations.Engine
{
    public class Project : CalculationContainer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Dictionary<Guid, Element> Elements { get; private set; }

        public Project()
        {
            Id = Guid.NewGuid();
            Elements = new Dictionary<Guid, Element>();
        }
    }
}
