Feature: two

@testScenario
Scenario: Show a message in upper case
	Given I have a message of "Hello Matt"	
	When I process message to make uppercase
	Then the result should be "HELLO MATT"

@testScenario
Scenario: Show a message in reverse
	Given I have a message of "hello all"	
	When I process message to reverse it
	Then the result should be "lla olleh"

@testScenario
Scenario: Show a message in reverse again
	Given I have a message of "hello you"	
	When I process message to reverse it
	Then the result should be "uoy olleh"

@testScenario
Scenario: Show a message in reverse once more for luck
	Given I have a message of "hello there"	
	When I process message to reverse it
	Then the result should be "ereht olleh"