using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestJovan.PageObjectModel
{
    internal class Page
    {
        protected IWebDriver Driver;
        protected virtual string pageUrl { get; }
        protected virtual string pageTitle { get; }
        
        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(pageUrl);
            EnsurePageLoaded();
        }

        public void EnsurePageLoaded(bool onlyCheckUrlStartsWithExpectedText = true)
        {
            bool urlIsCorrect;
            if (onlyCheckUrlStartsWithExpectedText)
            {
                urlIsCorrect = Driver.Url.StartsWith(pageUrl);
            }
            else
            {
                urlIsCorrect = Driver.Url == pageUrl;
            }

            bool pageHasLoaded = urlIsCorrect && (Driver.Title == pageTitle);
            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load page. Page URL = '{Driver.Url}' Page Source: \r\n {Driver.PageSource}");
            }
        }
    }
}
