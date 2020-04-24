using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowBDD.PageUtility;

namespace SpecflowBDD.Pages
{
    class HomePage:PageActions
    {
        By lblName = By.XPath("(//div[@class='Y5-ZPI']/following-sibling::div)[1]");
        By txtSearchField = By.ClassName("LM6RPg");
        By btnSearchIcon = By.ClassName("vh79eN");
        By lnkMyProfile = By.XPath("//div[text()='My Profile']");


        internal string GetNameText()
        {
            return GetText(lblName);
        }
        internal ProductListPage SearchProduct(string productName)
        {
            EnterText(txtSearchField, productName);
            ClickElement(btnSearchIcon);
            return new ProductListPage();
        }
        internal MyProfilePage GoToMyProfile()
        {
            HoverElement(lblName);
            ClickElement(lnkMyProfile);
            return new MyProfilePage();
        }
    }
}
