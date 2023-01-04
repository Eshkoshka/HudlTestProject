using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;

namespace HudlLoginTest.PageObject
{
    public class LoginPage : WaitForElement
    {

        private IWebDriver _driver;
        private string baseURL;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            baseURL = ConfigurationManager.AppSettings["BaseURL"];
        }

        public void goToPage(string link)
        {
            _driver.Navigate().GoToUrl(baseURL + link);
        }

        public IWebElement HomePage => _driver.FindElement(By.CssSelector("[title = 'Home']"));

        public IWebElement LogInTitle => _driver.FindElement(By.XPath("//title['Log In']"));

        public IWebElement LoginArea => _driver.FindElement(By.ClassName("login-container"));

        public IWebElement Username => _driver.FindElement(By.XPath("//input[@data-qa-id='email-input']"));

        public IWebElement Password => _driver.FindElement(By.XPath("//input[@data-qa-id='password-input']"));

        public IWebElement Login => _driver.FindElement(By.CssSelector("[id='logIn']"));

        public IWebElement Logout => _driver.FindElement(By.CssSelector("[data-qa-id='webnav-usermenu-logout']"));

        public IWebElement BackToLogin => _driver.FindElement(By.CssSelector("[class='btn__blue login']"));

        public IWebElement FirstName => _driver.FindElement(By.Id("first_name"));

        public IWebElement SaveChanges => _driver.FindElement(By.Id("save_basic"));

        public IWebElement LoginError => _driver.FindElement(By.CssSelector("[data-qa-id='error-display']"));

        public IWebElement LoginHelp => _driver.FindElement(By.CssSelector("[data-qa-id='login-help-headline']"));

        public IWebElement NeedHelpLink => _driver.FindElement(By.CssSelector("a[data-qa-id='need-help-link']"));
       
        public IWebElement ConfirmationMessage => _driver.FindElement(By.ClassName("uni-toast__content"));

        public IWebElement ResetEmail => _driver.FindElement(By.CssSelector("[data-qa-id='password-reset-input']"));
    
        public IWebElement CurrentPassword => _driver.FindElement(By.Id("current_password"));

        public IWebElement PasswordResetButton => _driver.FindElement(By.CssSelector("[data-qa-id='password-reset-submit-btn']"));

        public IWebElement EmailConfirmation => _driver.FindElement(By.XPath("//div[contains(@class, 'styles_checkEmailContainer')]"));

        public IWebElement NewPassword => _driver.FindElement(By.Id("password"));

        public IWebElement ConfirmPassword => _driver.FindElement(By.Id("confirm_password"));

        public void HoverOver(IWebElement elementToHoverOver)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(elementToHoverOver).Perform();
        }

        public IWebElement UserMenu => _driver.FindElement(By.XPath("//div[@class='hui-globalusermenu']"));
       
        public IWebElement EmailInUserMenu => _driver.FindElement(By.XPath("//div[@class='hui-globaluseritem__email']"));

        public string EmailAddress
        {
            get
            {
                HoverOver(UserMenu);
                return EmailInUserMenu.Text;
            }
        }

        public IWebElement Profile => _driver.FindElement(By.CssSelector("[data-qa-id='webnav-usermenu-yourprofile']"));

        public IList<IWebElement> UserMenuOptions => _driver.FindElements(By.XPath("//div[@class='hui-globalusermenu__items']//div"));

        public void SelectFromUserMenu(string menuOption)
        {
            UserMenu.Click();
            UserMenuOptions.ToList().First(option => option.Text == menuOption).Click();
        }




    }

}

