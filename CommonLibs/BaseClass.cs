using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlow.Utilities.ReportUtil;
using System;
using System.Diagnostics;

namespace SpecFlow.CommonLibs
{

    class BaseClass : EnvironVariables
    {
        public BaseClass LaunchBrowser(string browserType)
        {
            try
            {
                switch (browserType.ToUpper())
                {
                    case "CHROME":
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("disable-infobars");
                        options.AddArgument("--start-maximized");
                        driver = new ChromeDriver(options);
                        //driver.Manage().Window.Maximize();
                        ((IJavaScriptExecutor)driver).ExecuteScript("document.body.style.zoom='80%';");
                        break;
                    case "CHROMEHEADLESS":
                        ChromeOptions optionsh = new ChromeOptions();
                        optionsh.AddArgument("--headless");
                        optionsh.AddArgument("disable-infobars");
                        driver = new ChromeDriver(optionsh);
                        driver.Manage().Window.Maximize();
                        break;
                    default:
                        break;
                }
                //ExtentReportUtil.report.Log(/*Status.Pass, "Launched Browser <b> " + Browser + "</b>"*/);
            }
            catch (Exception e)
            {
                //ExtentReportUtil.report.Log(/*Status.Fail, "Exception occured in LaunchBrowser => " + e.ToString()*/);
            }

            return new BaseClass();
        }

        public void NavigateTo(string URL)
        {
            try
            {
                driver.Navigate().GoToUrl(URL);
                //ExtentReportUtil.report.Log(/*Status.Pass, "Navigated to => <b>" + URL + "</b>"*/);
            }
            catch (Exception e)
            {
                //ExtentReportUtil.report.Log(/*Status.Fail, "Exception occured on NavigateTo method- " + e.ToString()*/);
            }
        }

        public void CloseProcess(string ProcessName)
        {
            try
            {
                foreach (var process in Process.GetProcessesByName(ProcessName))
                {
                    process.Kill();
                }
            }
            catch (Exception){}
        }

        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}