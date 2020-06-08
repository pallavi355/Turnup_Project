using System;
using System.Data;
using System.Security.Cryptography;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TurnupNunitMay20
{
    internal class TimeMaterial
    {
        IWebDriver driver;
        public TimeMaterial(IWebDriver driver)
        {
            this.driver = driver;
        }



        internal void clickCreateNew()
        {
            //checking the text of  drag a column header and drop it here to group bt that column  
            //  Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[1]")).Text, Is.EqualTo(" "));
            //click create and new button
            try
            {
                IWebElement createNew = driver.FindElement(By.XPath("//a[@href='/TimeMaterial/Create']"));
                createNew.Click();
                Console.WriteLine("assertion pass");
            }
            catch (Exception message)
            {

                Console.WriteLine(message.ToString());
                Assert.Fail();

            }
        }


        internal void CreateNewRecord(string code, string Description)
        {
            //check the text of element back to list means we are on Time and material page 

            Assert.That(driver.FindElement(By.XPath("//*[@id='container']/div/a")).Text, Is.EqualTo("Back to List"));

            Console.WriteLine("assertion pass");
            //try
            //{
            //    //check if new page opened to create new
            //    Assert.That((driver.Url).ToString, Is.EqualTo("http://horse-dev.azurewebsites.net/TimeMaterial/Create"));
            //}
            //catch (Exception message)
            //{
            //    Console.WriteLine(message);
            //}
            //Find Code button
            IWebElement Code = driver.FindElement(By.Id("Code"));
            Code.SendKeys(code);
            //Find description button and entering value//
            //IWebElement saveButton = driver.FindElement(By.XPath("//input[contains(@id,'SaveButton')]"));
            //saveButton.Click();
            //// the description field is required
            //try
            //{
            //    Assert.AreEqual("", driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[3]/div/span")).Text);

            //    Console.WriteLine("assertion pass");

            //}
            //catch (Exception e)
            //{

            //    Console.Write(e);
            //}
            Thread.Sleep(1500);
            IWebElement Description1 = driver.FindElement(By.XPath("//input[contains(@id,'Description')]"));

            Description1.SendKeys(Description);
            //find Price textbox and write price
            IWebElement Price = driver.FindElement(By.CssSelector("input.k-formatted-value.k-input"));
            Price.SendKeys("10.00");
            //IWebElement price = driver.FindElement(By.CssSelector("input.k-formatted-value.k-input"));
            //price.Click();
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //string script = "return document.getelementbyid(\"price\").value = 20;";
            //_ = js.ExecuteScript(script);

            IWebElement saveButton1 = driver.FindElement(By.XPath("//input[contains(@id,'SaveButton')]"));
            saveButton1.Click();

        }

        internal void EditNewRecord()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]")).Click();

            IWebElement code = driver.FindElement(By.Id("Code"));
            code.Clear();
            code.SendKeys("777");


            Thread.Sleep(1000);
            //find Description textbox and write description
            string descriptionInput = "hello";

            IWebElement description = driver.FindElement(By.Id("Description"));
            description.Clear();
            description.SendKeys(descriptionInput);
            IWebElement price = driver.FindElement(By.CssSelector("input.k-formatted-value.k-input"));
            price.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string script = "return document.getElementById(\"Price\").value = 2020;";
            js.ExecuteScript(script);

        }

        internal void DeleteNewRecord()
        {
            Thread.Sleep(2000);
            // //*[@id="tmsGrid"]/div[3]/table/tbody/tr[1]/td[5]/a[2]
            driver.FindElement(By.LinkText("Delete")).Click();
            IAlert alert = driver.SwitchTo().Alert();

            //String alertmessage = alert.Text;


            //if (alertmessage.Equals("Are you sure you want to delete this record ? "))
            //{

            //    Console.WriteLine("correct msg");
            //}
            //else
            //{
            //    Console.WriteLine("incorrect msg");
            //}
            alert.Accept();
        }
        internal void GoToLastPage()
        {


            //Find go to last page button and click it
            IWebElement lastPageBtn = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            Thread.Sleep(1500);
            lastPageBtn.Click();


        }

        public void GoToPreviousPage()
        {
            IWebElement lastPageBtn = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[2]/span"));
            Thread.Sleep(1500);
            lastPageBtn.Click();

        }

        internal void GoToNextPage()
        {
            driver.FindElement(By.XPath("//span[contains(.,'Go to the next page')]")).Click();
            Thread.Sleep(1000);
        }






        internal void ValidateNewRecord()
        {
            Thread.Sleep(1000);
            GoToLastPage();


            try
            {
                while (true)
                {
                    for (var i = 1; i <= 10; i++)
                    {
                        var testcode = driver.FindElement(By.XPath("//*[@id=\"tmsgrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]")).Text;
                        var testdescription = driver.FindElement(By.XPath("//*[@id=\"tmsgrid\"]/div[3]/table/tbody/tr[" + i + "]/td[3]")).Text;
                        // logic to compare the one we wanted
                        Assert.That(testcode, Is.EqualTo("ck"));
                        Assert.That(testdescription, Is.EqualTo("des1"));

                        Console.WriteLine("test passed");
                        break;

                    }
                    GoToPreviousPage();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("test failed");
            }
        }
        internal void ValidateNewRecord1(string code, string Description)
        {
            Thread.Sleep(1000);
            GoToLastPage();


            try
            {
                while (true)
                {
                    for (var j = 1; j <= 10; j++)
                    {
                        var testcode = driver.FindElement(By.XPath("//*[@id=\"tmsgrid\"]/div[3]/table/tbody/tr[" + j + "]/td[1]")).Text;
                        var testdescription = driver.FindElement(By.XPath("//*[@id=\"tmsgrid\"]/div[3]/table/tbody/tr[" + j + "]/td[3]")).Text;
                        // logic to compare the one we wanted
                        Assert.That(testcode, Is.EqualTo(code));
                        Assert.That(testdescription, Is.EqualTo(Description));

                        Console.WriteLine("test passed");
                        break;

                    }
                    GoToPreviousPage();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("test failed");
            }
        }


        internal void ValidateEditRecord()
        {

            // Wait for 1 second
            Thread.Sleep(1000);

            try
            {
                while (true)
                {
                    for (var i = 1; i <= 10; i++)
                    {

                        var testcode = driver.FindElement(By.XPath("//*[@id=\"tmsgrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]")).Text;



                        var testdescription = driver.FindElement(By.XPath("//*[@id=\"tmsgrid\"]/div[3]/table/tbody/tr[" + i + "]/td[3]")).Text;

                        //logic to compare the one we wanted
                        if (testcode == "777" && testdescription == "hello")
                        {
                            Console.WriteLine("test passed");
                            break;
                        }

                        // GoToNextPage();
                        driver.FindElement(By.XPath("//span[contains(.,'Go to the next page')]")).Click();

                    }


                }

            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }
        }


    }
}
