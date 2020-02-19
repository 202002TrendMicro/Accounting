using System;
using System.Linq;
using AccountingWebTests.DataModels;
using AccountingWebTests.PageObjects;
using Atata;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AccountingWebTests.steps
{
    [Binding]
    public class CreateBudgetsSteps : Steps
    {
        private CreateBudgetPage _createBudgetPage;
        private CreateBudgetResultPage _createBudgetResultPage;

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

            _createBudgetPage = Go.To<CreateBudgetPage>();
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            AtataContext.Current?.CleanUp();
        }

        [Given(@"budget for setting")]
        public void GivenBudgetForSetting(Table table)
        {
            var budget = table.CreateInstance<Budget>();
            ScenarioContext.Set(budget);
        }

        [When(@"create budget")]
        public void WhenCreateBudget()
        {
            var budget = ScenarioContext.Get<Budget>();
            _createBudgetResultPage = _createBudgetPage.Create(budget);
        }

        [Then(@"it should created succeed")]
        public void ThenItShouldCreatedSucceed()
        {
            _createBudgetResultPage
                .Status.Should.ContainAll("created", "succeed");
        }

        [Then(@"there are budgets")]
        public void ThenThereAreBudgets(Table table)
        {
            using (var dbContext = new AccountingEntities())
            {
                table.CompareToSet(dbContext.Budgets.ToList()); 
            } 
        }
    }
}