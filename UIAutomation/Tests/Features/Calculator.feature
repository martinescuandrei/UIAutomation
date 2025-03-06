Feature: Calculator Home Page

@e2e
Scenario Outline: Verify sum of two numbers "<number1>" and "<number2>"
	Given the application is opened
	When I add "<number1>" to "<number2>"
	Then I verify the result is "<result>"
Examples:
	| number1 | number2 | result |
	| 12      | 40      | 52     |
	| 2       | 8       | 10     |
	| 2       | 4       | 5      |


@e2e
Scenario Outline: Verify square root of "<number1>"
	Given the application is opened
	When I navigate to "<calculatorType>"
	And I calculate the square root for "<number1>"
	Then I verify the result is "<result>"
Examples:
	| number1 | result | calculatorType |
	| 4       | 2      | Scientific     |
	| 16      | 4      | Scientific     |
	| 25      | 4      | Scientific     |


