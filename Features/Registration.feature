Feature: Registration

A short summary of the feature

@Registration
Scenario: Check Register with Buggy Cars Rating label is available
	Given I open the buggy application home page
	When I click Register button
	Then I validate Register with Buggy Cars Rating label


Scenario: Register new user after entering data in all fields
Given I open the buggy application home page
When I click Register button
When click on Login Field
Then clear data if available

Then click on First Name field
Then clear data in FN if available
Then click on Last Name field
Then clear data in LN if available
Then click on Password field
Then clear data in Password if available
Then click on Confirm Password field
Then clear data in CP if available
When Enter data in registration fields    
	  | login   | firstname   | lastname   | password   | confirmpassword   |
	  | <login> | <firstname> | <lastname> | <password> | <confirmpassword> |

Then I clicked Register button below the fields
And I validate the success message

Examples:
  | login     | firstname | lastname | password | confirmpassword |
  | testuser1 | dtest     | user1    | User123$ | User123$       |

  Scenario: Validate password and confirm password fields with different data
  Given I open the buggy application home page
  When I click Register button
  When Enter data in registration fields    
	  | login   | firstname   | lastname   | password   | confirmpassword   |
	  | <login> | <firstname> | <lastname> | <password> | <confirmpassword> |

And I validate the warning message
Then I click Cancel button

Examples:
  | login     | firstname | lastname | password | confirmpassword |
  | testuser | dtest     | user    | User123$ | User123$$      |

  Scenario: Validate password and confirm password fields by providing minimum character length
  Given I open the buggy application home page
  When I click Register button
  When Enter data in registration fields    
	  | login   | firstname   | lastname   | password   | confirmpassword   |
	  | <login> | <firstname> | <lastname> | <password> | <confirmpassword> |

Then I clicked Register button below the fields
#And I validate the message
Then I validate the error message 'InvalidParameter: 1 validation error(s) found. - minimum field size of 6, SignUpInput.Password.'

 Examples:
  | login     | firstname | lastname | password | confirmpassword |
  | testuser  | dtest     | user     | User     | User     |

  Scenario: Validate Register button if all text fields are empty
  Given I open the buggy application home page
  When I click Register button
  And I validate Register button

Scenario: Validate Register button if one or more fields are empty
  Given I open the buggy application home page
  When I click Register button
  When Enter data in registration fields    
	  | login   | firstname   | lastname   | password   | confirmpassword   |
	  | <login> | <firstname> | <lastname> | <password> | <confirmpassword> |

	  And I validate Register button
	  Examples:
  | login     | firstname | lastname | password | confirmpassword |
  | testuser  | dtest     |   | User     | User     |

  Scenario: Validate password and confirm password fields without matching password criteria
  Given I open the buggy application home page
  When I click Register button
  When Enter data in registration fields    
	  | login   | firstname   | lastname   | password   | confirmpassword   | 
	  | <login> | <firstname> | <lastname> | <password> | <confirmpassword> | 

Then I clicked Register button below the fields
Then I Validate password criteria errormessage
| errormessage |
|<errormessage>|

Examples:
  | login    | firstname | lastname | password     | confirmpassword | errormessage                                                                                            |
  | testuser | dtest     |   user   | user123456   | user123456      | InvalidPasswordException: Password did not conform with policy: Password must have uppercase characters |

  
    

