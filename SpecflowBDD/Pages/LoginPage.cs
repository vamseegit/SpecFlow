using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowBDD.PageUtility;

namespace SpecflowBDD.Pages
{
    class LoginPage:PageActions
    {
        By txtUsername = By.XPath("//input[@class='_2zrpKA _1dBPDZ']");
        By txtPassword = By.XPath("//input[@class='_2zrpKA _3v41xv _1dBPDZ']");
        By btnSubmit = By.XPath("//button[@class='_2AkmmA _1LctnI _7UHT_c']");

        internal HomePage LoginToFlipkart(string username, string password)
        {
            EnterText(txtUsername, username);
            EnterText(txtPassword, password);
            ClickElement(btnSubmit);
            HardWait(1);
            return new HomePage();
        }
    }
}
