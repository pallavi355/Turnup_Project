using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace TurnupNunitMay20
{
    internal class Home
    {
        private IWebDriver driver;
        
        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }
        internal void clickAdminstration()
        {
            Assert.That(driver.FindElement(By.XPath("//a[@href='#'][contains(.,'Administration')]")).Text, Is.EqualTo("Administration"));
             //click admin & click time and material
            driver.FindElement(By.XPath("//a[@href='#'][contains(.,'Administration')]")).Click();
            Console.WriteLine("Assertion pass");
        }

        internal void clickTimenMaterials()
        {
            Assert.That(driver.FindElement(By.XPath("//a[@href='/TimeMaterial']")).Text, Is.EqualTo("Time & Materials"));
            driver.FindElement(By.XPath("//a[@href='/TimeMaterial']")).Click();
            Console.WriteLine("assertion pass");
        }
    }
}