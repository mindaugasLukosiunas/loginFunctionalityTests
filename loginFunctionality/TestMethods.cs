using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using UnitTestProject2;

namespace loginFunctionality
{
    public class TestMethods
    {
        private IWebDriver _driver;
        //username and password removed due to security reasons
        string username = "";
        string password = "";

        [SetUp]
        public void Setup()
        {
            _driver = new DriverInit().GetDriver();
        }

        [Test]
        public void TestMethod1()
        {
            //Successful login
            var loginPage = new LoginPageElements(_driver);
            loginPage.EnterEmail(username);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();
            loginPage.CheckWeAreLoggedIn().Should().BeTrue();
        }

        [Test]
        public void TestMethod2()
        {
            //Unsuccessful login with empty username and password
            var loginPage = new LoginPageElements(_driver);
            loginPage.EnterEmail("");
            loginPage.EnterPassword("");
            loginPage.ClickLoginButton();
            loginPage.CheckLoginPasswordErrorMessagesShown().Should().BeTrue();
            loginPage.CheckLoginEmailErrorMessagesShown().Should().BeTrue();
        }

        [Test]
        public void TestMethod3()
        {
            //Unsuccessful login with google login
            var loginPage = new LoginPageElements(_driver);
            loginPage.ClickGoogleLoginButton();
            loginPage.CheckWeAreLoggedIn().Should().BeFalse();
        }

        [Test]
        public void TestMethod4()
        {
            //Unsuccessful login with empty password
            var loginPage = new LoginPageElements(_driver);
            loginPage.EnterEmail(username);
            loginPage.ClickLoginButton();
            loginPage.CheckLoginPasswordErrorMessagesShown().Should().BeTrue();
            loginPage.CheckWeAreLoggedIn().Should().BeFalse();
            
        }

        [Test]
        public void TestMethod5()
        {
            //Forgot password link opens forgot password form
            var loginPage = new LoginPageElements(_driver);
            loginPage.ClickForgotPasswordLink();
            loginPage.CheckForgotPAsswordFormIsOpened().Should().BeTrue();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();            
        }
    }
}
