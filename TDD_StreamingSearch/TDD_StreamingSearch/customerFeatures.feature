Feature: customerFeatures
	I want to know where I can stream a show or movie in my region

@findShowInMyRegion
Scenario: Find streaming sites in my region which have the show I want to watch
	Given There is a show that I want to watch
	| SHOWNAME   | USERREGION   | EMAILADDRESS   | EXCLUSIONS   | NOTIFICATION   |
	| <SHOWNAME> | <USERREGION> | <EMAILADDRESS> | <EXCLUSIONS> | <NOTIFICATION> |
	When I enter the name od the show I want to watch		
	Then A list of sites is presented to me where I can stream the show
	And my show is added to a notification list so if it leaves or is added to a service I get notified

	Examples: 

	| SHOWNAME       | USERREGION | EMAILADDRESS       | EXCLUSIONS           | NOTIFICATION |
	| The Young Ones | UK         | matt.barbier@os.uk | Disney plus, Netflix | false        |
	| Rick and Morty | UK         | mike.bruce@os.uk   | Now Tv               | true         |
