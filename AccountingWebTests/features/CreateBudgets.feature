Feature: CreateBudgets
	In order to manage budget of department
	As a department manager
	I want to set budget amount of specific year month

@CleanBudgets
Scenario: create a budget
	Given budget for setting
		| YearMonth | Amount |
		| 202003    | 31     |
	When I create
	Then it should be created succeed
	And there should be budgets existed
		| YearMonth | Amount |
		| 202003    | 31     |

@CleanBudgets
Scenario: update the budget when budget existed
	Given budget for setting
		| YearMonth | Amount |
		| 202003    | 310    |
	And there are budgets
		| YearMonth | Amount |
		| 202003    | 31     |
	When I create
	Then it should be updated succeed
	And there should be budgets existed
		| YearMonth | Amount |
		| 202003    | 310    |