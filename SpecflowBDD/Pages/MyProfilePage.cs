using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowBDD.PageUtility;

namespace SpecflowBDD.Pages
{
    class MyProfilePage:PageActions
    {
        By lnkManageAddresses = By.XPath("//div[text()='Manage Addresses']");
        By lnkAddNewAddress = By.XPath("//div[text()='ADD A NEW ADDRESS']");
        By txtName = By.Name("name");
        By txtMobileNo = By.Name("phone");
        By txtPinCode = By.Name("pincode");
        By txtLocality = By.Name("addressLine2");
        By txtAddress = By.Name("addressLine1");
        By btnSave = By.XPath("//button[text()='Save']");
        private By GetElementUsingText(string replaceText)
        {
            String textDynamicXpath = "//*[text()='" + replaceText + "']";
            return By.XPath(textDynamicXpath);
        }

        private By GetRadioUsingDynamicXpath(string replaceText)
        {
            return By.XPath("//span[text()='"+replaceText+ "']/../preceding-sibling::div");
        }
        internal void GoToManageAddresses()
        {
            ClickElement(lnkManageAddresses);
        }
        internal void FillAndSaveNewAddress(string name, string mobileNo,string pincode, string locality, string address, string addressType) 
        {
            ClickElement(lnkAddNewAddress);
            EnterText(txtName, name);
            EnterText(txtMobileNo, mobileNo);
            EnterText(txtPinCode, pincode);
            EnterText(txtLocality, locality);
            EnterText(txtAddress, address);
            SelectRadio(GetRadioUsingDynamicXpath(addressType));
            ClickElement(btnSave);
        }
        internal bool VerifyAddressAdded(string name, string mobileNo, string pincode)
        {
           return (IsElementDisplayed(GetElementUsingText(name)) &&
                   IsElementDisplayed(GetElementUsingText(mobileNo)) &&
                   IsElementDisplayed(GetElementUsingText(pincode)));
        }
    }
}