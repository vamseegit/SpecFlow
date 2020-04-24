using SpecflowBDD.BaseTest;
using SpecflowBDD.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ApplicationTests.Steps
{
    [Binding]
    public class FlipkartFeatureSteps : TestBase
    {
        LoginPage loginPage;
        HomePage homePage;
        ProductListPage productListPage;

        [Given(@"I have logged into  flipkart (.*) (.*) (.*)")]
        public void GivenIHaveLoggedIntoFlipkart(string username, string password,string verifyName)
        {
            loginPage = new LoginPage();
            homePage = loginPage.LoginToFlipkart(username, password);
            Assert.AreEqual(verifyName, homePage.GetNameText());
        }
        
        [When(@"I search product (.*)")]
        public void WhenISearchProductPollutionMask(string productName)
        {
            productListPage = homePage.SearchProduct(productName);
        }
        
        [When(@"Sort Price by Low to High")]
        public void WhenSortPriceByLowToHigh()
        {
            productListPage.SortByPriceLowToHigh();
        }
        
        [Then(@"I should get the product sorted product list")]
        public void ThenIShouldGetTheProductSortedProductList()
        {
            Assert.IsTrue(productListPage.IsPriceAssendingOrdered());
        }

        [BeforeScenario]
        public void SetupTest()
        {
            InitializeTest();
        }
        [AfterScenario]
        public void Teardown()
        {
            CleanupTest();
        }
    }
}
