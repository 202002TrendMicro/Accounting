﻿using System;
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