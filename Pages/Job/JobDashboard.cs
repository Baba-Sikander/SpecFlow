using AventStack.ExtentReports.Utils;
using OpenQA.Selenium;
using SpecFlow.BusinessMethods;
using SpecFlow.CommonLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Pages
{
    class Job_Dashboard : WebActions
    {
        CommonFunctions cf = new CommonFunctions();
        public static string PageName = null;
        IWebElement Page => driver.FindElement(By.XPath("//strong[@class='StrongText---richtext_strong'][text()='" + PageName + "']"));
        IWebElement CurrentJobs => driver.FindElement(By.XPath("//strong[text()='CURRENT JOBS']"));
        IWebElement JobSearch => driver.FindElement(By.XPath("//input[@class='TextInput---text TextInput---align_start TextInput---inSideBySideItem']"));
        IWebElement JobSearchButton => driver.FindElement(By.XPath("//button[text()='Search']"));
        IWebElement OPID => driver.FindElement(By.XPath("//div[@class='ContentLayout---content_layout ContentLayout---padding_less']//a[contains(@href,'view/summary')]"));
        IWebElement ExpandedViewJobID => driver.FindElements(By.XPath("//*[@class='FieldLayout---field_layout FieldLayout---margin_below_none FieldLayout---inColumnArrayLayout appian-context-last-in-list']//span[@class='SizedText---small SizedText---predefined']"))[0];
        //From VT_ServiceCharges
        IWebElement LocalJobNo => driver.FindElement(By.XPath("//a[contains(@href,'https://gactest.appiancloud.com/suite/sites/pegasus-job/page/local-job/record')]/span"));
        IWebElement OpProcessRefNum => driver.FindElement(By.XPath("//a[contains(@href,'https://gactest.appiancloud.com/suite/sites/pegasus-job/page') and contains(@class,'LinkedItem')]"));

        public string JobID;
        public string OP_ID;
        public string CaptureNewJobID()
        {
            JobID = LocalJobNo.GetAttribute("innerText");
            return JobID;
        }

        public void ClickLocalJob()
        {
            ClickOn(LocalJobNo);
            SwitchToLastWindow();
        }
        public void VerifyPageTitle(string OP_ID,string OP_Name)
        {
            if (OP_ID=="" || OP_ID==null)
            {
                OP_ID = this.OP_ID;
            }
            if (driver.PageSource.Contains(OP_ID + " | " + OP_Name))
            {
                AssertTrue(true, "Operational Process not created");
            }
        }

        public void NavigateToPage(string pageName)
        {
            PageName = pageName;
            WaitForObject(Page);
            ClickOn(Page);
            Wait(2);
            SwitchToLastWindow();
            Wait(5);
        }
        public string ClickOperProcessLink()
        {
            Wait(5);
            RefreshPage();
            Wait(15);
            OP_ID = OpProcessRefNum.GetAttribute("innerText");
            ClickOn(OpProcessRefNum);
            SwitchToLastWindow();
            return OP_ID;
        }
        public void ClickOnGivenLink(string labelName)
        {
            string xPath = "//a[@class='LinkedItem---standalone_richtext_link LinkedItem---inStrongText elements---global_a'][text()=' " + labelName + "']";
            Wait(10);
            ClickOn(driver.FindElement(By.XPath(xPath)));
        }
        public String GetCurrentJobs()
        {
            return GetText(CurrentJobs);
        }

        public void SearchJob(String searchCriteria)
        {
            Set_Textbox(JobSearch, searchCriteria);
        }
        public void ClickSearchJob()
        {
            ClickOn(JobSearchButton);
        }

        public IList<IWebElement> GetOpenJobs(String username)
        {
            string firstname = cf.getFirstName();
            if (username.Equals("me"))
            {
                return driver.FindElements(By.XPath("//span[text()='Ship Agency']/..//ancestor::div//span[contains(text(),'" + firstname + "')]"));
            }
            else
                return driver.FindElements(By.XPath("//span[text()='Ship Agency']/..//ancestor::div//span[contains(text(),'"+ username+"')]"));
        }
        public string SelectOpenJob(String username)
        {
            ClickOn(GetOpenJobs(username)[0]);
          
            Wait(5);
            PageSync();
            //TODO - Return JobID
            JobID = ExpandedViewJobID.Text;
            return JobID;
        }
        public IWebElement GetOpId()
        {
           return OPID;
           
           
        }
        public String getProcessRefId(String localJobId)
        {
            try
            {
                return driver.FindElement(By.XPath("//span[text()='" + localJobId + "']/ancestor::div[@class='ContentLayout---content_layout ContentLayout---padding_less']//a")).Text;
            }
            catch
            {
                RefreshPage();
                PageSync();
                Wait(2);
                return driver.FindElement(By.XPath("//span[text()='" + localJobId + "']/ancestor::div[@class='ContentLayout---content_layout ContentLayout---padding_less']//a")).Text;
            }
        }
        
        public void AccessOpSummaryPage(String OpId)
        {
          IWebElement EleOPID=driver.FindElement(By.LinkText(OpId));
            ClickOn(EleOPID);
            SwitchToLastWindow();
            Wait(3);
            PageSync();
        }
    }
}
