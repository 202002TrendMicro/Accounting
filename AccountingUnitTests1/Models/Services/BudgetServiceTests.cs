using System;
using System.Collections.Generic;
using System.Linq;
using AccountingWeb.Models.Entities;
using AccountingWeb.Models.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace AccountingUnitTests1.Models.Services
{
    [TestFixture()]
    public class BudgetServiceTests
    {
        private BudgetService _budgetService;
        private IBudgetRepo _budgetRepo;

        [SetUp]
        public void SetUp()
        {
            _budgetRepo = Substitute.For<IBudgetRepo>();
            _budgetService = new BudgetService(_budgetRepo);
        }

        [Test()]
        public void query_budget_when_no_budgets()
        {
            GivenBudgets();
            TotalAmountShouldBe(0m,
                                new DateTime(2020, 3, 1),
                                new DateTime(2020, 3, 1));
        }

        [Test()]
        public void query_budget_period_inside_budget_month()
        {
            GivenBudgets(new Budget() {YearMonth = "202003", Amount = 31});

            TotalAmountShouldBe(1m,
                                new DateTime(2020, 3, 1),
                                new DateTime(2020, 3, 1));
        }

        [Test()]
        public void query_budget_period_without_overlapping_before_budget_first_day()
        {
            GivenBudgets(new Budget() {YearMonth = "202003", Amount = 31});

            TotalAmountShouldBe(0m,
                                new DateTime(2020, 2, 1),
                                new DateTime(2020, 2, 1));
        }

        [Test()]
        public void query_budget_period_without_overlapping_after_budget_last_day()
        {
            GivenBudgets(new Budget() {YearMonth = "202003", Amount = 31});

            TotalAmountShouldBe(0m,
                                new DateTime(2020, 4, 1),
                                new DateTime(2020, 4, 1));
        }

        [Test()]
        public void query_budget_period_overlapping_budget_first_day()
        {
            GivenBudgets(new Budget() {YearMonth = "202003", Amount = 31});

            TotalAmountShouldBe(1m,
                                new DateTime(2020, 2, 28),
                                new DateTime(2020, 3, 1));
        }

        [Test()]
        public void query_budget_period_overlapping_budget_last_day()
        {
            GivenBudgets(new Budget() {YearMonth = "202003", Amount = 31});

            TotalAmountShouldBe(1m,
                                new DateTime(2020, 3, 31),
                                new DateTime(2020, 5, 1));
        }

        [Test()]
        public void daily_amount_is_10()
        {
            GivenBudgets(new Budget() {YearMonth = "202003", Amount = 310});

            TotalAmountShouldBe(20m,
                                new DateTime(2020, 3, 30),
                                new DateTime(2020, 5, 1));
        }

        [Test()]
        public void query_budgets_when_multiple_budgets()
        {
            GivenBudgets(
                new Budget() {YearMonth = "202002", Amount = 29},
                new Budget() {YearMonth = "202003", Amount = 310},
                new Budget() {YearMonth = "202004", Amount = 3000}
            );

            TotalAmountShouldBe(912,
                                new DateTime(2020, 2, 28),
                                new DateTime(2020, 4, 6));
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _budgetRepo.GetAll().ReturnsForAnyArgs(budgets.ToList());
        }

        private void TotalAmountShouldBe(decimal expected, DateTime start, DateTime end)
        {
            var totalAmount = _budgetService.TotalAmount(start, end);
            totalAmount.Should().Be(expected);
        }
    }
}