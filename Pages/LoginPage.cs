using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlow.CommonLibs;
using SpecFlow.Utilities.ReportUtil;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlow.Pages
{
    class LoginPage : WebActions
    {
        IWebElement lognElement => driver.FindElement(By.XPath("//div[@class='login_box_inner']"));
        IWebElement Username => driver.FindElement(By.Id("un"));
        IWebElement Password => driver.FindElement(By.Id("pw"));
        IWebElement LoginBtn => driver.FindElement(By.XPath("//input[@type='submit']"));

        IWebElement PegasusLogoText => driver.FindElement(By.XPath("//span[text()='Pegasus Applications']"));

        IWebElement UserProfile => driver.FindElement(By.XPath("//div[@class='UserProfileLayout---current_user_menu_wrapper']"));
        IWebElement SignOut_button => driver.FindElement(By.XPath("//button[text()='Sign Out']"));
        IWebElement LoginLogo => driver.FindElement(By.XPath("//div[@class='login_logo']"));
        


        public void EnterCreds(string UserName)
        {
            try
            {
                WaitForObject(lognElement);
                EnterText(Username, username);
                EnterText(Password, ConfigurationManager.AppSettings["password"]);

                //Username.SendKeys(UserName);
                //Password.SendKeys(ConfigurationManager.AppSettings["password"]);
            }
            catch(Exception ex)
            {
                ExtentReportUtil.report.Log(Status.Error, "Error occurred in Login");
            }
                    
        }
        
        public void ClickLogin()
        {
            ClickOn(LoginBtn);
            //LoginBtn.Click();               
        }

        public void LoginToApplication(string username)
        {
            EnterText(Username, username);
            //EnterText(Password, ConfigurationManager.AppSettings["password"]);
            //Username.SendKeys(username);
            Password.SendKeys(ConfigurationManager.AppSettings["password"]);
            ClickOn(LoginBtn);
            WaitForObject(PegasusLogoText);
            AssertTrue(PegasusLogoText.Displayed, "Login unsuccessful");
            Wait(5);
        }

        public void Logout()
        {
            ClickOn(UserProfile);
            Wait(2);
            ClickOn(SignOut_button);
            WaitForObject(LoginLogo);
        }
    }
}
