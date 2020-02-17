using System;
using AccountingWeb.Models.Services;
using FluentAssertions;
using NUnit.Framework;

namespace AccountingUnitTests1.Models.Services
{
    [TestFixture()]
    public class BudgetServiceTests
    {
        private BudgetService _budgetService;

        [SetUp]
        public void SetUp()
        {
            _budgetService = new BudgetService();
        }

        [Test()]
        public void query_budget_when_no_budgets()
        {
            TotalAmountShouldBe(0m,
                new DateTime(2020, 3, 1),
                new DateTime(2020, 3, 1));
        }

        private void TotalAmountShouldBe(decimal expected, DateTime start, DateTime end)
        {
            var totalAmount = _budgetService.TotalAmount(start, end);
            totalAmount.Should().Be(expected);
        }
    }
}