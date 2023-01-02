@UI
Feature: LoginToHudl
	In order to provide user access to Hudle website
	As a coach
	I want to be able to login to Hudl to access my account

Background: 
Given I have navigated to the Hudl website

Scenario: Check the user is logged in correctly
When I login to Hudl as user k.dlabalova@gmail.com with password Hudlepassword123
Then the email address in the user menu is 'k.dlabalova@gmail.com'

Scenario: Must to be able to change the account information
Given I have logged into Hudl as user k.dlabalova@gmail.com with password Hudlepassword123
When I select Your Profile option from the drop down menu
And I update the First Name to 'Chris'
And I save the changes
Then confirmation message 'Profile successfully updated' is displayed

Scenario Outline: Verify login with incorrect password or username
When I login to Hudl as user <Username> with password <Password>
Then error message 'We didn't recognize that email and/or password. Need help?' is displayed 

Examples: 
| Username              | Password         |
| test                  | 123?dga          |
| k.dlabalova@gmail.com | kfsfhv66         |
| test@email.com        | Hudlepassword123 |
|                       |                  |

Scenario: Must able to logout successfully
Given I have logged into Hudl as user k.dlabalova@gmail.com with password Hudlepassword123
When I select Log Out option from the drop down menu
Then I am able to navigate back to Login page



