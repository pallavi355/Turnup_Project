﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;


namespace turnuppp.Customthd
{
   public  class seleniumsetmethod
    {

        public static void EnterText(
            IWebDriver driver,
            string element,
            string value,
            string elementtype)
        {

            if (elementtype == "Id")
                driver.FindElement(By.Id(element)).SendKeys(value);
            if (elementtype == "Name")
                driver.FindElement(By.Name(element)).SendKeys(value);
        }

        public static void Click(IWebDriver driver, string element, string elementtype)
        {

            if (elementtype =="Id")
                driver.FindElement(By.Id(element)).Click();
            if (elementtype == "Name")
                driver.FindElement(By.Name(element)).Click();
        }

         
    }


}
