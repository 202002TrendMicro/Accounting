using AccountingWebTests.DataModels;
using AccountingWebTests.PageObjects;
using Atata;
using TechTalk.SpecFlow;

namespace AccountingWebTests.steps
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

        [BeforeScenario]
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