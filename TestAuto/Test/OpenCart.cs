using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using TestAuto.Pages;

namespace TestAuto.myTest


{
    class OpenCart
    {
        IWebDriver driver = new ChromeDriver();
        
        HelperClass helper = new HelperClass();

        [SetUp]
        public void Initialize() {         
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=account/register");
        }

        [Test]
        public void RegistrationTest()
        {
            String randomEmail = helper.RandomString(15); 

            helper.EnterText(driver, "input-firstname", "Jill", "Id");
            helper.EnterText(driver, "input-lastname", "Barquero","Id");
            helper.EnterText(driver, "input-email", randomEmail +"@a.com", "Id");
            helper.EnterText(driver, "input-telephone", "222-222", "Id");
            helper.EnterText(driver, "input-password", "Thebutterfly1", "Id");           
            helper.EnterText(driver, "input-confirm", "Thebutterfly1", "Id");
            helper.ClickActions(driver, "//div[@class='pull-right']/input[1]", "Xpath");

            helper.ClickBotton(driver, "//input[@class='btn btn-primary']", "Xpath");
            Thread.Sleep(1000);
            String AccountCreatedText = helper.GetElementText(driver, "//div[@id='common-success']/div[@class='row']/div[@id='content']/h1", "Xpath");

            Assert.AreEqual(AccountCreatedText, "Your Account Has Been Created!");

            //logout
            helper.ClickBotton(driver, "//li[@class='dropdown']/a[@class='dropdown-toggle']/span[@class='hidden-xs hidden-sm hidden-md']", "Xpath");
            helper.ClickBotton(driver, "//ul[@class='list-inline']/li[@class='dropdown open']/ul[@class='dropdown-menu dropdown-menu-right']/li[5]/a", "Xpath");
        }
        [Test]
        public void CreateOrder()
        {
            String randomEmail = helper.RandomString(15);

            helper.EnterText(driver, "input-firstname", "Jill", "Id");
            helper.EnterText(driver, "input-lastname", "Barquero", "Id");
            helper.EnterText(driver, "input-email", randomEmail + "@a.com", "Id");
            helper.EnterText(driver, "input-telephone", "222-222", "Id");
            helper.EnterText(driver, "input-password", "Thebutterfly1", "Id");
            helper.EnterText(driver, "input-confirm", "Thebutterfly1", "Id");
            helper.ClickActions(driver, "//div[@class='pull-right']/input[1]", "Xpath");
            helper.ClickBotton(driver, "//input[@class='btn btn-primary']", "Xpath");
            Thread.Sleep(1000);
            String AccountCreatedText = helper.GetElementText(driver, "//div[@id='common-success']/div[@class='row']/div[@id='content']/h1", "Xpath");

            Assert.AreEqual("Your Account Has Been Created!",AccountCreatedText);

            //Click continue button
            helper.ClickBotton(driver, "//div[@class='buttons']/div[@class='pull-right']/a[@class='btn btn-primary']", "Xpath");
  
            //search for product
            helper.EnterText(driver, "//div[@class='col-sm-5']/div[@id='search']/input[@class='form-control input-lg']", "Samsung SyncMaster 941BW", "Xpath");
            //click on search
            helper.ClickBotton(driver, "//div[@class='col-sm-5']/div[@id='search']/span[@class='input-group-btn']/button[@class='btn btn-default btn-lg']", "Xpath");
            //click on Add to cart
            helper.ClickBotton(driver, "//div[@class='product-thumb']/div[2]/div[@class='button-group']/button[1]", "Xpath");
            Thread.Sleep(1000);

            String AddedToCartText= helper.GetElementText(driver, "alert", "ClassName");
            Assert.AreEqual("Success: You have added Samsung SyncMaster 941BW to your shopping cart!\r\n×", AddedToCartText);


            //logout
            helper.ClickBotton(driver, "//li[@class='dropdown']/a[@class='dropdown-toggle']/span[@class='hidden-xs hidden-sm hidden-md']", "Xpath");
            helper.ClickBotton(driver, "//ul[@class='list-inline']/li[@class='dropdown open']/ul[@class='dropdown-menu dropdown-menu-right']/li[5]/a", "Xpath");

        }

        [Test]
        public void VerifyCurrency()
        {
            String randomEmail = helper.RandomString(15);

            helper.EnterText(driver, "input-firstname", "Jill", "Id");
            helper.EnterText(driver, "input-lastname", "Barquero", "Id");
            helper.EnterText(driver, "input-email", randomEmail + "@a.com", "Id");
            helper.EnterText(driver, "input-telephone", "222-222", "Id");
            helper.EnterText(driver, "input-password", "Thebutterfly1", "Id");
            helper.EnterText(driver, "input-confirm", "Thebutterfly1", "Id");
            helper.ClickActions(driver, "//div[@class='pull-right']/input[1]", "Xpath");
            helper.ClickBotton(driver, "//input[@class='btn btn-primary']", "Xpath");
            Thread.Sleep(1000);
            String AccountCreatedText = helper.GetElementText(driver, "//div[@id='common-success']/div[@class='row']/div[@id='content']/h1", "Xpath");

            Assert.AreEqual("Your Account Has Been Created!", AccountCreatedText);

            //Click continue button
            helper.ClickBotton(driver, "//div[@class='buttons']/div[@class='pull-right']/a[@class='btn btn-primary']", "Xpath");

            //click currency dropdown
            helper.ClickBotton(driver, "//button[@class='btn btn-link dropdown-toggle']/i[@class='fa fa-caret-down']", "Xpath");
            helper.ClickBotton(driver, "//div[@class='btn-group open']/ul[@class='dropdown-menu']/li[1]/button[@class='currency-select btn btn-link btn-block']", "Xpath");
            //search for product
            helper.EnterText(driver, "//div[@class='col-sm-5']/div[@id='search']/input[@class='form-control input-lg']", "Samsung SyncMaster 941BW", "Xpath");
            //click on search
            helper.ClickBotton(driver, "//div[@class='col-sm-5']/div[@id='search']/span[@class='input-group-btn']/button[@class='btn btn-default btn-lg']", "Xpath");

            //get text
            String PriceText= helper.GetElementText(driver, "//div[@class='product-thumb']/div[2]/div[@class='caption']/p[@class='price']", "Xpath");
            
            string pattern = "[€]";
            Regex regex = new Regex(pattern);
            regex.Match(PriceText);
            // Get all matches  
            MatchCollection MatchedCurrency = regex.Matches(PriceText);

            regex.Match(PriceText);

            //logout
            helper.ClickBotton(driver, "//li[@class='dropdown']/a[@class='dropdown-toggle']/span[@class='hidden-xs hidden-sm hidden-md']", "Xpath");
            helper.ClickBotton(driver, "//ul[@class='list-inline']/li[@class='dropdown open']/ul[@class='dropdown-menu dropdown-menu-right']/li[5]/a", "Xpath");


        }

        //close driver gets invalid session id 
        [TearDown]
        public void CleanUp()
        {   
            //driver.Close();
                  
        }
}
}