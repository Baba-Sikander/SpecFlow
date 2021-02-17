using OpenQA.Selenium;
using System;

namespace SpecFlow
{
    public class EnvironVariables
    {
        public static IWebDriver driver;
        public static string objectAttributes;
        public static object ElementTitle;
        public static string ElementOperated;
        //public static string testCaseID;
        public static string FeatureID;
        public static string ScenarioName;
        public static string QuotationNumber;
        /** 
         Report configuration variables         
         */
        public static string projectFolder = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        public static string projectPath = projectFolder.Replace(@"\bin\Debug", "");
        public static string logReportFolder = null;
        public static string reportFolder = projectPath + "Reports\\" + logReportFolder;
        public static string fileName = null;
        public static string filePath = projectPath + "Assets\\" + fileName;
        /**
         * Machine Details variables
         * */
        public static string MachineName = System.Environment.MachineName;
        public static string LoggedInUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        /**
         * Configuration Variables
         * */
        public static string EnvConfigurationPath = projectPath + "/EnvConfig.xml";
        public static string Environment = "QA";
        public static string ExecutionPath;
        public static string Browser;
        public static string URL;
        public static string ReportType;
        public static string ScreenshotType = "Embedded";
        public static string VideoRecordingFlag;
        public static string buildVersion = "";
        public static string username= "mayank.tripathi@gac.com";
        public static string Password;

    }
}