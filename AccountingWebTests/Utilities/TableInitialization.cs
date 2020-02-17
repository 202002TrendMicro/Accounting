using AccountingWebTests.DataModels;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AccountingWebTests.Utilities
{
    [Binding]
    public class TableInitialization
    {
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
    }
}