using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AutomationTestJovan.PageObjectModel
{
    class CreateAccPage : Page
    {
        public CreateAccPage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
        }

        protected override string pageUrl => "https://magento.softwaretestingboard.com/customer/account/create/";
        protected override string pageTitle => "Create New Customer Account";

        public void createAccWithSame(string firstname, string lastname, string emailadress, string password, string confirmpassword)
        {
            //Assert that you cannot create an account with same credentials
            Driver.FindElement(By.Id("firstname")).SendKeys(firstname);
            Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            Driver.FindElement(By.Id("email_address")).SendKeys(emailadress);
            Driver.FindElement(By.Id("password")).SendKeys(password);
            Driver.FindElement(By.Id("password-confirmation")).SendKeys(confirmpassword);
            Thread.Sleep(3000);
            IWebElement button = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/form/div/div[1]/button/span"));
            button.Click();
            Thread.Sleep(3000);
            IWebElement messageElement = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[2]/div[2]/div/div/div"));
            Assert.NotNull(messageElement);
        }
        public void testEmptyFields (string firstname, string lastname, string emailadress, string password, string confirmpassword) 
        {
            Driver.FindElement(By.Id("firstname")).Clear();
            Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            Driver.FindElement(By.Id("email_address")).SendKeys(emailadress);
            Driver.FindElement(By.Id("password")).SendKeys(password);
            Driver.FindElement(By.Id("password-confirmation")).SendKeys(confirmpassword);
            Thread.Sleep(3000);
            IWebElement button = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/form/div/div[1]/button/span"));
            button.Click();
            IWebElement firstNameError = Driver.FindElement(By.Id("firstname-error"));
            Assert.NotNull(firstNameError);

            // Test leaving out lastname
            Driver.FindElement(By.Id("firstname")).SendKeys(firstname);
            Driver.FindElement(By.Id("lastname")).Clear();
            Thread.Sleep(3000);
            button.Click();
            IWebElement lastNameError = Driver.FindElement(By.Id("lastname-error"));
            Assert.NotNull(lastNameError);

            //leaving out email
            Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            Driver.FindElement(By.Id("email_address")).Clear();
            Thread.Sleep(3000);
            button.Click();
            IWebElement emailError = Driver.FindElement(By.Id("email_address-error"));
            Assert.NotNull(emailError);

            //leaving out password and confirm password
            Driver.FindElement(By.Id("email_address")).SendKeys(emailadress);
            Driver.FindElement(By.Id("password")).Clear();
            Thread.Sleep(3000);
            button.Click();
            IWebElement passError = Driver.FindElement(By.Id("password-error"));
            Assert.NotNull(passError);

            Driver.FindElement(By.Id("password")).SendKeys(password);
            Driver.FindElement(By.Id("password-confirmation")).Clear();
            Thread.Sleep(3000);
            button.Click();
            IWebElement confpassError = Driver.FindElement(By.Id("password-confirmation-error"));
            Assert.NotNull(confpassError);
        }

        public void testEmptyFieldsUsingWait(string firstname, string lastname, string emailadress, string password, string confirmpassword)
        {
            Driver.FindElement(By.Id("firstname")).Clear();
            Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            Driver.FindElement(By.Id("email_address")).SendKeys(emailadress);
            Driver.FindElement(By.Id("password")).SendKeys(password);
            Driver.FindElement(By.Id("password-confirmation")).SendKeys(confirmpassword);
            
            //wait until button is displayed
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/form/div/div[1]/button/span")).Displayed);
           
            IWebElement button = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/form/div/div[1]/button/span"));
            button.Click();
            IWebElement firstNameError = Driver.FindElement(By.Id("firstname-error"));
            Assert.NotNull(firstNameError);

            // Test leaving out lastname
            Driver.FindElement(By.Id("firstname")).SendKeys(firstname);
            Driver.FindElement(By.Id("lastname")).Clear();

            //wait
            wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/form/div/div[1]/button/span")).Displayed);
            
            button.Click();
            IWebElement lastNameError = Driver.FindElement(By.Id("lastname-error"));
            Assert.NotNull(lastNameError);

            //leaving out email
            Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            Driver.FindElement(By.Id("email_address")).Clear();

            // wait
            wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/form/div/div[1]/button/span")).Displayed);
            button.Click();
            IWebElement emailError = Driver.FindElement(By.Id("email_address-error"));
            Assert.NotNull(emailError);

            //leaving out password and confirm password
            Driver.FindElement(By.Id("email_address")).SendKeys(emailadress);
            Driver.FindElement(By.Id("password")).Clear();
            
            //wait
            wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/form/div/div[1]/button/span")).Displayed);
            
            button.Click();
            IWebElement passError = Driver.FindElement(By.Id("password-error"));
            Assert.NotNull(passError);

            Driver.FindElement(By.Id("password")).SendKeys(password);
            Driver.FindElement(By.Id("password-confirmation")).Clear();
            
            //wait
            wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/form/div/div[1]/button/span")).Displayed);

            button.Click();
            IWebElement confpassError = Driver.FindElement(By.Id("password-confirmation-error"));
            Assert.NotNull(confpassError);
        }
        public void createAcc(string firstname, string lastname, string emailadress, string password, string confirmpassword)
        {

            Driver.FindElement(By.Id("firstname")).SendKeys(firstname);
            Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            Driver.FindElement(By.Id("email_address")).SendKeys(emailadress);
            Driver.FindElement(By.Id("password")).SendKeys(password);
            Thread.Sleep(3000);
            Driver.FindElement(By.Id("password-confirmation")).SendKeys(confirmpassword);
            Thread.Sleep(3000);
            IWebElement button = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/form/div/div[1]/button/span"));
            button.Click();
            Thread.Sleep(3000);
            IWebElement messageElement = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[1]/div[2]/div/div/div"));
            Assert.NotNull(messageElement);
          /*  string actualMessage = messageElement.Text;
            string expectedMessage = "Thank you for registering with Main Website Store.";
            Assert.Equal(expectedMessage, actualMessage); */
        }
    }
}
