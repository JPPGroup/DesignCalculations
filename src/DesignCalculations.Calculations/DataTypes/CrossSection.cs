using System;
using System.Collections.Generic;
using System.Text;

namespace Jpp.DesignCalculations.Calculations.DataTypes
{
    /// <summary>
    /// Class representing a structural cross section
    /// </summary>
    public class CrossSection
    {
        public double MajorPlasticSectionModulus { get; set; }
        public double MajorElasticSectionModulus { get; set; }

        public double MinorPlasticSectionModulus { get; set; }
        public double MinorElasticSectionModulus { get; set; }

        public double MajorSecondMomentOfArea { get; set; }
        public double MinorSecondMomentOfArea { get; set; }

        public double Area { get; set; }
    }
}
