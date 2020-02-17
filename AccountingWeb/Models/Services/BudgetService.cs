using System;
using System.Collections.Generic;
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
            var period = new Period(start, end);

            return _budgetRepo.GetAll().Sum(budget => budget.OverlappingAmount(period));
        }
    }
}