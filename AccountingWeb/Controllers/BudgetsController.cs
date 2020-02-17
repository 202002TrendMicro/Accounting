using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountingWeb.Models.Services;

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

        [HttpPost]
        public ActionResult CreateBudgets(string yearMonth, decimal amount)
        {
            var isUpdated = _budgetService.Save(yearMonth, amount);
            ViewBag.Status = isUpdated ? "budget updated succeed!" : "budget created succeed!";

            return View();
        }
    }
}