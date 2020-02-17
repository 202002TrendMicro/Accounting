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

        [Test]
        public void query_budget()
        {
            GivenTotalAmount(1m);

            var viewResult = WhenQueryBudget("20200301", "20200301");

            (viewResult.Model as QueryBudgetViewModel).Amount.Should().Be(1m);
        }

        private ViewResult WhenQueryBudget(string start, string end)
        {
            return _budgetsController.Query(new QueryBudgetViewModel() {Start = start, End = end}) as ViewResult;
        }

        private void GivenTotalAmount(decimal totalAmount)
        {
            _budgetService.TotalAmount(new DateTime(2020, 3, 1), new DateTime(2020, 3, 1))
                          .ReturnsForAnyArgs(totalAmount);
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