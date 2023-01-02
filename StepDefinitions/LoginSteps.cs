using FluentAssertions;
using HudlLoginTest.PageObject;
using TechTalk.SpecFlow;

namespace HudlLoginTest.ScenarioSteps
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage _loginPage;

        public LoginSteps(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        [Given(@"I have navigated to the Hudl website")]
        public void GivenIHaveNavigatedToTheHudlWebsite()
        {
            _loginPage.goToPage();
        }

        [When(@"I login to Hudl as user (.*) with password (.*)")]
        [Given(@"I have logged into Hudl as user (.*) with password (.*)")]
        public void GivenILoginToHudlAsUserWithPassword(string name, string password)
        {
            _loginPage.Username.SendKeys(name);
            _loginPage.Password.SendKeys(password);
            _loginPage.Login.Click();

        }

        [When(@"I select (.*) option from the drop down menu")]
        public void WhenISelectYourProfileFromTheDropDown(string value)
        {
            _loginPage.SelectFromUserMenu(value);
        }

        [When(@"I update the First Name to '(.*)'")]
        public void WhenIUpdateTheUsernameTo(string field)
        {
            _loginPage.FirstName.Clear();
            _loginPage.FirstName.SendKeys(field);

        }

        [When(@"I save the changes")]
        public void WhenISaveTheChanges()
        {
            _loginPage.SaveChanges.Click();
        }

        [Then(@"confirmation message '(.*)' is displayed")]
        public void ThenConfirmationMessageIsDisplayed(string message)
        {
            _loginPage.ConfirmationMessage.Text.Equals(message);
        }

        [Then(@"error message '(.*)' is displayed")]
        public void ThenErrorMessageIsDisplayed(string error)
        {
            _loginPage.LoginError.Text.Equals(error);
        }

        [Then(@"the email address in the user menu is '(.*)'")]
        public void ThenMyEmailAddressInTheUserMenuIs(string expected)
        {
            _loginPage.EmailAddress.Should().Be(expected, $"email address of the logged in user is '{expected}'");
        }


        [Then(@"I am able to navigate back to Login page")]
        public void ThenIAmAbleToNavigateBackToLoginPage()
        {
            _loginPage.BackToLogin.Click();
            _loginPage.LoginArea.Should().NotBeNull();

        }

    }

}
