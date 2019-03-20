Feature: two

@testScenario
Scenario: Show a message in upper case
	Given I have a message of "2 Hello Matt"	
	When I process message to make uppercase
	Then the result should be "2 HELLO MATT"

@testScenario
Scenario: Show a message in reverse
	Given I have a message of "2 hello all"	
	When I process message to reverse it
	Then the result should be "lla olleh 2"

@testScenario
Scenario: Show a message in reverse again
	Given I have a message of "2 hello you"	
	When I process message to reverse it
	Then the result should be "uoy olleh 2"

@testScenario
Scenario: Show a message in reverse once more for luck
	Given I have a message of "2 hello there"	
	When I process message to reverse it
	Then the result should be "ereht olleh 2"