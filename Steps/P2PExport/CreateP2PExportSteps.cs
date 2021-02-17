using SpecFlow.BusinessMethods;
using SpecFlow.Pages;
using SpecFlow.Utilities.TestDataUtil;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow
{
    [Binding]
    public class CreateP2PExportSteps
    {
        string Username = "majeeth.shaik@gac.com";
        string JobPage = "Job";

        LoginPage loginPage = new LoginPage();
        Dashboard dashboard = new Dashboard();
        CommonFunctions cf = new CommonFunctions();
        JobDashboard jobDashboard = new JobDashboard();


        [Given(@"I am on job Dashboard Page")]
        public void GivenIAmOnJobDashboardPage()
        {
            loginPage.LoginToApplication(Username);
            dashboard.NavigateToPage(JobPage);
        }



    }
}
