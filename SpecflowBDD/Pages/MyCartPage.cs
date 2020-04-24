using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowBDD.PageUtility;

namespace SpecflowBDD.Pages
{
    class MyCartPage:PageActions
    {
        By lnkProductName = By.XPath("//a[@class='_325-ji _3ROAwx']");
        By lnkSaveForLater = By.XPath("//div[text()='Save for later']");

        internal bool VerifyProductName(string expProductName)
        {
            string actualProductName = GetText(lnkProductName);
            return (actualProductName == expProductName);
        }
    }
}