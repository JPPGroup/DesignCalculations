using System;

namespace Jpp.DesignCalculations.Calculations.Analysis.Bars.Steel
{
    public class SteelBar : AbstractBar
    {
        public int SectionClassification { get; private set; }

        public SteelBar()
        {
            Moment = new SteelBarMoment();
            Axial = new SteelBarAxial();
        }

        public override void Run(CalculationContext context)
        {
            base.Run(context);
            CombinedUsage = new double[context.Combinations.Count][];

            if (SectionClassification <= 3)
            {
                for (int combinationIndex = 0; combinationIndex < context.Combinations.Count; combinationIndex++)
                {
                    // Clause 6.2.1 (7)
                    CombinedUsage[combinationIndex] = new double[context.NumberBarSegments + 1];
                    for (int i = 0; i <= context.NumberBarSegments; i++)
                    {
                        // Eq 6.2
                        CombinedUsage[combinationIndex][i] = Axial.Usage[combinationIndex][i] + Moment.MajorUsage[combinationIndex][i] + Moment.MinorUsage[combinationIndex][i];
                    }
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
