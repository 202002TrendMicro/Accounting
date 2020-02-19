Feature: CreateBudgets
	In order to manage budget of my department
	As a department manager
	I want to set budget

Scenario: create a budget
	Given budget for setting
		| YearMonth | Amount |
		| 202003    | 31     |
	When create budget
	Then it should created succeed
	And there are budgets
		| YearMonth | Amount |
		| 202003    | 31     |

Scenario: update budget when budget existed
	Given budget for setting
		| YearMonth | Amount |
		| 202003    | 310    |
	And there are budgets
		| YearMonth | Amount |
		| 202003    | 31     |
	When create budget
	Then it should updated succeed
	And there are budgets
		| YearMonth | Amount |
		| 202003    | 310    |