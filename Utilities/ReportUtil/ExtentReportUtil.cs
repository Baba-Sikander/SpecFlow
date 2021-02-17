using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using SpecFlow.CommonLibs;
using SpecFlow.Utilities.Hooks;
using System;
using System.Security.Authentication.ExtendedProtection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace SpecFlow.Utilities.ReportUtil
{
    public class ExtentReportUtil : TestListeners
    {        
        public void Log(Status status, string stepDetail)
        {
            var stepType = ScenarioContext.Current.StepContext.ToString();
            
            ExtentTest stepName;

            if (stepType == "Given")
            {
                stepName = Scenario.CreateNode<Given>(stepDetail);
            }
            else if (stepType == "When")
            {
                stepName = Scenario.CreateNode<When>(stepDetail);
            }
            else if (stepType == "Then" )
            {
                stepName = Scenario.CreateNode<Then>(stepDetail);
            }
            else
            {
                stepName = Scenario.CreateNode<And>(stepDetail);
            }

            switch (status)
            {
                case Status.Pass:
                    stepName.Pass(Status.Pass.ToString());
                    break;
                case Status.Fail:
                    stepDetail = "<font color = 'red'>" + stepDetail + "</font>";
                    stepName.Fail(stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot_Fail(), "Screenshot").Build());
                    Assert.Fail();
                    break;
                case Status.Fatal:
                    stepName.Fatal(stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot_Fail(), "Screenshot").Build());
                    Assert.Fail();
                    break;
                case Status.Error:
                    stepDetail = "<font color = 'red'>" + stepDetail + "</font>";
                    stepName.Error(stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot_Fail(), "Screenshot").Build());
                    Assert.Fail();
                    break;
                case Status.Warning:
                    stepName.Warning(stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot_Fail(), "Screenshot").Build());
                    break;
                case Status.Info:
                    stepName.Info(TakeScreenshot());
                    break;
                case Status.Skip:
                    stepName.Skip(TakeScreenshot());
                    break;
                case Status.Debug:
                stepName.Debug(TakeScreenshot());
                    break;
                default:
                    break;
            }
        }
    }
}


//check this method

//public void Log(Status status, string stepDetail)
//{            
//    switch (status)
//    {
//        case Status.Pass:
//            TestListeners.Scenario.CreateNode<Given>(TestContext.CurrentContext.Test.FullName, stepDetail).Pass(TakeScreenshot());
//            break;
//        case Status.Fail:
//            stepDetail = "<font color = 'red'>" + stepDetail + "</font>";
//            TestListeners.Scenario.Log(status, stepDetail);
//            TakeScreenshot();
//            try
//            {
//                Assert.Fail();
//            }
//            catch (System.Exception)
//            {

//            }

//            break;
//        case Status.Fatal:
//            TestListeners.Scenario.Log(status, stepDetail);
//            Assert.Fail();
//            break;
//        case Status.Error:
//            stepDetail = "<font color = 'red'>" + stepDetail + "</font>";
//            TestListeners.Scenario.Log(status, stepDetail);
//            TakeScreenshot();
//            Assert.Fail();
//            break;
//        case Status.Warning:
//            TestListeners.Scenario.Log(status, stepDetail);
//            break;
//        case Status.Info:
//            TestListeners.Scenario.Log(status, stepDetail);
//            break;
//        case Status.Skip:
//            TestListeners.Scenario.Log(status, stepDetail);
//            break;
//        case Status.Debug:
//            TestListeners.Scenario.Log(status, stepDetail);
//            break;
//        default:
//            break;

//    }
//}