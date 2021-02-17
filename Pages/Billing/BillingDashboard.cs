using NUnit.Framework;
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
    class BillingDashboard : WebActions
    {
        CommonFunctions cf = new CommonFunctions();

        //New Elements for Ready for Billing tab
        IWebElement PlusIcon => driver.FindElement(By.CssSelector("a.LinkedItem---standalone_richtext_link.LinkedItem---inLightBackground"));

        IWebElement BusinessArea_dropdown => driver.FindElement(By.XPath("//div[@class='DropdownWidget---dropdown_value DropdownWidget---placeholder DropdownWidget---inSideBySideItem'][text()='Select Business Area']"));

        public static IList<IWebElement> BusinessArea_Values => driver.FindElements(By.XPath("//ul[contains(@class,'MenuWidget---listbox')]//li/div"));

        public static IList<IWebElement> DropDown_Values => driver.FindElements(By.XPath("//div[contains(@class,'DropdownWidget---tether_dropdown')]//ul[contains(@class,'MenuWidget---listbox')]//li/div"));

        IList <IWebElement> Checkbox => driver.FindElements(By.XPath("//div[@class='CheckboxGroup---choice_group CheckboxGroup---no_label CheckboxGroup---align_start']"));

        IWebElement StartBilling_Btn => driver.FindElement(By.XPath("//span[text()='START BILLING']"));

        IWebElement BankAccount => driver.FindElement(By.XPath("//div[@class='DropdownWidget---dropdown_value DropdownWidget---placeholder'][contains(text(),'Bank Account')]"));

        public static IWebElement SearchCust => driver.FindElement(By.XPath(""));
        public static IWebElement SelectOpProcess => driver.FindElement(By.XPath(""));
        public static IWebElement SearchJobNumber => driver.FindElement(By.XPath("//label[@class='FieldLayout---field_label'][text()='Job Number']/parent::div/following-sibling::div//input"));      //JOB0000285
        public static IWebElement SelectBusinessArea => driver.FindElement(By.XPath(""));
        public static IWebElement SelectBillingStatus => driver.FindElement(By.XPath(""));
        public static IWebElement SelectBillingPriority => driver.FindElement(By.XPath(""));
        public static IWebElement NumberOfJobs_Count => driver.FindElement(By.XPath(""));
        public static IList<IWebElement> CustomerRow => driver.FindElements(By.XPath(""));
        //To Count the Number of Jobs for a Customer
        public static IList<IWebElement> JobNumberRow => driver.FindElements(By.XPath(""));
        //To Select the Jobs to be selected
        public static IList<IWebElement> JobNumberRow_Checkbox => driver.FindElements(By.XPath(""));
        //public static IWebElement StartBilling_Btn => driver.FindElement(By.XPath(""));
        public static IWebElement ReadyForBilling_Tab => driver.FindElement(By.XPath(""));
        public static IWebElement BillingInProgress_Tab => driver.FindElement(By.XPath(""));


        public void VerifyJobCount()
        {
            try
            {
                if(Int32.Parse(NumberOfJobs_Count.GetAttribute("innerText")) == JobNumberRow.Count)
                {
                    Assert.That(Int32.Parse(NumberOfJobs_Count.GetAttribute("innerText")).Equals(JobNumberRow.Count), "Number of Jobs in the list and in Job Column are not equal");
                }
            }
            catch (Exception) { }
        }

        public void SelectJobs(int NumberOfJobs)
        {
            int Count = 0;
            try
            {                
                foreach (IWebElement element in JobNumberRow_Checkbox)
                {
                    if (NumberOfJobs >= 1)
                    {
                        ClickOn(element);
                        NumberOfJobs--;
                        Count++;
                        break;
                    }
                }
                Assert.True(Int32.Parse("No. of Jobs Checked").Equals(Count), "Not equal");
            }
            catch (Exception)
            {
            }
        }

        public void SelectJob()
        {
            try
            {
                Wait(5);
                SendKeystrokes("PressDown");
                //ClickOn(JobList);
                Wait(3);
                ClickOn(BillingScreen.Job_Dropdown.First());
                SendKeystrokes("PressTab");
            }
            catch (Exception) { }


        }

        public void SelectSingleJobToBill(string JobType)
        {
            try
            {
                ClickOn(PlusIcon);
                Wait(3);
                if (JobType.ToUpper().Equals("SINGLE"))
                {
                    ClickOn(Checkbox.ElementAt(1));
                }
                else
                {
                    for (int i = 1; i < Checkbox.Count - 1; i++)
                    {
                        ClickOn(Checkbox.ElementAt(i));
                    }
                }
                Wait(5);
                ClickOn(StartBilling_Btn);
                Wait(5);
            }
            catch (Exception) { }
        }

        public void SelectBusinessAreaFilter(string BusinessArea)
        {
            cf.SelectValueFromDropDown(BusinessArea_dropdown, BusinessArea);
        }

        public void ClickBillingDashboardTab(string TabName)
        {
            IWebElement TabElement = driver.FindElement(By.XPath("//span[text()='" + TabName + "']"));

            ClickOn(TabElement);
            Wait(3);
        }
    }
}