using System;
using System.Linq;
using AccountingWeb.Models.Entities;

namespace AccountingWeb.Models.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepo _budgetRepo;

        public BudgetService(IBudgetRepo budgetRepo)
        {
            _budgetRepo = budgetRepo;
        }

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
                    dbContext.Budgets.Add(new Budget() {YearMonth = yearMonth, Amount = amount});
                }

                dbContext.SaveChanges();
                return isBudgetExisted;
            }
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            var budgets = _budgetRepo.GetAll();
            if (!budgets.Any()) return 0;

            var budget = budgets.First();
            if (start > budget.LastDay || end < budget.FirstDay)
            {
                return 0;
            }

            return (end - start).Days + 1;

        }
    }
}