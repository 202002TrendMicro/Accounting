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
            _budgetsController.CreateBudgets("202003", 31m);
            _budgetService.Received().Save("202003", 31m);
        }

        [Test]
        public void create_a_budget_succeed()
        {
            var viewResult = _budgetsController.CreateBudgets("202003", 31m) as ViewResult;
            (viewResult.ViewBag.Status as string).Should().ContainAll("created", "succeed");
        }

        [Test]
        public void update_the_budget_when_budget_existed()
        {
            _budgetService.Save(Arg.Any<string>(), Arg.Any<decimal>())
                          .ReturnsForAnyArgs(true);

            var viewResult = _budgetsController.CreateBudgets("202003", 31m) as ViewResult;
            (viewResult.ViewBag.Status as string).Should().ContainAll("updated", "succeed");
        }
    }
}