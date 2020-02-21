using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountingWeb.Models.Domain;
using AccountingWeb.ViewModels;

namespace AccountingWeb.Controllers
{
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
            var isUpdated = _budgetManager.Save(yearMonth, amount);

            if (isUpdated)
            {
                ViewBag.Status = "budget updated succeed";
            }
            else
            {
                ViewBag.Status = "budget created succeed";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Query()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Query(QueryBudgetViewModel queryBudgetViewModel)
        {
            return View(queryBudgetViewModel);
        } 
    }
}
