Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag1
Scenario: Add two numbers1
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen


@mytag2
Scenario: Add two numbers2
	Given I have entered 100 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 170 on the screen

	@mytag2
Scenario: Add two numbers3
	Given I have entered 1000 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 1070 on the screen