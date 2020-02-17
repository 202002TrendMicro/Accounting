using Atata;
using NUnit.Framework;

namespace AccountingWebTests.CheckEnvironment
{
    [Ignore("no need")]
    [TestFixture]
    public class UiTest
    {
        //if you cannot run web test, please check if you use the Chrome version 80 browser.
        //if your version is less than 80, you may need to downgrade nuget package "Selenium.WebDriver.ChromeDriver" version to the appropriate version

        [SetUp]
        public void SetUp()
        {
            // Find information about AtataContext set-up on https://atata.io/getting-started/#set-up
            AtataContext.Configure()
                        .UseChrome()
                        //    WithArguments("start-maximized").
                        //.UseBaseUrl("http://automationpractice.com/index.php")
                        .UseCulture("en-us").UseNUnitTestName()
                        .AddNUnitTestContextLogging().LogNUnitError()
                        .UseAssertionExceptionType<NUnit.Framework.AssertionException>()
                        .UseNUnitAggregateAssertionStrategy().Build();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }

        [Test]
        public void go_to_joey_blog()
        {
            Go.ToUrl("https://dotblogs.com.tw/hatelove/1");
        }
    }
}