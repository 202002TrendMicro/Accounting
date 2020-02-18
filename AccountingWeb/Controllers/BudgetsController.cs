using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountingWeb.Models.Services;
using AccountingWeb.Repos;
using AccountingWeb.ViewModels;

namespace AccountingWeb.Controllers
{
    public class BudgetsController : Controller
    {
        private readonly IBudgetService _budgetService;

        public BudgetsController()
        {
            _budgetService = new BudgetService(new BudgetRepo());
        }

        public BudgetsController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBudgets(string yearMonth, decimal amount)
        {
            _budgetService.Save(yearMonth, amount, SetStatus);

            return View();
        }

        private void SetStatus(bool isUpdated)
        {
            if (isUpdated)
            {
                ViewBag.Status = "budget updated succeed!";
            }
            else
            {
                ViewBag.Status = "budget created succeed!";
            }
        }

        [HttpGet]
        public ActionResult Query()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Query(QueryBudgetViewModel queryBudgetViewModel)
        {
            var start = queryBudgetViewModel.StartDate();
            var end = queryBudgetViewModel.EndDate();
            var totalAmount = _budgetService.TotalAmount(start, end);

            queryBudgetViewModel.Amount = totalAmount;
            return View(queryBudgetViewModel);
        }
    }
}