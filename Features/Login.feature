Feature: Login

Background:

# Use F12 To Navigate inside steps 
# Use Ctrl - to Get Back 
@login
Scenario: Validate logging in application with incorrect username and password combinations
  Given I open the buggy application home page
  When I fill in login Information
	|   login        |    password         |  
	|  <login>       |   <password>        |  
  Then I click login button
  And I Validate error message for invalid login

  Examples:
  	| login          | password                  |  
	|  johnderek     |  Specialpassword_2        |  
    |  johnderek2    |  Specialpassword_1        |  
	|  johnderek2    |  Specialpassword_2        |

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
	
	Scenario: logot the application on cliking Logout button
	Given I open the buggy application home page
	When I fill in login Information
	|   login        |    password         |  
	|  <login>       |   <password>        |  
	Then I click login button
	Then Home screen is opened
	Then  I click Logout button
	And  The buggy application home page with Login button is opened

	Examples:
  	| login          | password        |  
	|  divya         |  User123$       | 

Scenario: Validate logging in application with incorrect username and password combinations from the list
  Given I open the buggy application home page
  When I fill in login Information from the list
  Then I click login button
  And I Validate error message for invalid login