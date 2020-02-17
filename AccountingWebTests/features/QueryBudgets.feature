Feature: QueryBudgets
	In order to control budgets
	As a manager
	I want to query total amount of a period

@CleanBudgets
Scenario: no budgets
	When I query between "20200301" and "20200301"
	Then the total amount should be 0.00

@CleanBudgets
Scenario: query period inside budget month
	Given there are budgets
		| YearMonth | Amount |
		| 202003    | 31     |
	When I query between "20200301" and "20200301"
	Then the total amount should be 1.00

@CleanBudgets
Scenario: query when period without overlapping before budget first day
	Given there are budgets
		| YearMonth | Amount |
		| 202003    | 31     |
	When I query between "20200201" and "20200201"
	Then the total amount should be 0.00

@CleanBudgets
Scenario: query when period without overlapping after budget last day
	Given there are budgets
		| YearMonth | Amount |
		| 202003    | 31     |
	When I query between "20200401" and "20200401"
	Then the total amount should be 0.00

@CleanBudgets
Scenario: query when period overlapping budget first day
	Given there are budgets
		| YearMonth | Amount |
		| 202003    | 31     |
	When I query between "20200228" and "20200301"
	Then the total amount should be 1.00

@CleanBudgets
Scenario: query when period overlapping budget last day
	Given there are budgets
		| YearMonth | Amount |
		| 202003    | 31     |
	When I query between "20200331" and "20200501"
	Then the total amount should be 1.00

@CleanBudgets
Scenario: daily amount is 10
	Given there are budgets
		| YearMonth | Amount |
		| 202003    | 310    |
	When I query between "20200330" and "20200501"
	Then the total amount should be 20.00

@CleanBudgets
Scenario: multiple budgets
	Given there are budgets
		| YearMonth | Amount |
		| 202002    | 29     |
		| 202003    | 310    |
		| 202004    | 3000   |
	When I query between "20200228" and "20200406"
	Then the total amount should be 912.00