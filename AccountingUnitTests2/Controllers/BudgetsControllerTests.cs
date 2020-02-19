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
        [Test()]
        public void create_a_budget()
        {
            var budgetManager = Substitute.For<IBudgetManager>();

            var budgetsController = new BudgetsController(budgetManager);
            var viewResult = budgetsController.CreateBudget("20200301", 31m) as ViewResult;
            (viewResult.ViewBag.Status as string).Should().ContainAll("created", "succeed");

            budgetManager.Received()
                         .Save("202003", 31m);
        }
    }
}