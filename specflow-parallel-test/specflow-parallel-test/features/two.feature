Feature: two

Scenario: Show a message in upper case
	Given I have a message of Hello
	And My name is Matt
	When I process message2
	Then the result should be HELLO MATT


Scenario: Show a message in reverse
	Given I have a message of hello all
	And My name is Matt
	When I process message2 to reverse it
	Then the result should be ttaM olleH