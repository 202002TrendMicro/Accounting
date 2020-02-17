using AccountingWeb.Controllers;
using AccountingWeb.Models.Services;
using NSubstitute;
using NUnit.Framework;

namespace AccountingUnitTests1.Controllers
{
    [TestFixture()]
    public class BudgetsControllerTests
    {
        [Test()]
        public void create_a_budget_should_invoke_budgetService_save()
        {
            var budgetService = Substitute.For<IBudgetService>();

            var budgetsController = new BudgetsController(budgetService);
            budgetsController.CreateBudgets("202003", 31m);

            budgetService.Received().Save("202003", 31m);
        }
    }
}