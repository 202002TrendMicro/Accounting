using System.Web.Mvc;
using AccountingWeb.Controllers;
using AccountingWeb.Models.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace AccountingUnitTests1.Controllers
{
    [TestFixture()]
    public class BudgetsControllerTests
    {
        private BudgetsController _budgetsController;
        private IBudgetService _budgetService;

        [SetUp]
        public void SetUp()
        {
            _budgetService = Substitute.For<IBudgetService>();
            _budgetsController = new BudgetsController(_budgetService);
        }

        [Test()]
        public void create_a_budget_should_invoke_budgetService_save()
        {
            WhenCreateBudget("202003", 31m);
            _budgetService.Received().Save("202003", 31m);
        }

        [Test]
        public void create_a_budget_succeed()
        {
            var viewResult = WhenCreateBudget("202003", 31m) as ViewResult;
            StatusShouldContainAll(viewResult, "created", "succeed");
        }

        [Test]
        public void update_the_budget_when_budget_existed()
        {
            GivenIsUpdate(true);

            var viewResult = WhenCreateBudget("202003", 31m) as ViewResult;
            StatusShouldContainAll(viewResult, "updated", "succeed");
        }

        private static void StatusShouldContainAll(ViewResult viewResult, params string[] contents)
        {
            (viewResult.ViewBag.Status as string).Should().ContainAll(contents);
        }

        private void GivenIsUpdate(bool isUpdated)
        {
            _budgetService.Save(Arg.Any<string>(), Arg.Any<decimal>())
                          .ReturnsForAnyArgs(isUpdated);
        }

        private ActionResult WhenCreateBudget(string yearMonth, decimal amount)
        {
            return _budgetsController.CreateBudgets(yearMonth, amount);
        }
    }
}