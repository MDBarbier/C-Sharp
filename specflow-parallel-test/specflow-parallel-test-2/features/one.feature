Feature: one

@testScenario
Scenario: Show a message in upper case
	Given I have a message of "1 Hello Matt"	
	When I process message to make uppercase
	Then the result should be "1 HELLO MATT"

@testScenario
Scenario: Show a message in reverse
	Given I have a message of "1 hello all"	
	When I process message to reverse it
	Then the result should be "lla olleh 1"

@testScenario
Scenario: Show a message in reverse again
	Given I have a message of "1 hello you"	
	When I process message to reverse it
	Then the result should be "uoy olleh 1"

@testScenario
Scenario: Show a message in reverse once more for luck
	Given I have a message of "1 hello there"	
	When I process message to reverse it
	Then the result should be "ereht olleh 1"