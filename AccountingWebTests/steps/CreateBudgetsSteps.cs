using System.Linq;
using AccountingWebTests.DataModels;
using AccountingWebTests.PageObjects;
using AccountingWebTests.Utilities;
using Atata;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AccountingWebTests.steps
{
    [Binding]
    [Scope(Feature = "CreateBudgets")]
    public class CreateBudgetsSteps : Steps
    {
        private static CreateBudgetsPage _createBudgetsPage;
        private CreateBudgetResultPage _createBudgetResultPage;
        private readonly TableInitialization _tableInitialization = new TableInitialization();

        [BeforeScenario]
        public static void SetUpScenario()
        {
            using (var dbContext = new AccountingEntitiesForTest())
            {
                dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [Budgets]");
            }

            _createBudgetsPage = Go.To<CreateBudgetsPage>();
        }

        [Given(@"budget for setting")]
        public void GivenBudgetForSetting(Table table)
        {
            var budget = table.CreateInstance<Budget>();
            ScenarioContext.Set(budget);
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