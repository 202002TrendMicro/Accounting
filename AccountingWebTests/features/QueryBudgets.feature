Feature: QueryBudgets
	In order to control budgets
	As a manager
	I want to query total amount of a period

Scenario: no budgets
	When I query between "20200301" and "20200301"
	Then the total amount should be 0.00

Scenario: query period inside budget month
	Given there are budgets
		| YearMonth | Amount |
		| 202003    | 31     |
	When I query between "20200301" and "20200301"
	Then the total amount should be 1.00

Scenario: query when period without overlapping before budget first day
	Given there are budgets
		| YearMonth | Amount |
		| 202003    | 31     |
	When I query between "20200201" and "20200201"
	Then the total amount should be 0.00