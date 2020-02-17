using System;
using System.Linq;
using AccountingWebTests.DataModels;
using AccountingWebTests.PageObjects;
using Atata;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AccountingWebTests
{
    [Binding]
    public class CreateBudgetsSteps : Steps
    {
        private static CreateBudgetsPage _createBudgetsPage;
        private CreateBudgetResultPage _createBudgetResultPage;

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

            using (var dbContext = new AccountingEntitiesForTest())
            {
                dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [Budgets]");
            }

            _createBudgetsPage = Go.To<CreateBudgetsPage>();
        }

        [AfterScenario]
        public static void TearDownScenario()
        {
            AtataContext.Current?.CleanUp();
        }

        [Given(@"budget for setting")]
        public void GivenBudgetForSetting(Table table)
        {
            var budget = table.CreateInstance<Budget>();
            ScenarioContext.Set(budget);
        }

        [Given(@"there are budgets")]
        public void GivenThereAreBudgets(Table table)
        {
            using (var dbContext = new AccountingEntitiesForTest())
            {
                var budgets = table.CreateSet<Budget>();
                dbContext.Budgets.AddRange(budgets);
                dbContext.SaveChanges();
            } 
        }

        [Then(@"it should be updated succeed")]
        public void ThenItShouldBeUpdatedSucceed()
        {
            _createBudgetResultPage.Status.Should.ContainAll("updated", "succeed");
        }

        [When(@"I create")]
        public void WhenICreate()
        {
            var budget = ScenarioContext.Get<Budget>();
            _createBudgetResultPage = _createBudgetsPage.Create(budget);
        }

        [Then(@"it should be created succeed")]
        public void ThenItShouldBeCreatedSuccessfully()
        {
            _createBudgetResultPage.Status.Should.ContainAll("created", "succeed");
        }

        [Then(@"there should be budgets existed")]
        public void ThenThereShouldBeBudgetsExisted(Table table)
        {
            using (var dbContext = new AccountingEntitiesForTest())
            {
                var budgets = dbContext.Budgets.ToList();
                table.CompareToSet(budgets);
            }
        }
    }
}