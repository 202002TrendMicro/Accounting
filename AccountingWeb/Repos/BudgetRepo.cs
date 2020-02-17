using System.Collections.Generic;
using System.Linq;
using AccountingWeb.Models.Entities;
using AccountingWeb.Models.Services;

namespace AccountingWeb.Repos
{
    public class BudgetRepo : IBudgetRepo
    {
        public List<Budget> GetAll()
        {
            using (var dbContext = new AccountingEntities())
            {
                return dbContext.Budgets.ToList();
            } 
        }
    }
}