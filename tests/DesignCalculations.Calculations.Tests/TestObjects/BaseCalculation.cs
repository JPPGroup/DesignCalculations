using Jpp.DesignCalculations.Calculations.Attributes;

namespace Jpp.DesignCalculations.Calculations.Tests.TestObjects
{
    class BaseCalculation : ContextlessCalculation
    {
        [Input("Required Input", true)]
        public bool? RequiredInput { get; set; }

        [Output("Test Output")]
        public bool? TestOutput { get; set; }

        public override void RunBody(OutputBuilder builder)
        {
            TestOutput = true;
            Calculated = true;
        }
    }
}
