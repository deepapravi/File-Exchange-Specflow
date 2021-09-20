Feature: RS-UploadTemplate
	This feature describes the feature and functionality of Result Service - Upload Template

@Upload
Scenario Outline:1- Verify that the chosen file has been displayed on the input box
Given I login to Aspire as User ("<Username>","<Password>") with pemission to Manage Data with ADX status enabled
And I click on Upload Template section and select a file
Then I should be able to see the selected file in the Choose Input box
	Examples: 
| Username                          | Password     |
| m.neta@khalsasecondaryacademy.com | testpassword |
 
 @Upload
Scenario Outline:2-  Verify that last uploaded data and time is updating after the user upload the template
Given I login to Aspire as User ("<Username>","<Password>") with pemission to Manage Data with ADX status enabled
And I click on Upload Template section and select a file and then upload
Then After the Upload I should be able to see the updated date and time in the last uploaded section
	Examples: 
| Username                          | Password     |
| m.neta@khalsasecondaryacademy.com | testpassword |
 