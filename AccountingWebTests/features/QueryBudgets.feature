Feature: QueryBudgets
	In order to control budgets
	As a manager
	I want to query total amount of a period

Scenario: no budgets
	When I query between "20200301" and "20200301"
	Then the total amount should be 0.00