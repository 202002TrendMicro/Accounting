using System;
using TechTalk.SpecFlow;

namespace AccountingWebTests
{
    [Binding]
    public class CreateBudgetsSteps : Steps
    {
        [Given(@"budget for setting")]
        public void GivenBudgetForSetting(Table table)
        {
            ScenarioContext.Pending();
        }

        [When(@"I create")]
        public void WhenICreate()
        {
            ScenarioContext.Pending();
        }

        [Then(@"it should be created successfully")]
        public void ThenItShouldBeCreatedSuccessfully()
        {
            ScenarioContext.Pending();
        }

        [Then(@"there should be budgets existed")]
        public void ThenThereShouldBeBudgetsExisted(Table table)
        {
            ScenarioContext.Pending();
        }
    }
}
