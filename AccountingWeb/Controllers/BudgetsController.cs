using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountingWeb.Models.Services;
using AccountingWeb.ViewModels;

namespace AccountingWeb.Controllers
{
    public class BudgetsController : Controller
    {
        private readonly IBudgetService _budgetService;

        public BudgetsController()
        {
            _budgetService = new BudgetService();
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

        [HttpGet]
        public ActionResult Query()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Query(QueryBudgetViewModel queryBudgetViewModel)
        {
            var start = DateTime.ParseExact( queryBudgetViewModel.Start, "yyyyMMdd", null);
            var end = DateTime.ParseExact(queryBudgetViewModel.End, "yyyyMMdd", null);
            var totalAmount = _budgetService.TotalAmount(start, end);

            queryBudgetViewModel.Amount = totalAmount;
            return View(queryBudgetViewModel);
        }

        [HttpPost]
        public ActionResult CreateBudgets(string yearMonth, decimal amount)
        {
            var isUpdated = _budgetService.Save(yearMonth, amount);
            ViewBag.Status = isUpdated ? "budget updated succeed!" : "budget created succeed!";

            return View();
        }
    }
}