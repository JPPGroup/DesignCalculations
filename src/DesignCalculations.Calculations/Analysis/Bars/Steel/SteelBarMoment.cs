﻿using System;

namespace Jpp.DesignCalculations.Calculations.Analysis.Bars.Steel
{
    public class SteelBarMoment : AbstractBarMoment
    {
        public int SectionClassification { get; private set; }
        public double FactorSafety { get; set; } = 1;

        public override void Run(CalculationContext context)
        {
            MajorUsage = new double[context.Combinations.Count][];
            MinorUsage = new double[context.Combinations.Count][];

            switch (SectionClassification)
            {
                // Eq 6.13
                case 1:
                case 2:
                    MajorMomentResistance =
                        CrossSection.MajorPlasticSectionModulus * Material.YieldStrength / FactorSafety;
                    MinorMomentResistance =
                        CrossSection.MinorPlasticSectionModulus * Material.YieldStrength / FactorSafety;
                    break;

                // Eq 6.14
                case 3:
                    MajorMomentResistance =
                        CrossSection.MajorElasticSectionModulus * Material.YieldStrength / FactorSafety;
                    MinorMomentResistance =
                        CrossSection.MinorElasticSectionModulus * Material.YieldStrength / FactorSafety;
                    break;

                case 4:
                    throw new NotImplementedException();
            }

            for (int combinationIndex = 0; combinationIndex < context.Combinations.Count; combinationIndex++)
            {
                // TODO: Consider the effects of shear.
                MajorUsage[combinationIndex] = new double[context.NumberBarSegments + 1];
                MinorUsage[combinationIndex] = new double[context.NumberBarSegments + 1];

                for (int i = 0; i <= context.NumberBarSegments; i++)
                {
                    MajorUsage[combinationIndex][i] = MajorMoment[combinationIndex][i] / MajorMomentResistance;
                    MinorUsage[combinationIndex][i] = MinorMoment[combinationIndex][i] / MinorMomentResistance;
                }
            }
        }
    }
}
