using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginFunctionality
{
    public class DriverInit
    {
        IWebDriver _driver;
        //string url removed due to security reasons
        string url = "";

        public IWebDriver GetDriver()
        {
            InitiateDriver();
            return _driver;
        }

        public void InitiateDriver()
        {

            _driver = new ChromeDriver();
            _driver.Url = url;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
