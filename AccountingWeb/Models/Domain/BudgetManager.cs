using AccountingWeb.Models.DataModels;

namespace AccountingWeb.Models.Domain
{
    public class BudgetManager : IBudgetManager
    {
        public BudgetManager()
        {
        }

        public bool Save(string yearMonth, decimal amount)
        {
            using (var dbContext = new AccountingEntitiesProd())
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
    }
}