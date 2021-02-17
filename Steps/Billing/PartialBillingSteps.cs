using SpecFlow.BusinessMethods;
using SpecFlow.CommonLibs;
using SpecFlow.Pages;
using SpecFlow.Utilities.Hooks;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class PartialBilling_SelectServiceSChargeSToInvoiceSteps : WebActions
    {
        string Username = "mayank.tripathi@gac.com";
        string BillingPage = "Billing";

        LoginPage loginPage = new LoginPage();
        Dashboard dashboard = new Dashboard();
        CommonFunctions cf = new CommonFunctions();
        BillingScreen billingScreen = new BillingScreen();

        //[Given(@"I am on Billing Dashboard Page")]
        //public void GivenIAmOnBillingDashboardPage()
        //{
        //    loginPage.LoginToApplication(Username);
        //    dashboard.NavigateToPage(BillingPage);
        //}
        
        [Given(@"I am on the Billing Screen")]
        public void GivenIAmOnTheBillingScreen()
        {
            loginPage.LoginToApplication(Username);
            
            dashboard.NavigateToPage(BillingPage);
            cf.ClickTab("Create Billing");
            billingScreen.VerifyCreateBillingPageLoaded("Create Billing");
        }
        
        [When(@"I Click on Start Billing for any of the Jobs in Ready for Billing Status")]
        public void WhenIClickOnStartBillingForAnyOfTheJobsInReadyForBillingStatus()
        {
            cf.ClickTab("Create Billing");
            billingScreen.VerifyCreateBillingPageLoaded("Create Billing");
        }
        
        [When(@"I Select a Customer")]
        public void WhenISelectACustomer()
        {
            //billingScreen.SelectPickerValue("Customer Name", "BLAN", "Blanchard Cat Power Systems");
            billingScreen.SelectInvoiceDate("07/18/2020");
        }
        
        [When(@"I select single Job to be billed")]
        public void WhenISelectSingleJobToBeBilled()
        {
            billingScreen.SelectJob();   
        }
        
        [When(@"I enter all the mandatory details for the Customer")]
        public void WhenIEnterAllTheMandatoryDetailsForTheCustomer()
        {
            
        }
        
        [When(@"I select multiple  Jobs to be Billed")]
        public void WhenISelectMultipleJobsToBeBilled()
        {
            
        }
        
        [When(@"I select Multiple Services and Charges")]
        public void WhenISelectMultipleServicesAndCharges()
        {
            
        }
        
        [When(@"I click on Save")]
        public void WhenIClickOnSave()
        {
            
        }
        
        [When(@"When I select a Customer")]
        public void WhenWhenISelectACustomer()
        {
            
        }
        
        [When(@"And I select single Job to be billed")]
        public void WhenAndISelectSingleJobToBeBilled()
        {
            
        }
        
        [Then(@"I should be able to select checkboxes for different services and charges")]
        public void ThenIShouldBeAbleToSelectCheckboxesForDifferentServicesAndCharges()
        {
            
        }
        
        [Then(@"The Invoice should be saved successfully")]
        public void ThenTheInvoiceShouldBeSavedSuccessfully()
        {
            
        }
        
        [Then(@"All the services and charges for the Selected Job should be checked")]
        public void ThenAllTheServicesAndChargesForTheSelectedJobShouldBeChecked()
        {
            
        }
        
        [Then(@"Verify the Total Value of the Invoice is automatically calculated")]
        public void ThenVerifyTheTotalValueOfTheInvoiceIsAutomaticallyCalculated()
        {
            
        }
        
        [Then(@"I should be navifated to the Billing Dashboard Page")]
        public void ThenIShouldBeNavifatedToTheBillingDashboardPage()
        {
            
        }
        
        [Then(@"The Status of the Job should be set as (.*)")]
        public void ThenTheStatusOfTheJobShouldBeSetAs(string p0)
        {
            
        }
    }
}
