using System;
using System.Web.Mvc;
using AccountingWeb.Controllers;
using AccountingWeb.Models.Services;
using AccountingWeb.ViewModels;
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
            _budgetService.Received().Save("202003", 31m, Arg.Any<Action<bool>>());
        }

        [Test]
        public void create_a_budget_succeed()
        {
            _budgetService.Save("202003", 31m, Arg.InvokeDelegate<Action<bool>>(false));
            var viewResult = WhenCreateBudget("202003", 31m) as ViewResult;
            StatusShouldContainAll(viewResult, "created", "succeed");
        }

        [Test]
        public void update_the_budget_when_budget_existed()
        {
            _budgetService.Save("202003", 31m, Arg.InvokeDelegate<Action<bool>>(true));
            var viewResult = WhenCreateBudget("202003", 31m) as ViewResult;
            StatusShouldContainAll(viewResult, "updated", "succeed");
        }

        [Test]
        public void query_budget()
        {
            GivenTotalAmount(1m);

            var viewResult = WhenQueryBudget("20200301", "20200301");

            (viewResult.Model as QueryBudgetViewModel).Amount.Should().Be(1m);
        }

        private static void StatusShouldContainAll(ViewResult viewResult, params string[] contents)
        {
            (viewResult.ViewBag.Status as string).Should().ContainAll(contents);
        }

        private void GivenTotalAmount(decimal totalAmount)
        {
            _budgetService.TotalAmount(new DateTime(2020, 3, 1), new DateTime(2020, 3, 1))
                          .ReturnsForAnyArgs(totalAmount);
        }

        private ActionResult WhenCreateBudget(string yearMonth, decimal amount)
        {
            return _budgetsController.CreateBudgets(yearMonth, amount);
        }

        private ViewResult WhenQueryBudget(string start, string end)
        {
            return _budgetsController.Query(new QueryBudgetViewModel() { Start = start, End = end }) as ViewResult;
        }
    }
}