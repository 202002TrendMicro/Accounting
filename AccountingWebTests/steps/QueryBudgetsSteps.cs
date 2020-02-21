using System;
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
        private QueryBudgetPage _queryBudgetPage;

        [BeforeScenario()]
        public void BeforeScenario()
        {
            AtataContext.Configure()
                        .UseChrome()
                        .UseBaseUrl("http://localhost:50564/")
                        .UseCulture("en-us").UseNUnitTestName()
                        .AddNUnitTestContextLogging().LogNUnitError()
                        .UseAssertionExceptionType<NUnit.Framework.AssertionException>()
                        .UseNUnitAggregateAssertionStrategy().Build();

            _queryBudgetPage = Go.To<QueryBudgetPage>();
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            AtataContext.Current?.CleanUp();
        }

        [When(@"I query between ""(.*)"" and ""(.*)""")]
        public void WhenIQueryBetweenAnd(string start, string end)
        {
            _queryBudgetPage.Query(start, end);
        }

        [Then(@"the total amount should be (.*)")]
        public void ThenTheTotalAmountShouldBe(string expectedAmount)
        {
            _queryBudgetPage.TotalAmount.Should.Equal(expectedAmount);
        }
    }
}