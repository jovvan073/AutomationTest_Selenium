using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AutomationTestJovan.PageObjectModel
{
   // [Trait("Category", "Applications")]
     class MainPage : Page
    {
        public MainPage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();

        }

        protected override string pageUrl => "https://magento.softwaretestingboard.com/";
        protected override string pageTitle => "Home Page";
        
        public void seachForProduct ()
        {
            //click on men section
            Driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div[2]/nav/ul/li[3]/a")).Click(); 
            //assert the title of the page
            Assert.Equal("Men", Driver.Title);
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[4]/div[2]/div[2]/div/ul[1]/li[1]/a")).Click();
            //assert title of section
            Assert.Equal("Hoodies & Sweatshirts - Tops - Men", Driver.Title);
            Driver.FindElement(By.Id("sorter")).Click();
           // Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div[1]/div[3]/div[4]/select")).Click();

            IWebElement sorterElement = Driver.FindElement(By.Id("sorter"));
            SelectElement sortBy = new SelectElement(sorterElement);
            sortBy.SelectByValue("price");

            IWebElement sorterElement1 = Driver.FindElement(By.Id("sorter"));
            SelectElement sortBy1 = new SelectElement(sorterElement1);
            sortBy1.SelectByValue("name");

            IWebElement sorterElement2 = Driver.FindElement(By.Id("sorter"));
            SelectElement sortBy2 = new SelectElement(sorterElement2);
            sortBy2.SelectByValue("position"); 
            
            // click on down arrow
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div[1]/div[3]/div[4]/a")).Click();
            IWebElement arrowElementDown = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div[1]/div[3]/div[4]/a"));
          
            //assert that down arrow is clicked 
            Assert.Equal("Set Ascending Direction", arrowElementDown.Text);

            // click on up arrow
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div[1]/div[3]/div[4]/a")).Click();
            IWebElement arrowElementUp = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div[1]/div[3]/div[4]/a"));
            //assert that up arrow is clicked 
            Assert.Equal("Set Descending Direction", arrowElementUp.Text);
        }

        public void AddToCartErrors()
        {
            // assert that you cannot add to cart with only color or size
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/div[3]/div[3]/div/div/ol/li[1]/div/a/span/span/img")).Click();

            Assert.Equal("Radiant Tee", Driver.Title);

            IWebElement sizeButton = Driver.FindElement(By.Id("option-label-size-143-item-166"));
            sizeButton.Click();
            Thread.Sleep(3000);

            //don't add color and assert error message
            IWebElement button = Driver.FindElement(By.Id("product-addtocart-button"));
            button.Click();

            IWebElement errorMsg = Driver.FindElement(By.Id("super_attribute[93]-error"));
            Assert.NotNull(errorMsg);
            Assert.Equal("This is a required field.", errorMsg.Text);

            //unclick size and select color
            sizeButton.Click();
            IWebElement color = Driver.FindElement(By.Id("option-label-color-93-item-50"));
            color.Click();

            //wait until button is displayed
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElement(By.Id("product-addtocart-button")).Displayed);

            button.Click();

            Assert.NotNull(errorMsg);
        }
       
        public void AddToCart()
        {
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/div[3]/div[3]/div/div/ol/li[1]/div/a/span/span/img")).Click();

            Assert.Equal("Radiant Tee", Driver.Title);

            IWebElement sizeButton = Driver.FindElement(By.Id("option-label-size-143-item-166"));
            sizeButton.Click();
            Thread.Sleep(3000);

            IWebElement color = Driver.FindElement(By.Id("option-label-color-93-item-50"));
            color.Click();
            Thread.Sleep(3000);

            //add to cart
            IWebElement button = Driver.FindElement(By.Id("product-addtocart-button"));
            button.Click();
            Thread.Sleep(3000);

            //assert that it is added 
            IWebElement itemAdded = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[1]/div[2]/div/div/div"));
            Assert.NotNull(itemAdded);
        }

        public void AddToCartUsingWait()
        {
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/div[3]/div[3]/div/div/ol/li[1]/div/a/span/span/img")).Click();

            Assert.Equal("Radiant Tee", Driver.Title);

            IWebElement sizeButton = Driver.FindElement(By.Id("option-label-size-143-item-166"));
            sizeButton.Click();

            //wait
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElement(By.Id("option-label-color-93-item-50")).Displayed);

            IWebElement color = Driver.FindElement(By.Id("option-label-color-93-item-50"));
            color.Click();

            //wait
            wait.Until(d => d.FindElement(By.Id("product-addtocart-button")).Displayed);

            //add to cart
            IWebElement button = Driver.FindElement(By.Id("product-addtocart-button"));
            button.Click();

            //wait
            wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/main/div[1]/div[2]/div/div/div")).Displayed);

            //assert that it is added 
            IWebElement itemAdded = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[1]/div[2]/div/div/div"));
            Assert.NotNull(itemAdded);
        }


        public void checkOutIfElse ()
        {
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/div[3]/div[3]/div/div/ol/li[1]/div/a/span/span/img")).Click();
            IWebElement sizeButton = Driver.FindElement(By.Id("option-label-size-143-item-166"));
            sizeButton.Click();
            Thread.Sleep(3000);

            IWebElement color = Driver.FindElement(By.Id("option-label-color-93-item-50"));
            color.Click();
            Thread.Sleep(3000);

            //add to cart
            IWebElement button = Driver.FindElement(By.Id("product-addtocart-button"));
            button.Click();
            Thread.Sleep(3000);
            Driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[1]/a")).Click();
            Thread.Sleep(3000);
            Driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[1]/div/div/div/div[2]/div[3]/div/button")).Click();
            Thread.Sleep(3000);
            Assert.Equal("Checkout", Driver.Title);

            //assert that application form exists within the given account
            IWebElement checkOutInfo = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[2]/div/div[3]/div[4]/ol/li[1]/div[2]/div[1]/div/div/div"));
            Assert.NotNull(checkOutInfo);

            //----------assert that you have to press radio button to go next - this works only if the account is reseted-----------
            if (!Driver.FindElement(By.XPath("/html/body/div[2]/main/div[2]/div/div[3]/div[4]/ol/li[2]/div/div[3]/form/div[1]/table/tbody/tr[1]/td[1]/input")).Selected)
            {
                //assert that you cannot click without radio button being selected
                Driver.FindElement(By.CssSelector("button[data-role='opc-continue']")).Click();
                IWebElement errorMsg = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[2]/div/div[3]/div[4]/ol/li[2]/div/div[3]/form/div[3]/span"));
                Assert.NotNull(errorMsg);

                //click on radio button and proceed with payment
                Driver.FindElement(By.XPath("/html/body/div[2]/main/div[2]/div/div[3]/div[4]/ol/li[2]/div/div[3]/form/div[1]/table/tbody/tr[1]/td[1]/input")).Click();
                
                IWebElement nextButton = Driver.FindElement(By.CssSelector("button[data-role='opc-continue']"));

                nextButton.Click();
            }
            else
            {
                IWebElement nextButton = Driver.FindElement(By.CssSelector("button[data-role='opc-continue']"));

                nextButton.Click();
            }
            Thread.Sleep(4000);

            //place order
            Driver.FindElement(By.XPath("/html/body/div[3]/main/div[2]/div/div[3]/div[4]/ol/li[3]/div/form/fieldset/div[1]/div/div/div[2]/div[2]/div[4]/div/button")).Click();
            Thread.Sleep(4000);
            Assert.Equal("Success Page", Driver.Title);
        }

        public void submitReview () 
        {
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[3]/div/div[3]/div[3]/div/div/ol/li[1]/div/a/span/span/img")).Click();
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[2]/div/div[4]/div/div[5]/a")).Click();
            IWebElement reviewField = Driver.FindElement(By.Id("review_field"));
            
            // add only review and assert error message after click, add summary and again assert error message for ratings
            reviewField.SendKeys("Review for product");
            Thread.Sleep(4000);
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[2]/div/div[4]/div/div[6]/div[2]/div[2]/form/div/div/button")).Click();
            IWebElement errorSubmit = Driver.FindElement(By.Id("summary_field-error"));
            Assert.NotNull(errorSubmit);

            // sometimes the review filed gets deleted so the if/else function makes the code goes forward
            if (string.IsNullOrEmpty(reviewField.GetAttribute("value")))
            {
                reviewField.SendKeys("Review for product");
            } 

            // assert that you have to give ratings in order to submit
            Driver.FindElement(By.Id("summary_field")).SendKeys("Demo summary");
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[2]/div/div[4]/div/div[6]/div[2]/div[2]/form/div/div/button")).Click();
            IWebElement errorSummary = Driver.FindElement(By.Id("ratings[4]-error"));
            Assert.NotNull(errorSummary);

            // click on star review
            IWebElement starRating = Driver.FindElement(By.Id("Rating_3_label"));

            Actions action = new Actions(Driver);
            action.MoveToElement(starRating).Click().Perform();

            // ensure that nickname field is filled
            IWebElement nicknameField = Driver.FindElement(By.Id("nickname_field"));
            if (string.IsNullOrEmpty(nicknameField.GetAttribute("value")))
            {
                nicknameField.SendKeys("John");
            }

            //click submit review
            Driver.FindElement(By.XPath("/html/body/div[2]/main/div[2]/div/div[4]/div/div[6]/div[2]/div[2]/form/div/div/button")).Click();
            Thread.Sleep(4000);

            //assert that review is submited
            IWebElement submitSuccess = Driver.FindElement(By.XPath("/html/body/div[2]/main/div[1]/div[2]/div/div")); 
            Assert.Equal("You submitted your review for moderation.", submitSuccess.Text);
         }
        
        public void hooverElements()
        {
            //hoover over men section
            Actions action = new Actions(Driver);
            action.MoveToElement(Driver.FindElement(By.Id("ui-id-5"))).Perform();
            action.MoveToElement(Driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div[2]/nav/ul/li[3]/ul/li[1]/a"))).Perform();
            action.MoveToElement(Driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div/div[2]/nav/ul/li[3]/ul/li[1]/ul/li[2]/a/span"))).Click().Perform();
            //assert the title is equal
            Assert.Equal("Hoodies & Sweatshirts - Tops - Men", Driver.Title);
        }

    }

}
