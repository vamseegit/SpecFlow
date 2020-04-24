using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowBDD.PageUtility;


namespace SpecflowBDD.Pages
{
    class ProductPage : PageActions
    {
        By lblProductName = By.ClassName("_35KyD6");
        By btnAddToCart = By.XPath("//button[text()='ADD TO CART']");

        internal bool VerifyProductName(string expProductName)
        {
            string actualProductName = GetText(lblProductName);
            return (actualProductName == expProductName);
        }
        internal MyCartPage AddProductToCart()
        {
            ClickElement(btnAddToCart);
            return new MyCartPage();
        }
    }
}