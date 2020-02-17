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
                var budget = dbContext.Budgets.Find(yearMonth);
                var isBudgetExisted = budget != null;
                if (isBudgetExisted)
                {
                    budget.Amount = amount;
                }
                else
                {
                    dbContext.Budgets.Add(new Budget() { YearMonth = yearMonth, Amount = amount });
                }
                dbContext.SaveChanges();
                return isBudgetExisted;
            } 
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}