﻿using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TurnupNunitMay20;

namespace turnuppp
{
    [Binding]
    public class TimeandMaterialSteps
    {
        public IWebDriver driver = new ChromeDriver();
        [Given(@"I have logged in turn up loginpage successfully")]
        public void GivenIHaveLoggedInTurnUpLoginpageSuccessfully()
        {

            // open a browser
            driver = new ChromeDriver();
            var loginpage = new Login(driver);
            loginpage.LoginSuccess();
        }

        [Given(@"I navigate to time and material")]
        public void GivenINavigateToTimeAndMaterial()
        {
            var homePage = new Home(driver);
            homePage.clickAdminstration();

            homePage.clickTimenMaterials();
        }
        [When(@"I create new time and material form")]
        public void WhenICreateNewTimeAndMaterialForm()

        {
            TimeMaterial timeMaterial = new TimeMaterial(driver);
            timeMaterial.clickCreateNew();

            timeMaterial.CreateNewRecord("ck", "des1");
           
        }
        [Then(@"The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TimeMaterial timeMaterial = new TimeMaterial(driver);
            timeMaterial.ValidateNewRecord();
            driver.Quit();
        }

        [When(@"I edit an existing time and material")]
        public void WhenIEditAnExistingTimeAndMaterial()
        {
            TimeMaterial timeMaterial = new TimeMaterial(driver);
            timeMaterial.EditNewRecord();



        }
        [Then(@"The record should be edited successfully")]
        public void ThenTheRecordShouldBeEditedSuccessfully()
        {
            TimeMaterial timeMaterial = new TimeMaterial(driver);
            //timeMaterial.ValidateEditRecord();
            driver.Quit();
        }
       
        [When(@"I create time and material with below (.*) and (.*)")]
        public void GivenICreateTimeAndMaterialWithBelowAnd(string p0, string p1)
        {
            var homePage = new Home(driver);
            homePage.clickAdminstration();
            homePage.clickTimenMaterials();

            TimeMaterial timeMaterial = new TimeMaterial(driver);
            timeMaterial.clickCreateNew();

            timeMaterial.CreateNewRecord(p0, p1);
            
        }
        
        [Then(@"The record should be created with given values test(.*) and testdescription(.*) successfully")]
        public void ThenTheRecordShouldBeCreatedWithGivenValuesTestAndTestdescriptionSuccessfully(string p0,string p1)
        {
            TimeMaterial timeMaterial = new TimeMaterial(driver);
            timeMaterial.ValidateNewRecord1(p0, p1);
            driver.Quit();
        }



        [When(@"I delete an existing time and material")]
        public void WhenIDeleteAnExistingTimeAndMaterial()
        {
            var homePage = new Home(driver);
            homePage.clickAdminstration();
            homePage.clickTimenMaterials();
            TimeMaterial timeMaterial = new TimeMaterial(driver);

            timeMaterial.DeleteNewRecord();

        }
        [Then(@"The record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {

            driver.Quit();
        }
        




    }


}














