using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject2
{
    public class LoginPageElements
    {
        IWebDriver _driver;
        WebDriverWait _wait;

        public LoginPageElements(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void EnterEmail(string email)
        {
            _driver.FindElement(By.Id("txtEmail")).SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(By.Id("txtPassword")).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            _driver.FindElement(By.Id("btnLogin")).Click();
        }

        public void ClickGoogleLoginButton()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.Id("loader")));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("btnLoginGoogle")));
            _driver.FindElement(By.Id("btnLoginGoogle")).Click();
            
        }

        public bool CheckWeAreLoggedIn()
        {
            return _driver.FindElements(By.Id("header_userinfo_arrow")).Count() > 0;
        }

        public bool CheckForgotPAsswordFormIsOpened()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("welcomeText1")));

            return _driver.FindElements(By.Id("welcomeText1")).Where(e => e.Displayed).Count() > 0 &&
                _driver.FindElements(By.Id("txtEmailRecover")).Where(e => e.Displayed).Count() > 0 &&
                _driver.FindElements(By.Id("btnRecoverPassword")).Where(e => e.Displayed).Count() > 0;                
        }

        public void ClickForgotPasswordLink()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("passwordLost")));

            _driver.FindElement(By.Id("passwordLost")).Click();
        }

        public bool CheckLoginEmailErrorMessagesShown()
        {
            var errorMessageEmail = _driver.FindElements(By.Id("txtEmail_error"));

            return errorMessageEmail.Where(e => e.Displayed).Count() > 0;
        }

        public bool CheckLoginPasswordErrorMessagesShown()
        {
            var errorMessagePassw = _driver.FindElements(By.Id("txtPassword_error"));
            return errorMessagePassw.Where(e => e.Displayed).Count() > 0;
        }
    }
}
