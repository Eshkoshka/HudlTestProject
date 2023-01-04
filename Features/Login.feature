@UI
Feature: LoginToHudl
	In order to provide user access to Hudl website
	As a coach
	I want to be able to login to Hudl to access my account

Background: 
Given I have navigated to the Hudl login page

Scenario: Check the user is logged in correctly
When I login to Hudl as user k.dlabalova@gmail.com with password Hudlepassword123
Then the email address in the user menu is 'k.dlabalova@gmail.com'

Scenario: Must to be able to reset user details
When I click Need Help link
Then I am successfully redirected to Help Page
When I enter the email 'k.dlabalova@gmail.com' and confirm
Then confirmation message saying Check Your Email is displayed

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
When I select Log out from the user menu
Then the Hudl home page is displayed



