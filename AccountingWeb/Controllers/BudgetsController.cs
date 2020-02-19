using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountingWeb.Models.DataModels;
using AccountingWeb.Models.Domain;

namespace AccountingWeb.Controllers
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
                dbContext.Budgets.Add(new Budget() { YearMonth = yearMonth, Amount = amount });
                dbContext.SaveChanges();
            }

            return false;
        }
    }

    public class BudgetsController : Controller
    {
        private readonly IBudgetManager _budgetManager;

        public BudgetsController()
        {
            _budgetManager = new BudgetManager(); 
        }
        public BudgetsController(IBudgetManager budgetManager)
        {
            _budgetManager = budgetManager;
        }

        // GET: Budgets
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBudget(string yearMonth, decimal amount)
        {
            _budgetManager.Save(yearMonth, amount);

            return View();
        }
    }
}