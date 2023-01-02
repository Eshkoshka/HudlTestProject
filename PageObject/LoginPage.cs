using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace HudlLoginTest.PageObject
{
    public class LoginPage
    {

        private IWebDriver _driver;
        private string baseURL;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            baseURL = ConfigurationManager.AppSettings["BaseURL"];
        }

        public void goToPage()
        {
            _driver.Navigate().GoToUrl(baseURL + "login");
        }

        [FindsBy(How = How.ClassName, Using = "login-container")]
        public IWebElement LoginArea { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id='password']")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id='logIn']")]
        public IWebElement Login { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-qa-id='webnav-usermenu-logout']")]
        public IWebElement Logout { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[class='btn__blue login']")]
        public IWebElement BackToLogin { get; set; }

        [FindsBy(How = How.Id, Using = "first_name")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "save_basic")]
        public IWebElement SaveChanges { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='login-error-container']")]
        public IWebElement LoginError { get; set; }

        [FindsBy(How = How.ClassName, Using = "uni-toast__content")]
        public IWebElement ConfirmationMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-qa-id='webnav-usermenu-yourprofile']")]
        public IWebElement YourProfile { get; set; }

        [FindsBy(How = How.Id, Using = "current_password")]
        public IWebElement CurrentPassword { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement NewPassword { get; set; }

        [FindsBy(How = How.Id, Using = "confirm_password")]
        public IWebElement ConfirmPassword { get; set; }

        public void HoverOver(IWebElement elementToHoverOver)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(elementToHoverOver).Perform();
        }

        [FindsBy(How = How.CssSelector, Using = ".hui-globaluseritem")]
        public IWebElement UserMenu { get; set; }

        [FindsBy(How = How.ClassName, Using = "hui-globaluseritem__email")]
        public IWebElement EmailInUserMenu { get; set; }

        public string EmailAddress
        {
            get
            {
                HoverOver(UserMenu);
                return EmailInUserMenu.Text;
            }
        }

        [FindsBy(How = How.CssSelector, Using = "a.hui-globalusermenu__item>span")]
        public IList<IWebElement> UserMenuOptions;

        public void SelectFromUserMenu(string menuOption)
        {
            HoverOver(UserMenu);
            UserMenuOptions.ToList().First(option => option.Text == menuOption).Click();
        }




    }

}

