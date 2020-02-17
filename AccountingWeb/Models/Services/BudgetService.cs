using System;
using System.Linq;
using AccountingWeb.Models.Domain;
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
            var period = new Period(start, end);
            return period.OverlappingDays(CreatePeriod(budget));
        }

        private static Period CreatePeriod(Budget budget)
        {
            return new Period(budget.FirstDay, budget.LastDay);
        }
    }
}