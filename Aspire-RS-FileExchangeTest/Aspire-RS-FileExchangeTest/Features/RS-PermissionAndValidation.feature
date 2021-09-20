Feature:2- Result-Service Access Permissions And Validation
	This feature describe the permission and access for  Result-Service and  ADX status check to enable the RS module

@Permission
Scenario Outline:1- Permission check for user with Manage data permission
	Given I login to Aspire as User ("<Username>","<Password>") with pemission to Manage Data with ADX status enabled
	Then I should be able to access the Result Service Module

Examples: 
| Username                | Password     |
| eleyn@stberns.bristol.sch.uk | testpassword |

@Permission
Scenario Outline:2- Permission check for user with Manage data but no setup
	Given I login to Aspire as User ("<Username>","<Password>") with pemission to Manage Data with no Setup and ADX status enabled
	Then I should be able to access the Result Service Module

Examples: 
| Username                | Password     |
| richard.dollimore@bcs.hants.sch.uk | testpassword |

@Permission
Scenario Outline:3- Permission check for user without Manage data permission
	Given I login to Aspire as User ("<Username>","<Password>") without having pemission to Manage Data and ADX status enabled
	Then I should be able to see the validation "Manage Data permissions required"


Examples: 
| Username                | Password     |
|t.rowe@khalsasecondaryacademy.com | Password1* |


@Permission
Scenario Outline:4- Permission check for user with Manage data but no ADX connection enabled
	Given I login to Aspire as User ("<Username>","<Password>") having Manage Data but no ADX status enabled
	Then I should be able to see the validation "To use this service, you must have Aspire Data Exchange set up by the date shown."

Examples: 
| Username                | Password     |
| l.osborne@aldevalley.suffolk.sch.uk | testpassword |