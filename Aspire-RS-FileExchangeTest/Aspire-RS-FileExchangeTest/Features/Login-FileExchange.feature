Feature:1- Login
	Test the Login functionality

@Login
Scenario Outline: Logging to File Exchange
         Given I go to "appurl" https://test.aspire.fft.local/app/fileexchange/home on "<Browser>"
         And I enter "Username_Id" as "<Username>"
         And I enter "Password_Id" as "<Password>"
         When I click on "LoginButton_Id"
         Then I should be able to view the RS Homepage "<ExpectedResult>"

Examples: 
| Browser | Username                     | Password     | ExpectedResult |
| Chrome  | eleyn@stberns.bristol.sch.uk | testpassword | Successful     |
