using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Jpp.Common;

namespace Jpp.DesignCalculations.Engine
{
    public class Project : CalculationContainer
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ProjectReference { get; set; }

        public string Client { get; set; }

        public DateTime LastModified { get; private set; }

        public Dictionary<Guid, Element> Elements { get; private set; }

        public Project()
        {
            Id = Guid.NewGuid();
            Elements = new Dictionary<Guid, Element>();
        }
    }
}
