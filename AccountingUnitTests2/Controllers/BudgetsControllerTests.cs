using System.Web.Mvc;
using AccountingWeb.Controllers;
using AccountingWeb.Models.Domain;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace AccountingUnitTests2.Controllers
{
    [TestFixture()]
    public class BudgetsControllerTests
    {
        private IBudgetManager _budgetManager;
        private BudgetsController _budgetsController;

        [SetUp]
        public void SetUp()
        {
            _budgetManager = Substitute.For<IBudgetManager>();
            _budgetsController = new BudgetsController(_budgetManager);
        }

        [Test()]
        public void create_a_budget()
        {
            var viewResult = WhenCreateBudget("202003", 31m);
            StatusShouldContains(viewResult, "created", "succeed");

            BudgetManagerShouldSave("202003", 31m);
        }

        private static void StatusShouldContains(ViewResult viewResult, params string[] status)
        {
            (viewResult.ViewBag.Status as string).Should().ContainAll(status);
        }

        private void BudgetManagerShouldSave(string yearMonth, decimal amount)
        {
            _budgetManager.Received()
                          .Save(yearMonth, amount);
        }

        private ViewResult WhenCreateBudget(string yearMonth, decimal amount)
        {
            return _budgetsController.CreateBudget(yearMonth, amount) as ViewResult;
        }
    }
}