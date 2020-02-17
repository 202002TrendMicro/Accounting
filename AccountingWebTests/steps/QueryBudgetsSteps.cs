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
            _queryBudgetsPage = Go.To<QueryBudgetsPage>();
        }

        [Then(@"the total amount should be (.*)")]
        public void ThenTheTotalAmountShouldBe(string expectedAmount)
        {
            _queryBudgetsPage.Amount.Should.Equal(expectedAmount);
        }

        [When(@"I query between ""(.*)"" and ""(.*)""")]
        public void WhenIQueryBetweenAnd(string start, string end)
        {
            _queryBudgetsPage.Query(start, end);
        }
    }
}