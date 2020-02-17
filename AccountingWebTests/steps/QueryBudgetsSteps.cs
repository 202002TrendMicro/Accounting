using AccountingWebTests.DataModels;
using AccountingWebTests.PageObjects;
using Atata;
using TechTalk.SpecFlow;

namespace AccountingWebTests.steps
{
    [Binding]
    [Scope(Feature = "QueryBudgets")]
    public class QueryBudgetsSteps : Steps
    {
        private static QueryBudgetsPage _queryBudgetsPage;

        [BeforeScenario()]
        public static void SetUpScenario()
        {
            using (var dbContext = new AccountingEntitiesForTest())
            {
                dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [Budgets]");
            }

            _queryBudgetsPage = Go.To<QueryBudgetsPage>();
        }

        [When(@"I query between ""(.*)"" and ""(.*)""")]
        public void WhenIQueryBetweenAnd(string start, string end)
        {
            _queryBudgetsPage.Query(start, end);
        }

        [Then(@"the total amount should be (.*)")]
        public void ThenTheTotalAmountShouldBe(string expectedAmount)
        {
            _queryBudgetsPage.Amount.Should.Equal(expectedAmount);
        }
    }
}