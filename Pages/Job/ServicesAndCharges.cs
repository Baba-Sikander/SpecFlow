using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SpecFlow.BusinessMethods;
using SpecFlow.CommonLibs;
using SpecFlow.Utilities.ReportUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Pages.Job
{
    class ServicesAndCharges : WebActions
    {

        readonly CommonFunctions cf = new CommonFunctions();

        public string JobID;
        public string OP_ID;
        public string SectionHeaders;

        IWebElement SectionHeading => driver.FindElement(By.XPath("//div[@class='BoxLayout---box_label'][@title='" + SectionHeaders + "']"));
        IWebElement VT_LabelHeader => driver.FindElement(By.XPath("//strong[contains(text(),'VESSEL TRACKING')]"));
        public static IWebElement CreateButton => driver.FindElement(By.XPath("//button[text()='Create']"));
        IWebElement LocalJobNo => driver.FindElement(By.XPath("//a[contains(@href,'https://gactest.appiancloud.com/suite/sites/pegasus-job/page/local-job/record')]/span"));
        IWebElement OpProcessRefNum => driver.FindElement(By.XPath("//a[contains(@href,'https://gactest.appiancloud.com/suite/sites/pegasus-job/page') and contains(@class,'LinkedItem')]"));
        IWebElement VT_SC_Grid => driver.FindElement(By.XPath("(//table[contains(@class,'EditableGridLayout---table')])[2]"));

        IWebElement VT_SC_TBody => VT_SC_Grid.FindElement(By.XPath("//tbody"));

        //Service 1 & Charges
        IWebElement VT_Row1 => VT_SC_TBody.FindElement(By.XPath("//tr[1]"));
        IWebElement VT_Col3_UOM => VT_Row1.FindElement(By.XPath("//td[3]/div/div"));
        IWebElement VT_Col5_Supplier => VT_Row1.FindElement(By.XPath("//td[5]//input"));
        IWebElement VT_Col6_SRN => VT_Row1.FindElement(By.XPath("//td[6]//input"));
        IWebElement VT_Col7_CostCurr => VT_Row1.FindElement(By.XPath("//td[7]//input"));
        IWebElement VT_Col16_PriceCurrency => VT_Row1.FindElement(By.XPath("//td[16]/div/div"));

        //Service 2 & Charges
        IWebElement VT_Row2 => VT_SC_TBody.FindElement(By.XPath("//tr[2]"));
        IWebElement VT_Col1_Principal => VT_Row2.FindElement(By.XPath("//td[1]//input"));
        IWebElement VT_Col2_BillingParty => VT_Row2.FindElement(By.XPath("//td[2]//input"));
        IWebElement VT_Col4_Qty => VT_Row2.FindElement(By.XPath("//td[4]//input"));
        IWebElement VT_Col8_ActualUnitCost => VT_Row2.FindElement(By.XPath("//td[8]//input"));
        IWebElement VT_Col10_EstTotalCost => VT_Row2.FindElement(By.XPath("//td[10]//input"));
        IWebElement VT_Col11_TaxType => VT_Row2.FindElement(By.XPath("//td[11]//input"));
        IWebElement VT_Col12_TaxRate => VT_Row2.FindElement(By.XPath("//td[12]//input"));
        IWebElement VT_Col17_Margin => VT_Row2.FindElement(By.XPath("//td[17]//input"));
        IWebElement VT_Col18_ActualUnitPrice => VT_Row2.FindElement(By.XPath("//td[18]//input"));
        IWebElement VT_Col20_Discount => VT_Row2.FindElement(By.XPath("//td[20]//input"));
        IWebElement VT_Col25_OperatingIncome => VT_Row2.FindElement(By.XPath("//td[25]/div/div"));


        public void ClickLabel()
        {
            ClickOn(VT_LabelHeader);
            Wait(5);
        }

        public void EnterServicesAndCharges()
        {
            cf.SelectValueFromDropDown(VT_Col3_UOM, "BULK LIQUID");
            cf.SelectValueFromPicker(VT_Col5_Supplier, "Blue Mountain", "Blue Mountain Tankers AS");
            cf.SelectValueFromPicker(VT_Col7_CostCurr, "AED", "AED");
            cf.SelectValueFromPicker(VT_Col1_Principal, "Blanchard", "Blanchard Cat Power Systems");

            EnterText(VT_Col4_Qty, "20");
            EnterText(VT_Col8_ActualUnitCost, "350");
            EnterText(VT_Col10_EstTotalCost, "7000");
            EnterText(VT_Col11_TaxType, "VAT");
            EnterText(VT_Col12_TaxRate, "5");

            EnterText(VT_Col17_Margin, "10");
            EnterText(VT_Col18_ActualUnitPrice, "");
            Wait(5);

            //ClickOn(VT_CreateJob.NextButton);

        }

        public void ClickCreate()
        {
            ClickOn(CreateButton);
            PageSync();
            Wait(10);
        }

        public void VerifySectionHeaders(string SectionHeaders)
        {
            try
            {
                AssertTrue(SectionHeading.GetAttribute("innerText").Contains(SectionHeaders), "Section Header - " + SectionHeaders + " is NOT Displayed");
            }
            catch(Exception)
            {
                ExtentReportUtil.report.Log(AventStack.ExtentReports.Status.Fail, "Assertion Failed for " + SectionHeaders +" presence.");
            }
        }

        public string CaptureJobID()
        {
            JobID = LocalJobNo.GetAttribute("innerText");
            return JobID;
        }

        public void ClickLocalJob()
        {
            ClickOn(LocalJobNo);
            SwitchToLastWindow();
        }

        public string ClickOperProcessLink()
        {
            OP_ID = OpProcessRefNum.GetAttribute("innerText");
            Wait(20);
            ClickOn(OpProcessRefNum);
            SwitchToLastWindow();
            return OP_ID;
        }

        public void VerifyPageTitle(string OP_Name)
        {
            if (driver.PageSource.Contains(OP_ID + " | " + OP_Name))
            {
                Console.WriteLine("OP created successfully...");

                //OP000000968 | Vessel Tracking'
            }
        }
    }
}
