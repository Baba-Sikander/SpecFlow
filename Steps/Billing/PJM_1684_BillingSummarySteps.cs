using SpecFlow.BusinessMethods;
using SpecFlow.CommonLibs;
using SpecFlow.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class PJM_1684_BillingSummarySteps : WebActions
    {
        string Username = "mayank.tripathi@gac.com";
        string BillingPage = "Billing";

        LoginPage loginPage = new LoginPage();
        Dashboard dashboard = new Dashboard();
        CommonFunctions cf = new CommonFunctions();
        BillingScreen billingScreen = new BillingScreen();
        BillingDashboard billingDashboard = new BillingDashboard();


        [Given(@"User is on the Billing Dashboard Screen")]
        public void GivenUserIsOnTheBillingDashboardScreen()
        {
            loginPage.LoginToApplication(Username);

            dashboard.NavigateToPage(BillingPage);
            Wait(5);
;       }
        
        [Given(@"User is on the Billing Screen")]
        public void GivenUserIsOnTheBillingScreen()
        {
            
        }
        
        //[When(@"User Clicks on \+ icon for any customer")]
        //public void WhenUserClicksOnIconForAnyCustomer()
        //{
        //    billingDashboard.SelectSingleJobToBill("");
        //    billingScreen.SelectIvoiceDate("07/18/2020");
        //}
        
        [When(@"Clicks on a checkbox for a Job")]
        public void WhenClicksOnACheckboxForAJob()
        {
            
        }
        
        [When(@"Enters the Billing Details")]
        public void WhenEntersTheBillingDetails()
        {
            
        }
        
        [When(@"Enters the Customer Details")]
        public void WhenEntersTheCustomerDetails()
        {
            
        }
        
        [When(@"Selects single Service and multiple Charges fron the Line Items List")]
        public void WhenSelectsSingleServiceAndMultipleChargesFronTheLineItemsList()
        {
            
        }
        
        [When(@"Enters the Charge Details")]
        public void WhenEntersTheChargeDetails()
        {
            
        }
        
        [When(@"Clicks on Save")]
        public void WhenClicksOnSave()
        {
            
        }
        
        [When(@"Clicks on View Summary")]
        public void WhenClicksOnViewSummary()
        {
            
        }
        
        [When(@"User selects a Customer")]
        public void WhenUserSelectsACustomer()
        {
            
        }
        
        [When(@"Clicks on multiple checkboxes to select Jobs")]
        public void WhenClicksOnMultipleCheckboxesToSelectJobs()
        {
            
        }
        
        [Then(@"Verify the GAC Company Details and Bank Details are displayed")]
        public void ThenVerifyTheGACCompanyDetailsAndBankDetailsAreDisplayed()
        {
            
        }
        
        [Then(@"The Billing Header section have following fields - Billing Party, Customer Name, Customer Reference Number, Email Address, Phone Number, Address Line (.*), Address Line (.*), City/Town, Country")]
        public void ThenTheBillingHeaderSectionHaveFollowingFields_BillingPartyCustomerNameCustomerReferenceNumberEmailAddressPhoneNumberAddressLineAddressLineCityTownCountry(int p0, int p1)
        {
            
        }
        
        [Then(@"The Payment Term and the selected Job Number on the Billing Summary Page")]
        public void ThenThePaymentTermAndTheSelectedJobNumberOnTheBillingSummaryPage()
        {
            
        }
        
        [Then(@"The Job Details Table for following columns - Job Number, Operational Process, Services/Charges, Supplier Name, Quantity, UOM, Unit Price, Billing Amount")]
        public void ThenTheJobDetailsTableForFollowingColumns_JobNumberOperationalProcessServicesChargesSupplierNameQuantityUOMUnitPriceBillingAmount()
        {
            
        }
    }
}
