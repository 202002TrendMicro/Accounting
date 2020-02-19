using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingWeb.Controllers
{
    public class BudgetsController : Controller
    {
        // GET: Budgets
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBudget()
        {
            return View();
        }
    }
}