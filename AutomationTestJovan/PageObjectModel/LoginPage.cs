using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AutomationTestJovan.PageObjectModel
{
    class LoginPage:Page
    {
        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
        }

        protected override string pageUrl => "https://magento.softwaretestingboard.com/customer/account/login/referer/aHR0cHM6Ly9tYWdlbnRvLnNvZnR3YXJldGVzdGluZ2JvYXJkLmNvbS8%2C/";
        protected override string pageTitle => "Customer Login";

        public void loginToAcc ()
        {
            string username = "john.doe12435@gmail.com";
            string password = "Password123";
            Driver.FindElement(By.Id("email")).SendKeys(username);
            Driver.FindElement(By.Id("pass")).SendKeys(password);
            IWebElement signIn = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/div[3]/div[1]/div[2]/form/fieldset/div[4]/div[1]/button/span"));
            signIn.Click();
            Assert.Equal("Home Page", Driver.Title);
        }

        public void loginError (string username, string password)
        {
            //assert that you cannot login only with password
            Driver.FindElement(By.Id("email")).Clear();
            Driver.FindElement(By.Id("pass")).SendKeys(password);
            IWebElement signIn = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/div[3]/div[1]/div[2]/form/fieldset/div[4]/div[1]/button/span"));
            signIn.Click();
            IWebElement emailError = Driver.FindElement(By.Id("email-error"));
            Assert.Equal("This is a required field.", emailError.Text);
        }
    }
}
