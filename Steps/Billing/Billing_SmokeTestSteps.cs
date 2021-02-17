using SpecFlow.BusinessMethods;
using SpecFlow.Pages;
using SpecFlow.Pages.VesselTracking;
using SpecFlow.Utilities.TestDataUtil;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class Billing_SmokTestSteps
    {

        string Username = "mayank.tripathi@gac.com";
        string BillingPage = "Job";

        LoginPage loginPage = new LoginPage();
        Dashboard dashboard = new Dashboard();
        CommonFunctions cf = new CommonFunctions();
        BillingScreen billingScreen = new BillingScreen();
        BillingDashboard billingDashboard = new BillingDashboard();
        BillingSummary billingSummary = new BillingSummary();

        VT_ServicesCharges servicesCharges = new VT_ServicesCharges();
        CreateJob createJob = new CreateJob();

        XMLTestDataReader testData = new XMLTestDataReader();

        [Given(@"I am on Billing Dashboard")]
        public void GivenIAmOnBillingDashboard()
        {
            loginPage.LoginToApplication(Username);
            dashboard.NavigateToPage(BillingPage);
            cf.ClickTab("Create Job");
            createJob.EnterJobSetupDetails("Ship Agency", "Vessel Tracking");
            createJob.EnterCustAndVesselDetails("Blanchard Cat Power Systems", "Adriatic");
            servicesCharges.ClickLabel();
            servicesCharges.EnterServicesAndCharges();
        }
        
        [When(@"I Navigate to Ready for Billing Tab")]
        public void WhenINavigateToReadyForBillingTab()
        {
            //billingDashboard.ClickBillingDashboardTab("Ready for Billing");
        }
        
        [Then(@"I should be able to see following filters - Customer, Job Number, Billing Priority and Business Area")]
        public void ThenIShouldBeAbleToSeeFollowingFilters_CustomerJobNumberBillingPriorityAndBusinessArea()
        {
            
        }
        
        [Then(@"I should be able to see the Customers in the Grid")]
        public void ThenIShouldBeAbleToSeeTheCustomersInTheGrid()
        {
            
        }
        
        [Then(@"I should be able to see the count of Customers on Ready for Billing and Billing Progress")]
        public void ThenIShouldBeAbleToSeeTheCountOfCustomersOnReadyForBillingAndBillingProgress()
        {
            
        }
        
        [Then(@"I should be able to see the count of documents on the Invoices tab")]
        public void ThenIShouldBeAbleToSeeTheCountOfDocumentsOnTheInvoicesTab()
        {
            
        }

        [When(@"I Navigate to Billing in Progress Tab")]
        public void WhenINavigateToBillingInProgressTab()
        {
            //billingDashboard.ClickBillingDashboardTab("Billing in Progress");
        }

        [Then(@"I should be able to see following filters - Customer, Job Number, Transaction Number, Billing Party and Transaction To and From Date")]
        public void ThenIShouldBeAbleToSeeFollowingFilters_CustomerJobNumberTransactionNumberBillingPartyAndTransactionToAndFromDate()
        {
            
        }

        [When(@"I Navigate to Invoices Tab")]
        public void WhenINavigateToInvoicesTab()
        {
            billingDashboard.ClickBillingDashboardTab("Invoices");
        }

        [Then(@"I should be able to see following filters - Customer, Invoice Number, Job Number, Billing Party, Invoice Date To and From, Due Date To and From, Invoice Type and Invoice Status")]
        public void ThenIShouldBeAbleToSeeInvoiceFilters()
        {

        }
    }
}
