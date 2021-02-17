using SpecFlow.BusinessMethods;
using SpecFlow.Pages;
using SpecFlow.Pages.VesselTracking;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class PortToPortSteps
    {
        string Username = "majeeth.shaik@gac.com";
        string JobPage = "Job";

        LoginPage loginPage = new LoginPage();
        Dashboard dashboard = new Dashboard();
        CommonFunctions cf = new CommonFunctions();
        P2P_ServicesCharges servicesCharges = new P2P_ServicesCharges();
        CreateJob createJob = new CreateJob();


        [Given(@"I am on Job application")]
        public void GivenIAmOnJobApplication()
        {
            loginPage.LoginToApplication(Username);
            dashboard.NavigateToPage(JobPage);
        }



        [Given(@"go to job setup page")]
        public void GivenGoToJobSetupPage()
        {
            cf.ClickTab("Create Job");
        }


        [When(@"I select Business Product as ""(.*)"" and Operational Process as ""(.*)""")]
        public void WhenISelectBusinessProductAsAndOperationalProcessAs(string p0, string p1)
        {
            createJob.EnterJobSetupDetails(p0,p1);
        }

        [When(@"I enter the Customer Details")]
        public void WhenIEnterTheCustomerDetails()
        {
            createJob.enterCustomerName("Blanchard Cat Power Systems");
            createJob.enterCustomerRefNo("Test Cust Ref 001");
            createJob.enterSalesRepresentative("Majeeth Shaik");
            createJob.enterNominatedBy("Boreray Shipping Limited");

        }


        [When(@"I enter the Export instructions for Air Direct")]
        public void WhenIEnterTheExportInstructionsforAirDirect()
        {
            createJob.expandSection();
            createJob.selectCustomerFromPartiesSection("Blanchard Cat Power Systems");
            createJob.selectModeofTransportAir();
            createJob.selectBookingType("Direct");
            createJob.selectOrigin("Dubai");
            createJob.selectDestination("Singapore");
            createJob.clickNext();
            

        }
        [When(@"I enter the Export instructions for Air House")]
        public void WhenIEnterTheExportInstructionsforAirHouse()
        {
            createJob.expandSection();
            createJob.selectCustomerFromPartiesSection("Blanchard Cat Power Systems");
            createJob.selectModeofTransportAir();
            createJob.selectBookingType("House");
            createJob.selectOrigin("Dubai");
            createJob.selectDestination("Singapore");
            createJob.clickNext();


        }
        [When(@"I enter the Export instructions for Sea Direct")]
        public void WhenIEnterTheExportInstructionsforSeaDirect()
        {
            createJob.expandSection();
            createJob.selectCustomerFromPartiesSection("Blanchard Cat Power Systems");
            createJob.selectModeofTransportSea();
            createJob.selectBookingType("Direct");
            createJob.selectOrigin("Dubai");
            createJob.selectDestination("Singapore");
            createJob.clickNext();


        }
        [When(@"I enter the Export instructions for Sea House")]
        public void WhenIEnterTheExportInstructionsforSeaHouse()
        {
            createJob.expandSection();
            createJob.selectCustomerFromPartiesSection("Blanchard Cat Power Systems");
            createJob.selectModeofTransportSea();
            createJob.selectBookingType("House");
            createJob.selectOrigin("Dubai");
            createJob.selectDestination("Singapore");
            createJob.clickNext();


        }

        [When(@"I enter the Services and Charges for Port to Port Export")]
        public void WhenIEnterTheServicesAndChargesForPorttoPortExport()
        {
            servicesCharges.ClickLabel();
            servicesCharges.EnterServicesAndCharges();
        }



    }
}
