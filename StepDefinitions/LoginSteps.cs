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

        [Given(@"I have navigated to the Hudl login page")]
        public void GivenIHaveNavigatedToTheHudlWebsite()
        {
            _loginPage.goToPage("login");
            _loginPage.LogInTitle.Text.Equals("Log In");
        }

        [When(@"I login to Hudl as user (.*) with password (.*)")]
        [Given(@"I have logged into Hudl as user (.*) with password (.*)")]
        [Given(@"I have tried to login into Hudl as user (.*) with password (.*)")]
        public void GivenILoginToHudlAsUserWithPassword(string name, string password)
        {
            _loginPage.Username.SendKeys(name);
            _loginPage.Password.SendKeys(password);
            _loginPage.LogInTitle.Text.Equals("Log In");
            _loginPage.Login.Click();
        }

        [When(@"I select Log out from the user menu")]
        public void WhenISelectYourProfileFromTheDropDown()
        {
            _loginPage.UserMenu.Equals(true);
            _loginPage.UserMenu.Click();
            _loginPage.Logout.Click();
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

        [When(@"I click Need Help link")]
        public void WhenIClickNeedHelpLink()
        {
            _loginPage.LogInTitle.Text.Equals("Log In");
            _loginPage.NeedHelpLink.Click();
        }

        [Then(@"confirmation message '(.*)' is displayed")]
        public void ThenConfirmationMessageIsDisplayed(string message)
        {
            _loginPage.ConfirmationMessage.Text.Equals(message);
        }

        [When(@"error message '(.*)' is displayed")]
        [Then(@"error message '(.*)' is displayed")]
        public void ThenErrorMessageIsDisplayed(string error)
        {
            _loginPage.LoginError.Text.Equals(error);
        }

        [Then(@"I am successfully redirected to Help Page")]
        public void ThenIAmAbleToResetMyPasswordViaHelpPage()
        {
            _loginPage.LoginHelp.Equals(true);
            _loginPage.ResetEmail.Equals(true);
        }

        [When(@"I enter the email '(.*)' and confirm")]
        public void WhenIEnterTheEmail(string email)
        {
            _loginPage.ResetEmail.Click();
            _loginPage.ResetEmail.SendKeys(email);
            _loginPage.PasswordResetButton.Click();
        }

        [Then(@"confirmation message saying Check Your Email is displayed")]
        public void ThenConfirmationMessageSayingCheckYourEmailIsDisplayed()
        {
            _loginPage.EmailConfirmation.Equals(true);
        }

        [Then(@"the email address in the user menu is '(.*)'")]
        public void ThenMyEmailAddressInTheUserMenuIs(string expected)
        {
            _loginPage.UserMenu.Equals(true);
            _loginPage.EmailInUserMenu.Text.Equals(expected);
        }

        [Then(@"the Hudl home page is displayed")]
        public void ThenTheHudlHomePageIsDisplayed()
        {
            _loginPage.HomePage.Equals(true);
        }
    }

}
