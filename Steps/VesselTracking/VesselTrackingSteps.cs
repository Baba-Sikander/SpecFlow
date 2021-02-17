
using NUnit.Framework;
//using NUnit.Framework.StringAssert;
using SpecFlow.BusinessMethods;
using SpecFlow.CommonLibs;
using SpecFlow.Pages;
using SpecFlow.Pages.Job;
using SpecFlow.Pages.VesselTracking;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class VesselTrackingSteps :WebActions
    {
        Dashboard dashboard = new Dashboard();
        CommonFunctions cf = new CommonFunctions();

        JobSetup jobSetup = new JobSetup();
        JobDetails jobDetails = new JobDetails();
        ServicesAndCharges servicesAndCharges = new ServicesAndCharges();
        
        VT_Summary vtSummary = new VT_Summary();
        Job_Dashboard job_dashboard = new Job_Dashboard();


        string Username = EnvironVariables.username;
        string BillingPage = "Job";
        static string LocalJobNo;
        static string localJobOPId;
        


        [Given(@"I navigate to the Job module")]
        public void GivenINavigateToTheJobModule()
        {
            dashboard.NavigateToPage(BillingPage);
        }

        
        [Given(@"I click on Create a Job")]
        public void GivenIClickOnCreateAJob()
        {
            cf.ClickTab("Create Job");
        }
        [Given(@"I create a new Job for ""(.*)""")]
        public void GivenICreateANewJobFor(string opProcess)
        {
            cf.ClickTab("Create Job");
            jobSetup.EnterJobSetupDetails("Ship Agency", "Vessel Tracking");
            jobDetails.EnterCustAndVesselDetails("Blanchard Cat Power Systems", "Adriatic - 9724257");
            servicesAndCharges.ClickCreate();

            //if (opProcess.ToLower().Contains("vessel tracking"))
            //{
            //}
        }

        [Given(@"I create a new Job")]
        public void GivenIHaveCreatedANewJob()
        {
            cf.ClickTab("Create Job");
            jobSetup.EnterJobSetupDetails("Ship Agency", "Vessel Tracking");
            jobDetails.EnterCustAndVesselDetails("Blanchard Cat Power Systems", "Adriatic - 9724257");
            //servicesCharges.ClickLabel();
            //servicesCharges.EnterServicesAndCharges();
            servicesAndCharges.ClickCreate();
        }
        
        [When(@"I select the Business Product as ""(.*)"" and Operational Process as ""(.*)""")]
        public void WhenISelectTheBusinessProductAsAndOperationalProcessAs(string p0, string p1)
        {
            jobSetup.EnterJobSetupDetails(p0,p1);
        }
        
        [When(@"I click on Next")]
        public void WhenIClickOnNext()
        {
            
        }
        
        [When(@"I enter the Customer and Vessel Details")]
        public void WhenIEnterTheCustomerAndVesselDetails()
        {
            jobDetails.EnterCustAndVesselDetails("Blanchard Cat Power Systems", "Adriatic - 9724257");
            
        }
        
        [When(@"I enter the Services and Charges")]
        public void WhenIEnterTheServicesAndCharges()
        {
            servicesAndCharges.ClickLabel();
            servicesAndCharges.EnterServicesAndCharges();
        }
        
        [When(@"I click on Create")]
        public void WhenIClickOnCreate()
        {
            servicesAndCharges.ClickCreate();
        }
        
        [When(@"I click on the Local Job ID")]
        public void WhenIClickOnTheLocalJobID()
        {
            servicesAndCharges.CaptureJobID();
            //servicesCharges.ClickLocalJob();
        }
        
        [Then(@"the Job should be created with a new Job ID")]
        public void ThenTheJobShouldBeCreatedWithANewJobID()
        {
            job_dashboard.ClickLocalJob();
        }
        
        [Then(@"I should be able to click on Job ID to view the summary")]
        public void ThenIShouldBeAbleToClickOnJobIDToViewTheSummary()
        {
            job_dashboard.ClickOperProcessLink();
        }
        
        [Then(@"I should be navigated to the Summary view in a new Tab")]
        public void ThenIShouldBeNavigatedToTheSummaryViewInANewTab()
        {
            job_dashboard.VerifyPageTitle(localJobOPId,"Vessel Tracking");
        }
        
        [Then(@"Verify the Page Label is ""(.*)""")]
        public void ThenVerifyThePageLabelIs(string p0)
        {
            job_dashboard.VerifyPageTitle(localJobOPId,"Vessel Tracking");
        }
        
        [Then(@"Verify the Page Sections are Vessel Tracking Details, Services & Charges, Notification Group Settings, Forecasting and Events")]
        public void ThenVerifyThePageSectionsAreVesselTrackingDetailsServicesChargesNotificationGroupSettingsForecastingAndEvents()
        {
            servicesAndCharges.VerifySectionHeaders("Services & Charges");
            servicesAndCharges.VerifySectionHeaders("Notification Group Settings");
            servicesAndCharges.VerifySectionHeaders("Forecasting");
            servicesAndCharges.VerifySectionHeaders("Events");
        }

        [When(@"I navigate to the Job Summary Page")]
        public void WhenINavigateToTheJobSummaryPage()
        {
            job_dashboard.ClickLocalJob();
            job_dashboard.ClickOperProcessLink();
           
            //job_dashboard.AccessOpSummaryPage(localJobOPId);

            job_dashboard.VerifyPageTitle(localJobOPId,"Vessel Tracking");
        }

        [When(@"I click on Documents tab")]
        public void WhenIClickOnDocumentsTab()
        {
            vtSummary.ClickTabOnSummary("Documents");
        }

        [When(@"I navigate to the Event section")]
        public void WhenINavigateToTheEventSection()
        {
            
        }

        [When(@"I convert ETA, ETB and ETC to ATA, ATB and ATC respectively")]
        public void WhenIConvertETAETBAndETCToATAATBAndATCRespectively()
        {
            vtSummary.EtConvertToActual();
            vtSummary.EtConvertToActual();
            vtSummary.EtConvertToActual();
        }

        [When(@"I add all the Events")]
        public void WhenIAddAllTheEvents()
        {
            //Events
            vtSummary.accessEvents(" Events");
            vtSummary.addEvent("Events");

            vtSummary.enterEventDate("10/15/2020");
            vtSummary.enterEventTime("6:00 AM");
            vtSummary.enterEventRemarks("None");
            vtSummary.enterEventName("Pilot On Board");

            ////Add Stoppage and Remarks
            vtSummary.accessEvents("Stoppage And Remarks");
            vtSummary.addEvent("Stoppage And Remarks");

           
            vtSummary.EnterEventStartDate("10/25/2020");
            vtSummary.EnterEventStartTime("6:00 AM");
            vtSummary.EnterEventEndDate("10/26/2020");
            vtSummary.EnterEventEndTime("6:00 AM");
            //vtSummary.enterEventRemarks("None");
            vtSummary.enterEventName("Suspended Load Due to Grade Change");

            //Add Bunkers
            vtSummary.accessEvents("Bunkers");
            vtSummary.addEvent("Bunkers");

            vtSummary.SelectFuelType("HSFO");
            vtSummary.EnterQuantity("2");
            vtSummary.enterEventName("Arrival");
        }

        [When(@"I click on Update")]
        public void WhenIClickOnUpdate()
        {
            vtSummary.updatePage();
        }

        [When(@"I Create SOF")]
        public void WhenICreateAnSOF()
        {
            vtSummary.createSOF();
            vtSummary.enterCommentsInParagraph("Please Approve");
            vtSummary.enterCaptainEmail(Username);
            vtSummary.UploadFile("C:\\Users\\lko33345\\Documents\\AutomationFramework\\pegasus_Specflow\\SpecFlow\\Assets\\AgentSign.png");
            vtSummary.sendMail();
        }

        [When(@"I complete the Captain's Approval")]
        public void WhenICompleteTheCaptainSApproval()
        {
            vtSummary.captainApproval();
            vtSummary.ClickPreviewSOF();
            vtSummary.UploadFile("C:\\Users\\lko33345\\Documents\\AutomationFramework\\pegasus_Specflow\\SpecFlow\\Assets\\CaptainSignature.png");
            vtSummary.clickProceedCheckBox();
            vtSummary.clickApproveCaptain();

        }

        [When(@"I complete the Agent's Review")]
        public void WhenICompleteTheAgentSReview()
        {
            vtSummary.ClickAgentsReview();
            vtSummary.ClickPreviewSOF();
            vtSummary.clickProceedCheckBox();
            vtSummary.AcceptCaptainsApproval();
        }

        [When(@"I convert the ETD to ATD")]
        public void WhenIConvertTheETDToATD()
        {
            vtSummary.EtConvertToActual();
            vtSummary.updatePage();
        }

        [Then(@"I should be able to add Vessel Documents")]
        public void ThenIShouldBeAbleToAddVesselDocuments()
        {
            vtSummary.UploadPreDepartureDoc("C:\\Users\\lko33345\\Documents\\AutomationFramework\\pegasus_Specflow\\SpecFlow\\Assets\\Predeparture.docx");
            vtSummary.ClickSave();
        }

        [Then(@"I should be able to add Events")]
        public void ThenIShouldBeAbleToAddEvents()
        {
            vtSummary.accessEvents(" Events");
            vtSummary.addEvent("Events");
            vtSummary.enterEventDate("10/15/2020");
            vtSummary.enterEventTime("6:00 AM");
            vtSummary.enterEventRemarks("None");
            vtSummary.enterEventName("Pilot On Board");
        }

        [Then(@"I should be able to add Stoppages and Remarks")]
        public void ThenIShouldBeAbleToAddStoppagesAndRemarks()
        {
            vtSummary.accessEvents("Stoppage And Remarks");
            vtSummary.addEvent("Stoppage And Remarks");
            vtSummary.EnterEventStartDate("10/25/2020");
            vtSummary.EnterEventStartTime("6:00 AM");
            vtSummary.EnterEventEndDate("10/26/2020");
            vtSummary.EnterEventEndTime("6:00 AM");
            //vtSummary.enterEventRemarks("None");
            vtSummary.enterEventName("Suspended Load Due to Grade Change");
        }

        [Then(@"I should be able to add Bunkers")]
        public void ThenIShouldBeAbleToAddBunkers()
        {
            
        }

        [Then(@"I should be able to add Draft")]
        public void ThenIShouldBeAbleToAddDraft()
        {
            
        }

        [Then(@"I should be able to add Tugs")]
        public void ThenIShouldBeAbleToAddTugs()
        {
            
        }

        [Then(@"I should be able to add Cargo Details")]
        public void ThenIShouldBeAbleToAddCargoDetails()
        {
            
        }

        [Then(@"The OP status should be moved to Vessel Departed")]
        public void ThenTheOPStatusShouldBeMovedToVesselDeparted()
        {
            //Verify Screenshot
        }

        [Given(@"I am on Job dashboard")]
        public void GivenIAmOnJobDashboard()
        {
            //  StringAssert.AreEqualIgnoringCase
            StringAssert.AreEqualIgnoringCase("CURRENT JOBS", job_dashboard.GetCurrentJobs());
            
        }

        [When(@"I search for Vessel Tracking Jobs")]
        public void WhenISearchForVesselTrackingJobs()
        {
            job_dashboard.SearchJob("Vessel Tracking");
            job_dashboard.ClickSearchJob();
           

        }

        [When(@"I select an open Job created by ""(.*)""")]
        public void WhenISelectAnOpenJobCreatedBy(string user)
        {
          LocalJobNo= job_dashboard.SelectOpenJob(user);
           

        }

        [When(@"I access operational process summary")]
        public void WhenIAccessOperationalProcessSummary()
        {
           localJobOPId= job_dashboard.getProcessRefId(LocalJobNo);

            job_dashboard.AccessOpSummaryPage(localJobOPId);
        }

        [When(@"I create New Job for Vessel Tracking op process")]
        public void WhenICreateNewJobForVesselTrackingOpProcess()
        {
            
        }

        [Then(@"Local Job Id and Operational Id should be created")]
        public void ThenLocalJobIdAndOperationalIdShouldBeCreated()
        {
            
        }

        [Then(@"If I access Summary tab of Vessel Tracking Ops screen")]
        public void ThenIfIAccessSummaryTabOfVesselTrackingOpsScreen()
        {
            
        }

        [Then(@"I should be able to update forecasting information\(ETA, ETB\)")]
        public void ThenIShouldBeAbleToUpdateForecastingInformationETAETB()
        {
            
        }

        [Then(@"I should be able to Convert and update Actual information\(ATA, ATB\)")]
        public void ThenIShouldBeAbleToConvertAndUpdateActualInformationATAATB()
        {
            
        }

        [When(@"The Captain Rejects the SOF")]
        public void WhenTheCaptainRejectsTheSOF()
        {
            
        }

        [When(@"Sends back to Agent")]
        public void WhenSendsBackToAgent()
        {
            
        }

        [Then(@"The Agent's Review screen should be displayed with ""(.*)""")]
        public void ThenTheAgentSReviewScreenShouldBeDisplayedWith(string p0)
        {
            
        }

        [Then(@"I can resend the SOF to the Captain")]
        public void ThenICanResendTheSOFToTheCaptain()
        {
            
        }

        [Then(@"The Captain's Approval button is displayed and enabled")]
        public void ThenTheCaptainSApprovalButtonIsDisplayedAndEnabled()
        {
            
        }

        [When(@"I return the SOF back to Captain")]
        public void WhenIReturnTheSOFBackToCaptain()
        {
            
        }

        [When(@"I change the Estimated date and time")]
        public void WhenIChangeTheEstimatedDateAndTime()
        {
            
        }

        [When(@"I convert it to actual")]
        public void WhenIConvertItToActual()
        {
            
        }

        [When(@"I navigate to the Event Tab")]
        public void WhenINavigateToTheEventTab()
        {
            
        }

        [Then(@"An event should be added to the Event List")]
        public void ThenAnEventShouldBeAddedToTheEventList()
        {
            
        }

        [Then(@"The Event Details remark should be displayed as ""(.*)""")]
        public void ThenTheEventDetailsRemarkShouldBeDisplayedAs(string p0)
        {
            
        }

    }
}
