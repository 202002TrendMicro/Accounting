using Atata;
using TechTalk.SpecFlow;

namespace AccountingWebTests.Utilities
{
    [Binding]
    public class AtataSetup
    {
        [BeforeTestRun]
        public static void SetUpTestRun()
        {
            AtataContext.GlobalConfiguration.UseChrome().
                         //WithArguments("start-maximized").
                         WithLocalDriverPath().UseBaseUrl("http://localhost:50564/").UseCulture("en-us")
                         .UseAllNUnitFeatures();
        }

        [BeforeScenario(Order = 0)]
        public static void SetUpScenario()
        {
            AtataContext.Configure().Build();
        }

        [AfterScenario]
        public static void TearDownScenario()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}