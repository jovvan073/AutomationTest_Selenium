using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AutomationTestJovan.PageObjectModel;
using System.Threading;

namespace AutomationTestJovan
{
    public class LoginTest
    {

        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadAndEnsurePageLoaded()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var ensureandload = new MainPage(driver);
                ensureandload.NavigateTo();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")] 
        public void LoadAndEnsureApplicationForm()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var applicationLink = new CreateAccPage(driver);
                applicationLink.NavigateTo();

                applicationLink.EnsurePageLoaded();
            }
        }

        [Fact]
        [Trait("Category", "Other")]
        public void testEmptyFields() 
        {
            using(IWebDriver driver = new ChromeDriver()) 
            {
                CreateAccPage applicationFill = new CreateAccPage(driver);
                applicationFill.NavigateTo();
                applicationFill.testEmptyFields("John", "Doe", "john.doe@example.com", "Password123", "Password123");
            }
        }
        [Fact]
        [Trait("Category", "Other")]
        public void testEmptyFieldsUsingWait()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                CreateAccPage applicationFill = new CreateAccPage(driver);
                applicationFill.NavigateTo();
                applicationFill.testEmptyFieldsUsingWait("John", "Doe", "john.doe@example.com", "Password123", "Password123");
            }
        }

        [Fact]
        [Trait("Category", "Other")]
        public void createAccWithSame()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                CreateAccPage applicationFill = new CreateAccPage(driver);
                applicationFill.NavigateTo();
                applicationFill.createAccWithSame("John", "Doe", "john.doe@example.com", "Password123", "Password123");
            }
        }

        [Fact]
        [Trait("Category", "Other")]
        public void createAcc()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                CreateAccPage createAccPage = new CreateAccPage(driver);
                createAccPage.NavigateTo();
                createAccPage.createAcc("John", "Doe", "john.doe12435@gmail.com", "Password123", "Password123");
            }
        }

        [Fact]
        [Trait("Category", "Other")]
        public void logIn()
        { 
            using (IWebDriver driver = new ChromeDriver())
            {
                LoginPage loginPage = new LoginPage(driver);
                loginPage.NavigateTo();
                loginPage.loginToAcc();
            }
        }

        [Fact]
        [Trait("Category", "Other")]
        public void loginError()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                LoginPage loginPage = new LoginPage(driver);
                loginPage.NavigateTo();
                loginPage.loginError("john.doe12435@gmail.com", "Password123");
            }
        }

        [Fact]
        [Trait("Category", "Other")]
        public void menAccsesories() 
        {
            using (IWebDriver driver = new ChromeDriver ())
            {
                LoginPage loginPage = new LoginPage (driver);
                loginPage.NavigateTo();
                loginPage.loginToAcc();
                MainPage mainPage = new MainPage(driver);
                mainPage.NavigateTo();
                mainPage.seachForProduct();
            }
        }
        [Fact]
        [Trait("Category", "Other")]
        public void AddtoCartError()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                LoginPage loginPage = new LoginPage(driver);
                loginPage.NavigateTo();
                loginPage.loginToAcc();
                MainPage mainPage = new MainPage (driver);
                mainPage.NavigateTo();
                mainPage.AddToCartErrors();
            }
        }

        [Fact]
        [Trait("Category", "Other")]
        public void AddToCart()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                LoginPage loginPage = new LoginPage(driver);
                loginPage.NavigateTo();
                loginPage.loginToAcc();
                var openMainPage = new MainPage(driver);
                openMainPage.NavigateTo();
                openMainPage.AddToCart();
            }
        }

        [Fact]
        [Trait("Category", "Other")]
        public void AddToCartUsingWait()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                LoginPage loginPage = new LoginPage(driver);
                loginPage.NavigateTo();
                loginPage.loginToAcc();
                var openMainPage = new MainPage(driver);
                openMainPage.NavigateTo();
                openMainPage.AddToCartUsingWait();
            }
        }

        [Fact]
        [Trait("Category", "Other")]
        public void checkOutIfElse ()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                LoginPage loginPage = new LoginPage(driver);
                loginPage.NavigateTo();
                loginPage.loginToAcc();
                var openMainPage = new MainPage(driver);
                openMainPage.NavigateTo();
                openMainPage.checkOutIfElse();
            }
        }
        [Fact]
        [Trait("Category", "Other")]
        public void submitReview()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                LoginPage loginPage = new LoginPage(driver);
                loginPage.NavigateTo();
                loginPage.loginToAcc();
                var openMainPage = new MainPage(driver);
                openMainPage.NavigateTo();
                openMainPage.submitReview();
            }
        }
      
        [Fact]
        [Trait("Category", "Other")]
        public void hooverOver()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                LoginPage loginPage = new LoginPage(driver);
                loginPage.NavigateTo();
                loginPage.loginToAcc();
                var openMainPage = new MainPage(driver);
                openMainPage.NavigateTo();
                openMainPage.hooverElements();
            }
        }
    }
}
