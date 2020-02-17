using System;
using AccountingWeb.Models.Entities;

namespace AccountingWeb.Models.Services
{
    public class BudgetService : IBudgetService
    {
        public bool Save(string yearMonth, decimal amount)
        {
            using (var dbContext = new AccountingEntities())
            {
                dbContext.Budgets.Add(new Budget() { YearMonth = yearMonth, Amount = amount });
                dbContext.SaveChanges();
            }

            return false;
        }
    }
}