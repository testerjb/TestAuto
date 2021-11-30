using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestAuto.Pages
{
    internal class HelperClass
    {
        bool Displayed = false;
        private static Random random = new Random();

        public Boolean WaitingElement(IWebDriver driver, String element, string elementType)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            if (elementType == "Name")
            {
                wait.Until((d) => { return driver.FindElement(By.Name(element)); });
                Displayed = driver.FindElement(By.Name(element)).Displayed;
                if (Displayed)
                {
                    return true;
                }
                else { return false; }
            }

            if (elementType == "Id")
            {
                wait.Until((d) => { return driver.FindElement(By.Id(element)); });
                Displayed = driver.FindElement(By.Id(element)).Displayed;
                if (Displayed)
                {
                    return true;
                }
                else { return false; }
            }
            if (elementType == "ClassName")
            {
                wait.Until((d) => { return driver.FindElement(By.ClassName(element)); });
                Displayed = driver.FindElement(By.ClassName(element)).Displayed;
                if (Displayed)
                {
                    return true;
                }
                else { return false; }
            }
                return Displayed;
        }

        public void EnterText(IWebDriver driver, string element, string value, string elementType)
        {          
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            if (elementType == "Name")
            {
                if (WaitingElement(driver, element,"Name"))
                { 
                    driver.FindElement(By.Name(element)).SendKeys(value);
                }
            }
            if (elementType == "Id")
            {
                if (WaitingElement(driver, element,"Id"))                    
                {
                    driver.FindElement(By.Id(element)).SendKeys(value);
                }
            }
            if (elementType == "ClassName")
            {
                if (WaitingElement(driver, element,"ClassName"))
                {                   
                    driver.FindElement(By.ClassName(element)).SendKeys(value);
                    
                }                
            }
            if (elementType == "Xpath")
            {
                if (WaitingElement(driver, element, "Xpath"))
                {
                    driver.FindElement(By.XPath(element)).SendKeys(value);
                }
            }
        }

        public void ClickBotton(IWebDriver driver, string element, string elementType)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            if (elementType == "Name")
            {
                if (WaitingElement(driver, element, "Name"))
                {
                    driver.FindElement(By.Name(element)).Click();
                }
            }
            if (elementType == "Id")
            {
                if (WaitingElement(driver, element, "Id"))
                {
                    driver.FindElement(By.Id(element)).Click();
                }
            }
            if (elementType == "ClassName")
            {
                if (WaitingElement(driver, element, "ClassName"))
                {
                    driver.FindElement(By.ClassName(element)).Click();
                }
            }
            if (elementType == "Xpath")
            {
                if (WaitingElement(driver, element, "Xpath"))
                {
                    driver.FindElement(By.XPath(element)).Click();
                }
            }
        }

        public void ClickActions(IWebDriver driver, string element, string elementType)
        {
            if (elementType == "Name")
            {
                if (WaitingElement(driver, element, "Name"))
                {
                    Actions action = new Actions(driver);
                    action.MoveToElement(driver.FindElement(By.Name(element)), 2, 2).Click().Perform();
                }
            }
            if (elementType == "Id")
            {
                if (WaitingElement(driver, element, "Id"))
                {
                    Actions action = new Actions(driver);
                    action.MoveToElement(driver.FindElement(By.Id(element)), 2, 2).Click().Perform();
                }
                 
            }
            if (elementType == "ClassName")
            {
                if (WaitingElement(driver, element, "ClassName"))
                {
                    Actions action = new Actions(driver);
                    action.MoveToElement(driver.FindElement(By.ClassName(element)), 2, 2).Click().Perform();
                }
                 
            }
            if (elementType == "Xpath")
            {
                if (WaitingElement(driver, element, "Xpath"))
                {
                    Actions action = new Actions(driver);
                    action.MoveToElement(driver.FindElement(By.XPath(element)), 2, 2).Click().Perform();
                }
            }
        }     

        //not currently used
        public void SelectDropDown(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "Name")
            {
                if (WaitingElement(driver, element, "Name"))
                {
                    new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
                }          
            }
            if (elementType == "Id")
            {
                if (WaitingElement(driver, element, "Id"))
                {
                    new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
                }
            }
            if (elementType == "ClassName")
            {
                if (WaitingElement(driver, element, "ClassName"))
                {
                    driver.FindElement(By.ClassName(element));
                }
            }

        }

        public string GetElementText(IWebDriver driver, string element, string elementType)
        {
            string Text = " . ";
            if (elementType == "Name")
            {
                if (WaitingElement(driver, element, "Name"))
                {
                    string Text2;
                    Text2 = driver.FindElement(By.Name(element)).Text;                                     
                }
            }
                if (elementType == "Id")
                {
                    if (WaitingElement(driver, element, "Id"))
                    {
                        Text = driver.FindElement(By.Id(element)).Text;                    
                    }
                }
            if (elementType == "ClassName")
            {
                if (WaitingElement(driver, element, "ClassName"))
                {
                    Text = driver.FindElement(By.ClassName(element)).Text;                   
                }
            }
            if (elementType == "Xpath")
            {
                if (WaitingElement(driver, element, "Xpath"))
                {
                    Text = driver.FindElement(By.XPath(element)).Text;                 
                }
            }


            return Text;
        }

        public  string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

  
    }
}
