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
    class JobDetails : WebActions
    {
        readonly CommonFunctions cf = new CommonFunctions();

        IWebElement Customer_Name => driver.FindElement(By.XPath("//input[contains(@aria-labelledby,'_column0_header')]"));
        IWebElement Customer_Ref => driver.FindElement(By.XPath("//input[contains(@aria-labelledby,'_column1_header')]"));
        IWebElement Sales_Rep => driver.FindElement(By.XPath("//input[contains(@aria-labelledby,'_column2_header')]"));
        IWebElement NominatedBy => driver.FindElement(By.XPath("//input[contains(@aria-labelledby,'_column3_header')]"));


        //Vessel Details
        IWebElement VesselName => driver.FindElement(By.XPath("//*[text()='Vessel']/../following-sibling::div/div/div/input"));

        IWebElement Terminal => driver.FindElement(By.XPath("//*[text()='Terminal']/../following-sibling::div/div/div/input"));
        IWebElement Port => driver.FindElement(By.XPath("//*[text()='Port']/../following-sibling::div/div/div/input"));
        IWebElement Berth => driver.FindElement(By.XPath("//*[text()='Berth']/../following-sibling::div/div/div/input"));
        IWebElement ETA_Date => driver.FindElement(By.XPath("//*[text()='ETA']/../following-sibling::div/div/div/div/input[contains(@aria-describedby,'datePicker_placeholder')]"));
        IWebElement ETB_Date => driver.FindElement(By.XPath("//*[text()='ETB']/../following-sibling::div/div/div/div/input[contains(@aria-describedby,'datePicker_placeholder')]"));
        IWebElement ETC_Date => driver.FindElement(By.XPath("//*[text()='ETC']/../following-sibling::div/div/div/div/input[contains(@aria-describedby,'datePicker_placeholder')]"));
        IWebElement ETD_Date => driver.FindElement(By.XPath("//*[text()='ETD']/../following-sibling::div/div/div/div/input[contains(@aria-describedby,'datePicker_placeholder')]"));
        
        
        //Export Elements
        IWebElement ModeOfTransportSea => driver.FindElement(By.XPath("//span[text()='Mode of Transport']/../following-sibling::div//input[@type='radio' and @value='Sea']/following::label"));

        IWebElement ModeOfTransportAir => driver.FindElement(By.XPath("//span[text()='Mode of Transport']/../following-sibling::div//input[@type='radio' and @value='Air']/following::label"));
        IWebElement BookingTypePicker => driver.FindElement(By.XPath("//span[text()='Booking Type']/../following-sibling::div//div[@role='listbox']"));
        IWebElement Origin => driver.FindElement(By.XPath("//span[text()='Origin']/../following-sibling::div//input[contains(@class,'PickerWidget---picker_input')]"));
        IWebElement Destination => driver.FindElement(By.XPath("//span[text()='Destination']/../following-sibling::div//input[contains(@class,'PickerWidget---picker_input')]"));
        IWebElement CustomerPartiesSection => driver.FindElement(By.XPath("//p[text()='Customer']/../following-sibling::td//input"));
        IWebElement P2PSectionHeader => driver.FindElement(By.XPath("//div[@class='BoxLayout---box_label'][text()='Port To Port Export']"));



        /* 
         * Shipping Methods - Ship Agency, Hub etc
         */
        public void EnterCustAndVesselDetails(string cust_Name, string vesselName)
        {
            cf.SelectValueFromPicker(Customer_Name, cust_Name, cust_Name);
            Wait(1);
            cf.SelectValueFromPicker(VesselName, "Adriatic", vesselName);
            Wait(1);
            ClickOn(JobSetup.NextButton);
            PageSync();
            Wait(10);
            AssertTrue(ServicesAndCharges.CreateButton.Displayed, "Did not navigate to Services and Charges screen.");
        }

        public void enterCustomerName(string cust_Name)
        {
            cf.SelectValueFromPicker(Customer_Name, cust_Name, cust_Name);
        }
        public void enterCustomerRefNo(string customerRefNo)
        {
            EnterText(Customer_Ref, customerRefNo);
        }

        public void enterSalesRepresentative(string salesRepName)
        {
            cf.SelectValueFromPicker(Sales_Rep, salesRepName, salesRepName);
        }
        public void enterNominatedBy(string nominatedUser)
        {
            cf.SelectValueFromPicker(NominatedBy, nominatedUser, nominatedUser);
        }

        public void enterVessel(string vesselName)
        {
            cf.SelectValueFromPicker(VesselName, vesselName, vesselName);
        }
        public void enterPort(string portname)
        {
            cf.SelectValueFromPicker(Port, portname, portname);
        }
        public void enterTerminal(string terminalName)
        {
            cf.SelectValueFromPicker(Port, terminalName, terminalName);
        }
        public void enterBerth(string berthName)
        {
            cf.SelectValueFromPicker(Port, berthName, berthName);
        }



        /* 
          * Logistics Methods - Freight, WH-IN, WH-OUT etc.
          */

        public void selectCustomerFromPartiesSection(string customerName)
        {
            cf.SelectValueFromPicker(CustomerPartiesSection, customerName, customerName);
        }
        public void selectModeofTransportAir()
        {
            cf.ClickOn(ModeOfTransportAir);
        }
        public void selectModeofTransportSea()
        {
            cf.ClickOn(ModeOfTransportSea);
        }
        public void selectBookingType(string bookingtype)
        {
            cf.SelectValueFromDropDown(BookingTypePicker, bookingtype);
        }
        public void selectOrigin(string originCountry)
        {
            cf.SelectValueFromPicker(Origin, originCountry, originCountry);
        }
        public void selectDestination(string destinationCountry)
        {
            cf.SelectValueFromPicker(Destination, destinationCountry, destinationCountry);
        }
        public void expandSection()
        {
            cf.ClickOn(P2PSectionHeader);
            Wait(3);
        }
        public void clickNext()
        {
            cf.ClickOn(JobSetup.NextButton);
            Wait(10);
        }
    }
}
