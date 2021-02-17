using SpecFlow.BusinessMethods;
using SpecFlow.CommonLibs;
using SpecFlow.Pages;
using SpecFlow.Utilities.TestDataUtil;
using TechTalk.SpecFlow;

namespace SpecFlow
{
    [Binding]
    public class CreateBillingSteps : WebActions
    {
        string Username = "majeeth.shaik@gac.com";
        string BillingPage = "Billing";

        LoginPage loginPage = new LoginPage();
        Dashboard dashboard = new Dashboard();
        CommonFunctions cf = new CommonFunctions();
        BillingScreen billingScreen = new BillingScreen();
        BillingDashboard billingDashboard = new BillingDashboard();
        BillingSummary billingSummary = new BillingSummary();

        XMLTestDataReader testData = new XMLTestDataReader();

        
        [Given(@"I am on Billing Dashboard Page")]
        public void GivenIAmOnBillingDashboardPage()
        {
            loginPage.LoginToApplication(Username);
            dashboard.NavigateToPage(BillingPage);
        }        

        [When(@"I select Jobs for a customer to Bill")]
        public void WhenISelectJobsForACustomerToBill()
        {
            string JobNo = testData.ReadData("JobNumber");

            
            billingDashboard.SelectBusinessAreaFilter("Shipping");
            Wait(5);
            cf.BillingDashboard_SearchFilter("Job Number", BillingDashboard.SearchJobNumber, JobNo);
            Wait(5);
            billingDashboard.SelectSingleJobToBill("SINGLE");
        }

        [When(@"I enter the Customer and Billing Details")]
        public void WhenIEnterTheCustomerAndBillingDetails()
        {
            //Billing Details
            billingScreen.SelectInvoiceDate("08/02/2020");
            cf.SelectItemFromPickerField("GAC Office", "Dubai", "Gulf Agency Company (Dubai) L.L.C.");
            cf.SelectItemFromPickerField("Billing Currency", "AED", "AED");
            cf.SelectItemFromPickerField("Billing Party", "JNJ", "JNJ Shipping (Seoul)");
            Wait(5);
        }

        [When(@"I enter the services and charges for the selected Jobs")]
        public void WhenIEnterTheServicesAndChargesForTheSelectedJobs()
        {
            string ServiceName = testData.ReadData("ServiceName");
            billingScreen.SelectServices(ServiceName);
            billingScreen.EnterCharges();
        }

        [When(@"I check the checkbox for the charge")]
        public void WhenICheckTheCheckboxForTheCharge()
        {
            billingScreen.SelectServicesCheckbox();
        }

        [When(@"I click on View Summary")]
        public void WhenIClickOnViewSummary()
        {
            billingScreen.ClickViewSummary();
        }

        [Then(@"I should be navigated to Billing Summary screen")]
        public void ThenIShouldBeNavigatedToBillingSummaryScreen()
        {
            billingSummary.VerifyBillingSummaryPageDisplayed();
        }

        [Then(@"Print Draft and Final Button should be displayed")]
        public void ThenPrintDraftAndFinalButtonShouldBeDisplayed()
        {
            billingSummary.VerifyPrintDraftAndFinalButtonDisplayed();
            //loginPage.Logout();
        }
    }
}
