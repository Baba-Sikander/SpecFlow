using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlow.BusinessMethods;
using SpecFlow.CommonLibs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace SpecFlow.Pages
{
    class BillingScreen : WebActions
    {
        CommonFunctions cf = new CommonFunctions();

        public static string LabelName = null;

        public static IWebElement PickerInputField => driver.FindElement(By.XPath("//span[text()='" + LabelName + "']/parent::div//following-sibling::div//input"));
        public static IList<IWebElement> pickerList => driver.FindElements(By.CssSelector("ul.MenuWidget---listbox.MenuWidget---relative li p"));

        //Headers
        public static IWebElement Cust_JobSelectionHeader => driver.FindElement(By.XPath("//span[text()='Customer & Job Selection']"));
        //Customer Details
        public static IWebElement CustRefID => driver.FindElement(By.XPath(""));
        public static IWebElement CustEmailAddress => driver.FindElement(By.XPath(""));
        public static IWebElement CustPhnNumber => driver.FindElement(By.XPath(""));
        public static IWebElement CustCountry => driver.FindElement(By.XPath(""));
        public static IWebElement CustCity => driver.FindElement(By.XPath(""));
        public static IWebElement JobList => driver.FindElement(By.XPath("//span[@data-placeholder='Select Local Jobs']"));
        public static IList<IWebElement> Job_Dropdown => driver.FindElements(By.CssSelector("ul.MenuWidget---listbox.MenuWidget---relative li div"));
        public static IWebElement Save_Btn => driver.FindElement(By.XPath("//button[@type='button'][text()='SAVE']"));
        public static IWebElement ViewSummary_Btn => driver.FindElement(By.XPath("//button[@type='button'][text()='VIEW SUMMARY']"));


        //Services and Charges
        public static IWebElement ServiceName => driver.FindElement(By.XPath("//table/tbody//td/div[@class='DropdownWidget---dropdown']"));
        public static IWebElement Supplier => driver.FindElement(By.XPath("(//table/tbody//td[@class='EditableGridLayout---reducedPadding']/div[contains(@class,'PickerWidget---picker')]//input)[1]"));
        public static IWebElement UOM_Dropdown => driver.FindElement(By.XPath("//table/tbody//td[@class='EditableGridLayout---reducedPadding']/div[@class='DropdownWidget---dropdown']/div[text()='Select a UOM']"));
        public static IWebElement ServiceReqNumber => driver.FindElement(By.XPath("(//table/tbody//td[@class='EditableGridLayout---reducedPadding']//input)[1]"));
        public static IWebElement TransCurrency => driver.FindElement(By.XPath("(//table/tbody//td[@class='EditableGridLayout---reducedPadding']/div[contains(@class,'PickerWidget---picker')]//input)[1]"));
        public static IWebElement UnitPrice => driver.FindElement(By.XPath("(//table/tbody//td[@class='EditableGridLayout---reducedPadding']//input)[2]"));
        public static IWebElement Qty => driver.FindElement(By.XPath("(//table/tbody//td[@class='EditableGridLayout---reducedPadding']//input)[3]"));
        public static IWebElement EstimatedBillAmt => driver.FindElement(By.XPath("(//table/tbody//td[@class='EditableGridLayout---reducedPadding']//input)[4]"));
        public static IWebElement UnitCost => driver.FindElement(By.XPath("(//table/tbody//td[@class='EditableGridLayout---reducedPadding']//input)[5]"));
        public static IWebElement EstimatedCostAmt => driver.FindElement(By.XPath("(//table/tbody//td[@class='EditableGridLayout---reducedPadding']//input)[6]"));
        public static IWebElement ExchangeRate => driver.FindElement(By.XPath("(//table/tbody//td[@class='EditableGridLayout---reducedPadding']//input)[7]"));
        public static IWebElement TaxType_Dropdown => driver.FindElement(By.XPath("//table/tbody//td[@class='EditableGridLayout---reducedPadding']/div[@class='DropdownWidget---dropdown']/div[text()='Tax Type']"));
        public static IWebElement Remarks => driver.FindElement(By.XPath("(//table/tbody//td[@class='EditableGridLayout---reducedPadding']//input)[8]"));

        public static IWebElement Checkbox => driver.FindElement(By.XPath("(//table/tbody//td/div[contains(@class,'CheckboxGroup---choice_group')])[2]"));

        

        public void VerifyCreateBillingPageLoaded(string PageName)
        {
            try
            {
                WaitForObject(Cust_JobSelectionHeader);
                AssertTrue(Save_Btn.Displayed, PageName + " not loaded");
            }
            catch (Exception)
            {

            }
        }

        public void SelectCustomerViaReferenceID(string RefID)
        {
            EnterText(CustRefID, RefID);
            SendKeystrokes("PressTab");
        }


        public void EnterCustomerDetails(string TextToSearch, string CustomerName, string EmailAdd, string PhnNumber, string Country, string City)
        {
            EnterText(CustRefID, TextToSearch);
            Wait(1);
            EnterText(CustEmailAddress, EmailAdd);
            EnterText(CustPhnNumber, PhnNumber);
            EnterText(CustCountry, Country);
            EnterText(CustCity, City);
        }

        public void SelectJob()
        {
            try
            {
                Wait(5);
                SendKeystrokes("PressDown");
                //ClickOn(JobList);
                Wait(3);
                ClickOn(Job_Dropdown.First());
                SendKeystrokes("PressTab");
            }
            catch (Exception) { }
            
            
            //foreach(IWebElement element in Job_Dropdown)
            //{
            //    ClickOn(element);
            //    break;
            //}

            //int NumberOfJobs = Job_Dropdown.Count;

            //if (NumberOfJobs <= NumberOfJobsToSelect)
            //{
            //    foreach (IWebElement element in Job_Dropdown)
            //    {
            //        ClickOn(element);
            //        NumberOfJobs++;
            //    }
                
            //}
            
        }

        public void SaveInvoice()
        {
            ClickOn(Save_Btn);
        }

        
        public void SelectPickerValue(string labelName, string TextToSearch, string ValueToSelect)
        {
            try
            {
                LabelName = labelName;
                Wait(10);
                WaitForObject(PickerInputField);
                cf.SelectValueFromPicker(PickerInputField, TextToSearch, ValueToSelect);
                Wait(3);
            }
            catch (Exception) { }
        }

        public void SelectInvoiceDate(string dateToSelect)
        {
            try
            {

                string InvoiceDate_XPath = "//label[@class='FieldLayout---field_label'][text()='Invoice Date']/parent::div//following-sibling::div//input";

                IWebElement InvoiceData = driver.FindElement(By.XPath(InvoiceDate_XPath));

                EnterText(InvoiceData, dateToSelect);

                Wait(3);
                //IWebElement element = driver.FindElement(By.XPath("//input[contains(@id,'datePicker')]"));
                //ClickOn(element);
                //Wait(2);
                //IWebElement TableElement = driver.FindElement(By.CssSelector("div.DatePicker---goog-date-picker table tbody"));
                //SelectDate(TableElement, "07/23/2020");
            }
            catch (Exception) { }
        }

        public void SelectServices(string Service)
        {
            cf.SelectValueFromDropDown(ServiceName, Service);
            Wait(5);
            PageSync();

            //ClickOn(ServiceName);
            //Wait(5);
            //SendKeystrokes("PressDown");
            //SendKeystrokes("PressDown");
            //SendKeystrokes("PressDown");
            //SendKeystrokes("PressEnter");
        }

        public void EnterCharges()
        {
            cf.SelectValueFromPicker(Supplier, "GS GLOBAL", "GS GLOBAL CORP");
            Wait(1);
            cf.SelectValueFromDropDown(UOM_Dropdown, "20 TANK");
            Wait(5);
            EnterText(ServiceReqNumber, "SR534531");
            cf.SelectValueFromPicker(TransCurrency, "AED","AED");
            Wait(1);
            EnterText(UnitPrice, "100");
            EnterText(Qty, "80");
            EnterText(EstimatedBillAmt, "7800");
            EnterText(UnitCost, "50");
            EnterText(EstimatedCostAmt, "3800");
            EnterText(ExchangeRate, "1");
            cf.SelectValueFromDropDown(TaxType_Dropdown, "VAT 5%");
            PageSync();
            EnterText(Remarks, "Auto_Test");
        }

        public void ClickSave()
        {
            ClickOn(Save_Btn);
        }

        public void ClickViewSummary()
        {
            ClickOn(ViewSummary_Btn);
            Wait(10);
            PageSync();
        }

        public void SelectServicesCheckbox()
        {
            ClickOn(Checkbox);
            Wait(5);
        }
    }
}