Feature: WorkFlow

A short summary of the feature

@Workflow
Scenario: Register a user and login with same user
	Given I open the buggy application home page
	When I click Register button
	When Enter data in registration fields    
	  | login   | firstname   | lastname   | password   | confirmpassword   |
	  | <login> | <firstname> | <lastname> | <password> | <confirmpassword> |
	Then I clicked Register button below the fields
	Then I validate registered login and password
	And I click Cancel button
	When I fill in login Information
	|   login     |    password         |  
	|  <login>    |   <password>        |  
	Then I click login button
	And Home screen is opened
	Then  I click Logout button
	And  The buggy application home page with Login button is opened

	Examples:
  | login     | firstname | lastname | password | confirmpassword |
  | testuser | dtest     | user1    | User123$ | User123$       |
