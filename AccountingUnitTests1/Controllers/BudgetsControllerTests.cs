using AccountingWeb.Controllers;
using AccountingWeb.Models.Services;
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
    }
}