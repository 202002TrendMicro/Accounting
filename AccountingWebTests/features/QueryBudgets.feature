Feature: QueryBudgets
        In order to control budgets
        As a manager
        I want to query total amount of a period

Scenario: no budgets
        When I query between "20200401" and "20200401"
        Then the total amount should be 0.00