using AccountingWebTests.DataModels;
using AccountingWebTests.PageObjects;
using Atata;
using NUnit.Framework;

namespace AccountingWebTests.steps
{
    [Ignore("demo")]
    [TestFixture]
    public class CreateBudgetsTests
    {
        private CreateBudgetPage _createBudgetPage;

        [SetUp]
        public void Setup()
        {
            AtataContext.Configure()
                        .UseChrome()
                        .UseBaseUrl("http://localhost:50564/")
                        .UseCulture("en-us").UseNUnitTestName()
                        .AddNUnitTestContextLogging().LogNUnitError()
                        .UseAssertionExceptionType<NUnit.Framework.AssertionException>()
                        .UseNUnitAggregateAssertionStrategy().Build();

            using (var dbContext = new AccountingEntities())
            {
                dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [Budgets]");
            }

            _createBudgetPage = Go.To<CreateBudgetPage>();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }

        [Test]
        public void create_a_budget()
        {
            _createBudgetPage
                .Create(new Budget() {YearMonth = "202003", Amount = 31})
                .Status.Should.ContainAll("created", "succeed");
        }
    }
}