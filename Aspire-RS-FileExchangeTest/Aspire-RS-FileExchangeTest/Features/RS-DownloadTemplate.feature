Feature:3- ResultService-DownloadTemplate
	This feature describes the feature and functionality of ResultService - Download Template module


@Download
Scenario Outline:2- Verify that the user can download the GCSE Template
	Given I login to Aspire as User ("<Username>","<Password>") with pemission to Manage Data with ADX status enabled
	Then I should  go to the download Template section and should able to download the  GCSE Template
	Examples: 
| Username                | Password     |
| eleyn@stberns.bristol.sch.uk | testpassword |

@Download
Scenario Outline:2- Verify that the user can download the Non-GCSE Template
	Given I login to Aspire as User ("<Username>","<Password>") with pemission to Manage Data with ADX status enabled
	Then I should  go to the download Template section and should able to download the  Non-GCSE Template
	Examples: 
| Username                | Password     |
| eleyn@stberns.bristol.sch.uk | testpassword |



@Download
Scenario Outline:3- Verify that Last download date and time will be displayed on screen
      Given I login to Aspire as User ("<Username>","<Password>") with pemission to Manage Data with ADX status enabled
      And I go to the Download Template section
	  Then I should be able to see the Last download date and time on screen if the user has done so previously  
Examples: 
| Username                | Password     |
| eleyn@stberns.bristol.sch.uk | testpassword |


@Download
Scenario Outline:4- Verify that last downloaded data and time is updating after the user download the template for GCSE
 Given I login to Aspire as User ("<Username>","<Password>") with pemission to Manage Data with ADX status enabled
 And I download the Template for GCSE
 Then After the Download I should be able to see the updated date and time in the last downloded section
 Examples: 
| Username                | Password     |
|eleyn@stberns.bristol.sch.uk | testpassword |


@Download
Scenario Outline:4- Verify that last downloaded data and time is updating after the user download the template for Non- GCSE
 Given I login to Aspire as User ("<Username>","<Password>") with pemission to Manage Data with ADX status enabled
 And I download the Template for Non-GCSE
 Then After the Download I should be able to see the updated date and time in the last downloded section
 Examples: 
| Username                | Password     |
|eleyn@stberns.bristol.sch.uk | testpassword |