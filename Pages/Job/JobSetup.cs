using OpenQA.Selenium;
using SpecFlow.BusinessMethods;
using SpecFlow.CommonLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Pages.Job
{
    class JobSetup : WebActions
    {
        readonly CommonFunctions cf = new CommonFunctions();
        public static IWebElement BusinessProduct => driver.FindElement(By.XPath("//div[contains(text(),'Select a Business Product')]"));
        public static IWebElement OpProcess => driver.FindElement(By.XPath("//div[contains(text(),'Select a Value')]"));
        public static IWebElement NextButton => driver.FindElement(By.XPath("//button[text()='NEXT']"));
        IWebElement Customer_Name => driver.FindElement(By.XPath("//input[contains(@aria-labelledby,'_column0_header')]"));
        public void EnterJobSetupDetails(string businessProduct, string opProcess)
        {
            cf.SelectValueFromDropDown(BusinessProduct, businessProduct);
            cf.SelectValueFromDropDown(OpProcess, opProcess);
            Wait(1);
            ClickOn(NextButton);
            PageSync();
            Wait(10);
            AssertTrue(Customer_Name.Displayed, "Did not navigate to Job Details screen");
        }
    }
}
