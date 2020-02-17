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
            return OverlappingDays(new Period(start, end), budget);
        }

        private static decimal OverlappingDays(Period period, Budget budget)
        {
            if (period.Start > budget.LastDay || period.End < budget.FirstDay)
            {
                return 0;
            }

            var overlappingStart = period.Start > budget.FirstDay ? period.Start : budget.FirstDay;
            var overlappingEnd = period.End < budget.LastDay ? period.End : budget.LastDay;
            return (overlappingEnd - overlappingStart).Days + 1;
        }
    }
}