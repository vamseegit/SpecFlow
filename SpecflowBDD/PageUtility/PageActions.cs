using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SpecflowBDD.BaseTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SpecflowBDD.PageUtility
{
    class PageActions : TestBase
    {
        IWebElement element;
        List<IWebElement> webElements;
        protected IWebDriver Driver { get; }
        protected WebDriverWait Wait { get; }

        public PageActions()
        {
            Driver = TestBase.driver;
            Wait = TestBase.wait;
        }

        protected void ClickElement(By locator)
        {
            element = Wait.Until(driver => driver.FindElement(locator));
            element.Click();
        }
        protected void EnterText(By locator, string textToEnter)
        {
            element = Wait.Until(driver => driver.FindElement(locator));
            element.SendKeys(textToEnter);
        }
        protected void SelectCheckBox(By locator)
        {
            element = Wait.Until(driver => driver.FindElement(locator));
            if (!element.Selected)
                element.Click();
        }
        protected void SelectRadio(By locator)
        {
            element = Wait.Until(driver => driver.FindElement(locator));
            if (!element.Selected)
                element.Click();
        }
        protected void HoverElement(By locator)
        {
            element = Wait.Until(driver => driver.FindElement(locator));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element).Perform();
            //HardWait(1);
        }
        protected string GetText(By locator)
        {
            element = Wait.Until(driver => driver.FindElement(locator));
            return element.Text;
        }
        protected void HardWait(int seconds)
        {
            int milliSeconds = seconds * 1000;
            Thread.Sleep(milliSeconds);
        }
        protected List<IWebElement> GetElementList(By locator)
        {
            webElements = Wait.Until(driver => driver.FindElements(locator)).ToList();
            return webElements;
        }
        protected void SwitchToActiveWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        protected bool IsElementDisplayed(By locator)
        {
            element = Wait.Until(driver => driver.FindElement(locator));
            return element.Displayed;
        }
    }
}