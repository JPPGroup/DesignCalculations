﻿using System;
using Jpp.DesignCalculations.Calculations.Attributes;

namespace Jpp.DesignCalculations.Calculations.Analysis
{
    [HiddenCalculation]
    class LocalGlobalLoadConverter : ContextlessCalculation
    {
        public double Bearing { get; set; } //Clockwise roation of axis 

        public double LocalMajorShear { get; set; }
        public double LocalMinorShear { get; set; }
        public double LocalAxial { get; set; }

        public double GlobalMajorShear { get; set; }
        public double GlobalMinorShear { get; set; }
        public double GlobalAxial { get; set; }

        public override void RunBody(OutputBuilder builder)
        {
            GlobalMinorShear = 0;
            GlobalMajorShear = 0;
            GlobalAxial = 0;

            //Componenets of Major Shear
            GlobalMajorShear = LocalMajorShear;

            //Componenets of Minor Shear
            if (Bearing >= 0)
            {
                GlobalMinorShear += Math.Cos(Bearing * Math.PI / 180) * LocalMinorShear;
            }
            else
            {
                GlobalMinorShear -= Math.Cos(Bearing * Math.PI / 180) * LocalMinorShear;
            }

            GlobalAxial += -Math.Sin(Bearing * Math.PI / 180) * LocalMinorShear;

            //Componenets of Axial
            GlobalAxial += Math.Cos(Bearing * Math.PI / 180) * LocalAxial;
            GlobalMinorShear += Math.Sin(Bearing * Math.PI / 180) * LocalAxial;
        }
    }
}
