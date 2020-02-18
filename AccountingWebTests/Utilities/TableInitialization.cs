using System.Collections.Generic;
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
            var budgets = table.CreateSet<Budget>();
            InsertData(budgets);
        }

        private static void InsertData<TTable>(IEnumerable<TTable> rows) where TTable : class
        {
            using (var dbContext = new AccountingEntitiesForTest())
            {
                dbContext.Set<TTable>().AddRange(rows);
                dbContext.SaveChanges();
            }
        }
    }
}