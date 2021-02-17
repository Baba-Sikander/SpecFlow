using SpecFlow.BusinessMethods;
using SpecFlow.Pages;
using SpecFlow.Utilities.TestDataUtil;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow
{
    [Binding]
    public class CreateQuotationSteps
    {
        string Username = "majeeth.shaik@gac.com";
        string QuotationPage = "Quotation";

        LoginPage loginPage = new LoginPage();
        Dashboard dashboard = new Dashboard();
        CommonFunctions cf = new CommonFunctions();
        QuotationDashboard quotationDashboard = new QuotationDashboard();
        

        [Given(@"I am on my Dashboard")]
        public void GivenIAmOnMyDashboard()
        {
            loginPage.LoginToApplication(Username);
            dashboard.NavigateToPage(QuotationPage);
        }
        [Given(@"I get the last successful quotation number")]
        public void GivenIGetTheLastSuccessfulQuotationNumber()
        {
            quotationDashboard.collectTheLastQuotationNumber();
        }

        [When(@"I click on Create New Quote")]
        public void WhenIClickOnCreateNewQuote()
        {
            quotationDashboard.ClickOnRequestQuoteLink(" Create New Quote");
        }
        [When(@"I enter all quotation setup details")]
        public void WhenIEnterAllQuotationSetupDetails()
        {

            quotationDashboard.EnterAllDetailsQuotationSetupDetails();


        }
        [When(@"I select commercial service as vesel call")]
        public void WhenISelectCommercialServiceAsVeselCall()
        {
            quotationDashboard.SelectCommercialServiceByValue("Vessel Call");
            
        
        }

        [When(@"I select commercial service as Door to Door")]
        public void WhenISelectCommercialServiceAsDoorToDoor()
        {
            quotationDashboard.SelectCommercialServiceByValue("Door To Door");
        }

        [When(@"I select commercial service as Crew Change")]
        public void WhenISelectCommercialServiceAsCrewChange()
        {
            quotationDashboard.SelectCommercialServiceByValue("Crew Change");
        }

        [When(@"I select assign agents")]
        public void WhenISelectAssignAgents()
        {
            quotationDashboard.SelectAssigneeForVesselCall();
        }

        [When(@"I enter Vessel and Voyage detais")]
        public void WhenIEnterVesselAndVoyageDetais()
        {
            quotationDashboard.EnterVesselAndVoyageDetailsOfVesselCall();
        }
        [When(@"I enter crew details of the vessel call")]
        public void WhenIEnterCrewDetailsOfTheVesselCall()
        {
            quotationDashboard.EnterCrewDetailsOfVesselCall();
        }

        [When(@"I enter cargo details of vessel call")]
        public void WhenIEnterCargoDetailsOfVesselCall()
        {
            quotationDashboard.EnterCargoDetailsOfVesselCall();
        }


        [When(@"I save the quote")]
        public void WhenISaveTheQuote()
        {
            quotationDashboard.SubmitQuote("SUBMIT");
        }
        [Then(@"I should be able to see the quote in dashboard")]
        public void ThenIShouldBeAbleToSeeTheQuoteInDashboard()
        {
            quotationDashboard.VerifyCreatedQuotation();
        }

        [Then(@"I should be able open the created quotation search by Quotation Number")]
        public void ThenIShouldBeAbleOpenTheCreatedQuotationSearchByQuotationNumber()
        {
            quotationDashboard.SearchAndOpenCreatedQuotation();
        }

    }
}
