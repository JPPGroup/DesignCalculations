namespace Jpp.DesignCalculations.Calculations.Tests.TestObjects
{
    class BaseCalculation : Calculation
    {
        [Input("Required Input", true)]
        public bool? RequiredInput { get; set; }

        [Output("Test Output")]
        public bool? TestOutput { get; set; }

        public override void Run()
        {
            TestOutput = true;
            Calculated = true;
        }
    }
}
