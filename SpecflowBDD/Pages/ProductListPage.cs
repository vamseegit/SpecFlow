using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowBDD.PageUtility;
using System.Collections;
using System.Text.RegularExpressions;

namespace SpecflowBDD.Pages
{
    
    class ProductListPage : PageActions
    {
        By lnkPriceLowToHigh = By.XPath("//div[contains(text(),'Low to High')]");
        By lnkRelevance = By.XPath("//div[contains(text(),'Relevance')]");
        By lblpriceElements = By.XPath("//div[@data-id]//a[@class='_2W-UZw']//div[@class='_1vC4OE']");
        By lblMemoryDetail = By.XPath("//li[@class='tVe95H'][1]");
        By lblProductNames = By.XPath("//div[@data-id]//a[@class='_2cLu-l']");

        private By GetChkBoxUsingDynamicXpath(string replaceText)
        {
            String chkDynamicXpath = "//div[text()='"+replaceText+"']/preceding-sibling::div";
            return By.XPath(chkDynamicXpath);
        }
        private By GetProductUsingDynamicXpath(string replaceText)
        {
            By lnkSelectedProduct = By.XPath("//a[@title='" + replaceText + "']");
            return lnkSelectedProduct;
        }
        internal void SortByPriceLowToHigh()
        {
            ClickElement(lnkPriceLowToHigh);
            HardWait(1);
        }
         
        internal bool IsPriceAssendingOrdered()
        {
            List<IWebElement> productPriceElementList = GetElementList(lblpriceElements);
            double tempValue = 0;
            int flag = 0;
            foreach(IWebElement element in productPriceElementList)
            {
                string elementText = Regex.Replace(element.Text,"[^0-9]", String.Empty);
                double elementInDouble = Convert.ToDouble(elementText);
                if (elementInDouble >= tempValue)
                {
                    tempValue = elementInDouble;
                    flag = 1;
                }
                else
                {
                    flag = 0;
                    break;
                }
            }
            return (flag==1)? true: false;
        }

        internal void SetFilter(string option)
        {
            By locator = GetChkBoxUsingDynamicXpath(option);
            SelectCheckBox(locator);
            HardWait(1);           
        }
        internal bool IsOptionsFiltered(string option)
        {
            List<IWebElement> productMemoryLblList = GetElementList(lblMemoryDetail);
            foreach(IWebElement element in productMemoryLblList)
            {
                if (!element.Text.Contains(option))
                    return false;
            }
            return true;
        }
        internal ProductPage OpenProduct(string productName)
        {
            By lnkDesiredProduct = GetProductUsingDynamicXpath(productName);
            ClickElement(lnkDesiredProduct);
            SwitchToActiveWindow();
            return new ProductPage();
        }
    }
}