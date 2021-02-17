using Autofac;
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SpecFlow.BusinessMethods;
using SpecFlow.CommonLibs;
using SpecFlow.Utilities.TestDataUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace SpecFlow.Pages
{
    class QuotationDashboard : WebActions
    {
        CommonFunctions cf = new CommonFunctions();
        XMLTestDataReader testDataReader = new XMLTestDataReader();
        //Request Quote Text
        IWebElement RequestQuoteTitle => driver.FindElement(By.XPath("//div[@class='FormLayout---bottom_border']/h1[@class='FormLayout---title'][text()='Request Quote']"));

        //Create new quote link
        IWebElement CreatenewQuoteLink => driver.FindElement(By.XPath("//a[@class='LinkedItem---standalone_richtext_link LinkedItem---inStrongText elements---global_a'][text()=' Create New Quote']"));

        IList<IWebElement> DropDownList => driver.FindElements(By.XPath("//ul[contains(@class,'MenuWidget---listbox')]/li/div"));

        IWebElement CustomerReferenceNumber => driver.FindElement(By.XPath("//label[text()='Customer Reference Number']//parent::div/following-sibling::div//input"));
        public void EnterAllDetailsQuotationSetupDetails()
        {
            //EnvironVariables.FeatureID = "CreateQuotation";
            //Select a customer
            //string customer = testDataReader.ReadData("CustomerName");
            
            SelectCustomer("Customer", "GAC Test", "GAC Test");
            //Enter customer Refernece Number
            EnterCustomerReferenceNumber("Customer Reference Number", "Test Reference 123aBcXyZ");
            //Select Nominated By 
            SelectNominatedBy("Nominated By", "GAC Hub", "GAC Hub Services DWC-LLC");
            //select sales rep
            SelectSalesRep("Sales Rep", "Majeeth", "Majeeth Shaik");

        }

        public void SelectCommercialServiceByValue(string serviceToSelect)
        {
            //Select a commercial service - Vesel Call
            SelectCommercialService("Select a Commercial Service", serviceToSelect);
            cf.ClickButtonByLabelName("NEXT");
        }


        public void SelectAssigneeForVesselCall()
        {
            //Select Assignment Type
            SelectAssigneeType("Select Type", "User");
            SelectAssignee("Assigned Agents", "Majeeth", "Majeeth Shaik");

        }
        public void EnterVesselAndVoyageDetailsOfVesselCall()
        {
            //--------Vessel And Voyage Details --------
            //Select a vessel
            SelectVessel("Vessel", "Aktea", "Aktea");
            //Select a call purpose
            SelectCallPurpose("Select a Call Purpose", "Load");
            //select port
            SelectPort("Port", "Dubai", "Dubai");
            //select last port
            SelectPreviousPort("Previous Port", "Singapore", "Singapore");
            //select next port
            SelectNextPort("Next Port", "Doha", "Doha");
            //Enter ETA
            EnterETA("ETA", "10/08/2020");
            //Enter ETB
            EnterETB("ETB", "10/11/2020");
            //Enter ETC
            EnterETC("ETC", "10/12/2020");
            //Enter ETD
            EnterETD("ETD", "10/13/2020");
        }
        public void EnterCrewDetailsOfVesselCall()
        {

            //--------Crew Details --------
            //Enter No of Sign Off
            EnterText(getLabelTextInputBox("Number Of Sign Off"), "10");
            //Enter No of Sign ON
            EnterText(getLabelTextInputBox("Number Of Sign On"), "10");
            //Sign Off From Date
            EnterText(getLabelTextInputBox("Sign Off From Date"), "10/12/2020");
            //Sign Off To Date
            EnterText(getLabelTextInputBox("Sign Off To Date"), "10/18/2020");
            //Sign On From Date
            EnterText(getLabelTextInputBox("Sign On From Date"), "10/12/2020");
            //Sign On TO Date
            EnterText(getLabelTextInputBox("Sign On To Date"), "10/22/2020");
            //Select Visa Required Checkbox
            ClickOn(getCheckBoxByLabel("Visa Required"));
            //Select Launch Required Checkbox
            ClickOn(getCheckBoxByLabel("Launch Required"));

        }
        public void EnterCargoDetailsOfVesselCall()
        {    
              
            //--------------Cargo Details--------------
            //click on add Cargo details link
            ClickOn(getLinkElementByLabel("Add Cargo Details"));
            SelectDangerousGoods("Selecte a value", "Yes");
            //SelectUnitOfWeight("Select a UOM", "KILOGRAMS");

            //--------------Crew Transport Details--------------
            //click on add new transport details link
            //ClickOn(getLinkElementByLabel("Add Transport Details"));


        }

        public void collectTheLastQuotationNumber()
        {
            Wait(5);
            ClickOn(getTopMenuByLable("Quotations"));
            Wait(5);
            getQuotationNumberText();
        }
        public void VerifyCreatedQuotation()
        {
            //Go to Quoations List Dashboard
            Wait(5);
            ClickOn(getTopMenuByLable("Quotations"));
            Wait(5);


        }
        public void SearchAndOpenCreatedQuotation()
        {
            SearchByNewlyCreatedQuotation("Quotation Number");
            ClickSearchFilterButton("Filter");
            OpenTheCreatedQuotation();
        }

        public void SelectSalesRep(string labelName, string valueToSearch, string valueToPick)
        {

            cf.SelectItemFromPickerField(labelName, valueToSearch, valueToPick);
        }

        public void SelectNominatedBy(string labelName, string valueToSearch, string valueToPick)
        {

            cf.SelectItemFromPickerField(labelName, valueToSearch, valueToPick);
        }

        public void SelectCommercialService(string labelName, string valueToPick)
        {
            cf.SelectValueFromDropDown(labelName, valueToPick);
            //SelectFromDropDown(SelectionType.selectByValue, getDropDownWithinGrid(labelName, valueToPick), valueToPick);

        }

        public void EnterETA(string labelName, string dateTime)
        {
            Wait(5);
            IWebElement ETA = getSpanTextInputBox(labelName);
            EnterText(ETA, dateTime);
            //ClickOn(ETA);
            //SelectDate(ETA, "");
        }

        public void EnterETB(string labelName, string dateTime)
        {

            EnterText(getSpanTextInputBox(labelName), dateTime);
        }

        public void SelectCustomer(string labelName, string valueToSearch, string valueToPick )
        {

            Wait(5);
            cf.SelectItemFromPickerField(labelName, valueToSearch, valueToPick);
        }

        public void SelectVessel(string labelName, string valueToSearch, string valueToPick)
        {
            cf.SelectItemFromPickerField(labelName, valueToSearch, valueToPick);
        }

        public void SelectPort(string labelName, string valueToSearch, string valueToPick)
        {

            cf.SelectItemFromPickerField(labelName, valueToSearch, valueToPick);
        }

        public void SelectPreviousPort(string labelName, string valueToSearch, string valueToPick)
        {
            cf.SelectItemFromPickerField(labelName, valueToSearch, valueToPick);
        }

        public void SelectNextPort(string labelName, string valueToSearch, string valueToPick)
        {

            cf.SelectItemFromPickerField(labelName, valueToSearch, valueToPick);
        }

        public void SelectAssigneeType(string labelName, string valueToPick)
        {
            Wait(5);
            cf.SelectValueFromDropDown(labelName, valueToPick);
        }

        public void SelectDangerousGoods(string labelName, string valueToPick)
        {
            Wait(5);
            cf.SelectValueFromDropDown(labelName, valueToPick);
        }
        public void SelectUnitOfWeight(string labelName, string valueToPick)
        {
            Wait(5);
            //cf.SelectValueFromDropDownWithinGrid(getDropDownWithinGrid(labelName, valueToPick), labelName, valueToPick);
            SelectFromDropDown(SelectionType.selectByValue, getDropDownWithinGrid(labelName, valueToPick), valueToPick);
        }


        public void SelectAssignee(string labelName, string valueToSearch, string valueToPick)
        {
            Wait(5);
            IWebElement PickerInput = driver.FindElement(By.XPath("//div[text()='"+labelName+"']//ancestor::thead//following-sibling::tbody//input[@class='PickerWidget---picker_input PickerWidget---placeholder']"));
            cf.SelectItemFromPickerField(PickerInput, valueToSearch, valueToPick);

        }

        public void SelectCallPurpose(string labelName, string valueToPick)
        {
            cf.SelectValueFromDropDown(labelName, valueToPick);
        }

        public void EnterETC(string labelName, string dateTime)
        {
            EnterText(getSpanTextInputBox(labelName), dateTime);
        }

        public void EnterETD(string labelName, string dateTime)
        {
            EnterText(getSpanTextInputBox(labelName), dateTime);
        }

        public void SubmitQuote(string labelName)
        {
            //---Move to Service Details section-------
            //click on next button
            cf.ClickButtonByLabelName("Next");
            Wait(10);
            cf.ClickButtonByLabelName(labelName);
            Wait(5);
        }

        public IWebElement getSpanTextInputBox (string labelName)
        {
            IWebElement element = driver.FindElement(By.XPath("//span[text()='"+ labelName +"']//parent::div/following-sibling::div//input"));

            return element;
        }

        public IWebElement getTopMenuByLable(string labelName)
        {
            IWebElement element = driver.FindElement(By.XPath("//div[@class='SiteMenuTab---nav_label' and text()='"+labelName+"']"));

            return element;
        }

        public IWebElement getDropDownWithinGrid(string labelName, string index)
        {
            IWebElement webElement = driver.FindElement(By.XPath("//span[text()='"+ labelName +"']//parent::div[1]"));
            return webElement;
        }

        public IWebElement getLabelTextInputBox(string labelName)
        {
            IWebElement webElement = driver.FindElement(By.XPath("//label[text()='" + labelName + "']//parent::div/following-sibling::div//input"));
            return webElement;
        }

        public IWebElement getCheckBoxByLabel(string labelName)
        {
            IWebElement webElement = driver.FindElement(By.XPath("//label[@class='CheckboxGroup---choice_label' and text()='"+ labelName +"']"));
            return webElement;
        }
        public IWebElement getLinkElementByLabel(string labelName)
        {
            IWebElement webElement = driver.FindElement(By.XPath("//a[text()='" + labelName + "']"));
            return webElement;
        }

        public void ClickOnRequestQuoteLink(string labelName)
        {

            //string xPath = "//a[text()='"+ labelName +"']";
            ClickOn(getTopMenuByLable("My Dashboard"));
            Wait(5);
             ClickOn(getLinkElementByLabel(labelName));
            //ClickOn(driver.FindElement(By.XPath(xPath)));

        }

        public void EnterCustomerReferenceNumber(string labelName, string valueToType)
        {
            string xPath = "//label[text()='"+ labelName +"']//parent::div/following-sibling::div//input";
            EnterText((driver.FindElement(By.XPath(xPath))), valueToType);

        }


        public string getQuotationNumberText()
        {
            IWebElement quotationListGrid =driver.FindElement(By.XPath("//span[text()='Quotation List']/parent::div/following-sibling::div//a[1]"));
            string QuoationNumber = quotationListGrid.Text;
            string TrimmedQuotationNumber = QuoationNumber.TrimStart('Q');
            long number = Int64.Parse(TrimmedQuotationNumber);
            string numberconverted = number.ToString();
            int nextNumber = Convert.ToInt32(number) + 1;
            string convertednextNumber = nextNumber.ToString();
            int Pos = QuoationNumber.IndexOf(numberconverted);
            string removedNumber = QuoationNumber.Remove(Pos);
            QuotationNumber = removedNumber + convertednextNumber;
            //Console.WriteLine(nextQuotationNumber);
            return QuotationNumber;
        }
        public void ClickSearchFilterButton(string labelName)
        {
            cf.ClickButtonByLabelName(labelName);
            Wait(5);

        }
        public void SearchByNewlyCreatedQuotation(string labelName)
        {
            EnterText(getLabelTextInputBox(labelName), QuotationNumber);
            Wait(2);
            
        }
        public void OpenTheCreatedQuotation()
        {

            IWebElement NewlyCreatedQuotationLink = driver.FindElement(By.XPath("//span[text()='Quotation List']/parent::div/following-sibling::div//a[text()='"+ QuotationNumber +"']"));
            ClickOn(NewlyCreatedQuotationLink);
            Wait(5);

        }


    }
}