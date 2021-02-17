using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using SpecFlow.CommonLibs;
using SpecFlow.Utilities.ReportUtil;
using SpecFlow.Utilities.TestDataUtil;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlow.Utilities.Hooks
{
    [Binding]
    public class TestListeners : WebActions
    {
        public static ExtentReportUtil report;

        public static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        //private static ExtentTest FeatureName;
        public static ExtentTest Scenario;

        private static ExtentTest Test { get; set; }
        public static XMLTestDataReader testData;

        //private readonly FeatureContext _featureContext;
        //private readonly ScenarioContext _scenarioContext;

        public static string stepType;

        //public TestListeners(FeatureContext featureContext, ScenarioContext scenarioContext)
        //{
        //    _featureContext = featureContext;
        //    _scenarioContext = scenarioContext;
        //}

        [BeforeTestRun]
        public static void StartTest()
        {
            report = new ExtentReportUtil();
            string logFolderName = "Report" + DateTime.Now.ToString("yyyy_MM_dd_hhmmss");
            logReportFolder = reportFolder + logFolderName;

            Directory.CreateDirectory(logReportFolder + "/screenshots");
            //For Logo
            Directory.CreateDirectory(logReportFolder + "/render");
            File.Copy(projectPath + "//Utilities/ReportUtil/gac.png", logReportFolder + "//render//gac.png");
            
            extent = new ExtentReports();
            htmlReporter = new ExtentHtmlReporter(logReportFolder + @"\extent.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent.AddSystemInfo("Host Name", MachineName);
            extent.AddSystemInfo("User Name", LoggedInUser);
            extent.AddSystemInfo("Environment", Environment);

            htmlReporter.LoadConfig(projectPath + @"Utilities\ReportUtil\extent-config.xml");
            extent.AttachReporter(htmlReporter);
            
            testData = new XMLTestDataReader();
            
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext _featureContext)
        {
          Test = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            FeatureID = FeatureContext.Current.FeatureInfo.Title;
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext _scenarioContext)
        {
            Scenario = Test.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            ScenarioName = _scenarioContext.ScenarioInfo.Title;
            
            new BaseClass().LaunchBrowser("CHROME")
                .NavigateTo(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
        }

        [BeforeStep]
        public static void InsertStepName()
        {
            stepType = ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType.ToString();
            
            if(ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                {
                    Scenario.CreateNode<Given>(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    Scenario.CreateNode<When>(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
                else if (stepType == "Then")
                {
                    Scenario.CreateNode<Then>(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
                else if (stepType == "And")
                {
                    Scenario.CreateNode<And>(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
            }
        }

        //[AfterStep]
        //public static void InsertReportingSteps()
        //{
        //    var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

        //    if (ScenarioContext.Current.TestError == null)
        //    {
        //        if (stepType == "Given")
        //        {
        //            Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass(TakeScreenshot());
        //        }
        //        else if (stepType == "When")
        //        {
        //            Scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass(TakeScreenshot());
        //        }
        //        else if (stepType == "Then")
        //        {
        //            Scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass(TakeScreenshot());
        //        }
        //        else if (stepType == "And")
        //        {
        //            Scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass(TakeScreenshot());
        //        }
        //    }
    //            else if (ScenarioContext.Current.TestError != null)
    //            {
    //                if (stepType == "Given")
    //                {
    //                    Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot_Fail(), "Screenshot").Build());
    //                }
    //                else if (stepType == "When")
    //                {
    //                    Scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot_Fail(), "Screenshot").Build());
    //                }
    //                else if (stepType == "Then")
    //{
    //    Scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot_Fail(), "Screenshot").Build());
    //}
    //else if (stepType == "And")
    //{
    //    Scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot_Fail(), "Screenshot").Build());
    //}
    //            }
        //}


        [AfterScenario]
        public static void Cleanup()
        {
            driver.Quit();
        }

        [AfterTestRun]
        public static void EndTest()
        {
            new BaseClass().CloseProcess("chromedriver");
            extent.Flush();
            Process.Start("file:///" + logReportFolder + "\\index.html");
        }
    }

}