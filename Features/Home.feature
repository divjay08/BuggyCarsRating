Feature: Home

A short summary of the feature

@Home
Scenario: Validate logging the application with correct username and password 
	Given I open the buggy application home page
	When I fill in login Information
	|   login        |    password         |  
	|  <login>       |   <password>        |  
	Then I click login button
	And Home screen is opened
	

	Examples:
  	| login          | password        |  
	|  divya         |  User123$       | 
