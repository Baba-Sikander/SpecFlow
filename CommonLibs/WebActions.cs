using OpenQA.Selenium;
using System;
using AventStack.ExtentReports;
using SpecFlow.Utilities.ReportUtil;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Linq;
using System.Windows;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlow.CommonLibs
{
    public class WebActions : EnvironVariables
    {
        public enum SelectionType
        {
            selectByValue,
            selectByIndex,
            selectByText
        }

        public static int imageCounter = 0;
        public Actions Operations;

        #region EnterText
        /// <summary>
        /// Method to enter text in the input box
        /// </summary>
        /// <param name="element">Web element</param>
        /// <param name="textToEnter">Input string</param>
        /// <returns>Returns page object</returns>
        ///
        public WebActions EnterText(IWebElement element, string textToEnter)
        {
            try
            {
                if (WaitForObject(element))
                {
                    GetElementAttributes(element);
                    ClearText(element);
                    if (!String.IsNullOrEmpty(textToEnter))
                    {
                        element.SendKeys(textToEnter);
                        ExtentReportUtil.report.Log(Status.Pass, "Entered <b> " + textToEnter + "</b> in the element - " + EnvironVariables.ElementOperated);
                    }
                    else
                    {
                        ExtentReportUtil.report.Log(Status.Fail, "Unable to enter value <b>" + textToEnter + "</b> in text box");
                    }
                }
                else
                {
                    ExtentReportUtil.report.Log(Status.Info, "Object => " + element.GetAttribute("innerText") + " is not displayed or disabled");
                }
            }
            catch (Exception ex)
            {
                ExtentReportUtil.report.Log(Status.Error, "Exception occurs in <b>EnterText</b> method =>" + ex.Message);
            }
            return new WebActions();
        }

        #endregion

        #region ClearText

        /// <summary>
        /// Method to clear text in the input box
        /// </summary>
        /// <param name="element">Web element</param>
        /// <returns>Returns page object</returns>
        public WebActions ClearText(IWebElement element)
        {
            try
            {
                if (WaitForObject(element))
                {
                    element.Clear();
                    //ExtentReportUtil.report.Log("Text cleared from the input box => " + EnvironVariables.ElementOperated);
                }
                else
                {
                    //ExtentReportUtil.report.Log("Object is not displayed or disabled");
                }
            }
            catch (Exception ex)
            {
                //ExtentReportUtil.report.Log("Exception Occured on ClearText Method => " + ex.ToString());
            }
            return new WebActions();
        }
        #endregion

        #region Set_TextBox
        /// <summary>
        /// Method to clear text, Click on textbox, and enter text
        /// </summary>
        /// <param name="element">Web Element</param>
        /// <param name="InputData">Input string</param>
        /// <returns>Returns page object</returns>
        public WebActions Set_Textbox(IWebElement element, string InputData)
        {
            try
            {
                if (WaitForObject(element, 5))
                {
                    element.Clear();
                    element.Click();
                    element.SendKeys(InputData);
                    //ExtentReportUtil.report.Log("Text cleared and entered <b>" + InputData + "</b> to the edit box => " + element.GetAttribute("name"));
                }
                else
                {
                    //ExtentReportUtil.report.Log("Unable to clear and enter <b>" + InputData + "</b> to the edit box => " + element.GetAttribute("name"));
                }
            }
            catch (Exception ex)
            {
                //ExtentReportUtil.report.Log("Exception Occured on Set_Textbox Method => " + ex.ToString());
            }
            return new WebActions();
        }

        #endregion

        #region ClickOn
        /// <summary>
        /// To click on object/element
        /// </summary>
        /// <param name="element">Web element</param>
        /// <returns>Returns page object</returns>
        
        public WebActions ClickOn(IWebElement element, string  messageToDisplay="")
        {
            try
            {
                if (WaitForObject(element))
                {
                    GetElementAttributes(element);
                    element.Click();
                    ExtentReportUtil.report.Log(Status.Pass, "Clicked on element - " + element.Text);
                }
                else
                {
                    ExtentReportUtil.report.Log(Status.Fail, "Object not found ");
                }
            }
            catch (Exception ex)
            {
                ExtentReportUtil.report.Log(Status.Error, "Exception occured on <b>ClickOn</B> method => " + ex.Message);
            }
            return new WebActions();
        }

        #endregion

        #region ClickOnJSByElement
        /// <summary>
        /// To click on object/element using JavaScript
        /// </summary>
        /// <param name="element">Web element</param>
        /// <returns>Returns page object</returns>
        
        public WebActions ClickOnJS(IWebElement element)
        {
            try
            {
                if (WaitForObject(element))
                {
                    String js = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js, element);
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                    executor.ExecuteScript("arguments[0].click();", element);
                    //ExtentReportUtil.report.Log("Clicked on object => " + EnvironVariables.ElementOperated);

                }
                else
                {
                    //ExtentReportUtil.report.Log("Object not found ");
                }
            }
            catch (Exception ex)
            {
                //ExtentReportUtil.report.Log("Exception occured on <b>ClickOn</B> method => " + ex.ToString());
            }
            return new WebActions();
        }
        #endregion

        #region WaitForObject
        /// <summary>
        /// To wait for element until(Within Provided Timeout) it is Displayed 
        /// </summary>
        /// <param name="element">Web element</param>
        /// <param name="TimeOut">Int Timeout</param>
        /// <returns>Returns Bool value</returns>
        public bool WaitForObject(IWebElement element, int TimeOut = 30)
        {
            bool flag = false;
            for (int i = 0; i < TimeOut; i++)
            {
                try
                {
                    if (element != null)
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        Wait(1);
                    }
                }
                catch (Exception)
                {
                    Wait(1);
                }
            }
            return flag;
        }
        #endregion

        #region TakeScreenshot
        /// <summary>
        /// To capture screenshot of current window
        /// </summary>
        /// <returns>Returns page object</returns>
        public static string TakeScreenshot()
        {
           
            imageCounter++;

            Screenshot screenshot = ((ITakesScreenshot)EnvironVariables.driver).GetScreenshot();

            string screenshotName = "image-" + imageCounter + ".JPEG";
            string screenshotPath = EnvironVariables.logReportFolder + "\\screenshots\\" + screenshotName;
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Jpeg);

            string screenshotRelativePath = "<a href = './screenshots/" + screenshotName + "'  target='_blank'> Screenshot </a>";
            return screenshotRelativePath;
        }

        public static string TakeScreenshot_Fail()
        {

            imageCounter++;

            Screenshot screenshot = ((ITakesScreenshot)EnvironVariables.driver).GetScreenshot();

            string screenshotName = "image-" + imageCounter + ".JPEG";
            string screenshotPath = EnvironVariables.logReportFolder + "\\screenshots\\" + screenshotName;
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Jpeg);
            return screenshotPath;
        }

        #endregion

        #region SwitchToLastWindow
        /// <summary>
        /// To Switch to the Last Window
        /// </summary>
        /// <returns>Returns Page object</returns>
        public WebActions SwitchToLastWindow()
        {
            try
            {
                string LastWindow = driver.WindowHandles.Last();
                driver.SwitchTo().Window(LastWindow);
                Wait(5);
                //ExtentReportUtil.report.Log("Switched to the Last window ");
            }
            catch (NoSuchWindowException ex)
            {
                //ExtentReportUtil.report.Log("Exception occures in the Switching to the Last Window " + ex.ToString());
            }
            return new WebActions();
        }
        #endregion

        #region SwitchToFirstWindow
        /// <summary>
        /// To Switch to the First Window
        /// </summary>
        /// <returns>Returns Page object</returns>
        public WebActions SwitchToFirstWindow()
        {
            try
            {
                string FirstWindow = driver.WindowHandles.First();
                driver.SwitchTo().Window(FirstWindow);
                Wait(5);
                //ExtentReportUtil.report.Log("Switched to the First window ");
            }
            catch (NoSuchWindowException ex)
            {
                //ExtentReportUtil.report.Log("Exception occures in the Switching to the First Window " + ex.ToString());
            }
            return new WebActions();
        }
        #endregion

        #region WaitExplicitUsingSeconds
        /// <summary>
        /// To Wait for webelement Explicitely(Hard wait)
        /// </summary>
        /// <param name="TimeOutInSeconds">Int TimeOutInSeconds</param>
        /// <returns>Returns page object</returns>
        public WebActions Wait(int TimeOutInSeconds)
        {
            Thread.Sleep(TimeOutInSeconds * 1000);
            return new WebActions();
        }
        #endregion

        #region AcceptAlert
        /// <summary>
        /// Accept the alert
        /// </summary>
        /// <returns>Returns page object</returns>
        public WebActions AcceptAlert()
        {
            try
            {
                Wait(2);
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                ExtentReportUtil.report.Log(Status.Pass, "Alert Accepted");
            }
            catch (Exception)
            {
                ExtentReportUtil.report.Log(Status.Fail, "No Alert Present");
            }
            return new WebActions();
        }
        #endregion

        #region DismissAlert
        /// <summary>
        /// Dismiss the alert
        /// </summary>
        /// <returns>Returns page object</returns>
        public WebActions DismissAlert()
        {
            try
            {
                Wait(2);
                IAlert alert = driver.SwitchTo().Alert();
                alert.Dismiss();
                ExtentReportUtil.report.Log(Status.Pass, "Alert Dismissed");
            }
            catch (Exception)
            {
                ExtentReportUtil.report.Log(Status.Fail, "No Alert Present");
            }
            return new WebActions();
        }

        #endregion

        #region Highlight
        /// <summary>
        ///  To Highlight the element/object
        /// </summary>
        /// <param name="element">Web element</param>
        public void Highlight(IWebElement element, IWebElement element2 = null)
        {
            for (int i = 0; i < 2; i++)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "border: 3px solid red;");
                if (element2 != null)
                {
                    js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element2, "border: 3px solid red;");
                }
                if (i == 1)
                {
                    TakeScreenshot();
                }
                js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "");

            }
            ExtentReportUtil.report.Log(Status.Pass, "Element is Highlighted");
        }
        #endregion

        #region SendKeystrokes
        /// <summary>
        /// To send key stroke
        /// </summary>
        /// <param name="key2Send">String key2Send</param>
        /// <returns>Returns page object</returns>
        public WebActions SendKeystrokes(string key2Send)
        {
            try
            {
                if (key2Send == "PressDown")
                {
                    SendKeys.SendWait(Keys.Down);
                    //ExtentReportUtil.report.Log("Down key pressed");
                }
                else if (key2Send == "PressUp")
                {
                    SendKeys.SendWait(Keys.ArrowUp);
                    //ExtentReportUtil.report.Log(Status.Pass, "Up key pressed");
                }
                else if (key2Send == "PressEnter")
                {
                    SendKeys.SendWait(Keys.Enter);
                    //ExtentReportUtil.report.Log(Status.Pass, "Enter key pressed");
                }
                else if (key2Send == "PressTab")
                {
                    SendKeys.SendWait(Keys.Tab);
                    //ExtentReportUtil.report.Log(Status.Pass, "Tab key pressed");
                }
                else if (key2Send == "PressControl")
                {
                    SendKeys.SendWait(Keys.LeftControl);
                    //ExtentReportUtil.report.Log(Status.Pass, "LeftControl key pressed");
                }
                else if (key2Send == "PressEscape")
                {
                    SendKeys.SendWait(Keys.Escape);
                }
                else
                {
                    //ExtentReportUtil.report.Log( "Invalid key pressed");
                }
            }
            catch (Exception ex)
            {
                //ExtentReportUtil.report.Log("Exception occured in SendKeystrokes method => " + ex.ToString());
            }
            return new WebActions();
        }
        #endregion

        #region SelectFromDropDown
        /// <summary>
        /// To select from dropdown (This functions will only work with the Combo Boxes Or Drop-Down with Select Tag).
        /// </summary>
        /// <param name="selectionType">SelectionType selectionType</param>
        /// <param name="element">Web element</param>
        /// <param name="value">String value</param>
        /// <returns>Returns page object</returns>
        public WebActions SelectFromDropDown(SelectionType selectionType, IWebElement element, string value)
        {
            if (WaitForObject(element))
            {
                SelectElement select = new SelectElement(element);
                switch (selectionType)
                {
                    case SelectionType.selectByValue:
                        select.SelectByValue(value);
                        //xtentReportUtil.report.Log(Status.Pass, "Selected " + value + " from the " + GlobalVariables.ElementOperated + " dropdown by Value provided");
                        break;
                    case SelectionType.selectByText:
                        select.SelectByText(value);
                        //tentReportUtil.report.Log(Status.Pass, "Selected " + value + " from the " + GlobalVariables.ElementOperated + " dropdown by Visible Text provided");
                        break;
                    case SelectionType.selectByIndex:
                        select.SelectByIndex(Convert.ToInt32(value));
                        //ExtentReportUtil.report.Log(Status.Pass, "Selected " + value + " from the " + GlobalVariables.ElementOperated + " dropdown by Index provided");
                        break;
                }
            }
            return new WebActions();
        }
        #endregion

        #region AssertTrue
        /// <summary>
        /// To ASSERT TRUE
        /// </summary>
        /// <param name="flag">Bool Flag</param>
        /// <returns>Returns page object</returns>
        public WebActions AssertTrue(bool flag, string ErrorMsg = "")
        {
            switch (flag)
            {
                case true:

                    ExtentReportUtil.report.Log(Status.Pass, "Assertion passed for - " + ScenarioContext.Current.StepContext.StepInfo.Text);
                    try
                    {
                        Assert.Pass();
                    }
                    catch (SuccessException) 
                    {
                    }
                    break;
                case false:

                    ExtentReportUtil.report.Log(Status.Fail, "Assertion failed for - " + ScenarioContext.Current.StepContext.StepInfo);
                    Assert.Fail();
                    break;
                default:
                    break;
            }
            return new WebActions();
        }
        #endregion

        #region AssertFalse
        /// <summary>
        /// To ASSERT FALSE
        /// </summary>
        /// <param name="flag">Bool Flag</param>
        /// <returns>Returns page object</returns>
        public WebActions AssertFalse(bool flag)
        {
            switch (flag)
            {
                case true:
                    Assert.Fail();
                    break;
                case false:

                    try
                    {
                        Assert.Pass();
                    }
                    catch (SuccessException) { }
                    break;
                default:
                    break;
            }
            return new WebActions();
        }
        #endregion

        public void SelectDate(IWebElement TableElement, string dateToSelect="")
        {
            try
            {
                string currentDate = DateTime.Now.ToString("mm/dd/yyyy");
                currentDate = currentDate.Substring(3, 2);
                if(dateToSelect!= "")
                {
                    dateToSelect = currentDate;
                }
                else
                {
                    dateToSelect = dateToSelect.Substring(3, 2);
                }
                IList<IWebElement> columns = TableElement.FindElements(By.TagName("td"));

                foreach (IWebElement ele in columns)
                {
                    if (ele.GetAttribute("innerText").Equals(dateToSelect))
                    {
                        ele.Click();
                        break;
                    }
                }
            }
            catch (Exception) { }
        }

        public void PageSync()
        {
            for(int i=0; i< 50; i++)
            {
                bool pageSync = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");

                if (pageSync)
                    break;
                else
                    Wait(1);
            }
        }

        #region ScrollElementIntoView
        /// <summary>
        /// To scroll to the web element
        /// </summary>
        /// <param name="element">Web element</param>
        public void ScrollElementIntoView(IWebElement element)
        {
            try
            {
                Wait(3);
                var js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", element);
                
            }
            catch (Exception)
            {
            }
        }
        #endregion
        public String GetText(IWebElement ele)
        {
            try {
               return ele.Text;
            }
            catch(Exception e)
            {
                return "Error! " + e;
            }
        }

        public bool ElementNotPresent(string XpathLocator, int timeout = 30)
        {
            bool flag = false;
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    if (driver.FindElements(By.XPath(XpathLocator)).Count == 0)
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
            return flag;
        }


        public void RefreshPage()
        {
            driver.Navigate().Refresh();
            Wait(10);
        }

        public void ScrollToEnd()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
        }

        public static string GetElementAttributes(IWebElement element)
        {
            ElementOperated = "";
            IJavaScriptExecutor JScriptDriver = (IJavaScriptExecutor)driver;
            Dictionary<string, object> attributes = JScriptDriver.ExecuteScript("var items = {}; for (index = 0; index < arguments[0].attributes.length; ++index) { items[arguments[0].attributes[index].name] = arguments[0].attributes[index].value }; return items;", element) as Dictionary<string, object>;
            GetElementTitle(attributes);
            objectAttributes = "";
            foreach (var item in attributes)
            {
                if (!item.Value.Equals(""))
                {
                    if (!objectAttributes.Equals(""))
                    {
                        objectAttributes = objectAttributes + "\r" + item.Key + " : " + item.Value;
                    }
                    else
                    {
                        objectAttributes = item.Key + " : " + item.Value;
                    }
                }
            }
            //Added few formatting for the Extent Reporting.
            ElementOperated = "<lable class ='dropdown-toggle' data-toggle='dropdown' data-placement='top' title='" + objectAttributes + "'><u><b>" + ElementTitle.ToString() + "</b></u></lable>";
            return ElementOperated;
        }

        public static string GetElementTitle(Dictionary<string, object> attributes)
        {
            try
            {
                if (attributes.ContainsKey("innerText"))
                {
                    attributes.TryGetValue("innerText", out ElementTitle);

                }
                else if (attributes.ContainsKey("name"))
                {
                    attributes.TryGetValue("name", out ElementTitle);

                }
                else if (attributes.ContainsKey("title"))
                {
                    attributes.TryGetValue("title", out ElementTitle);
                }
                else if (attributes.ContainsKey("class"))
                {
                    attributes.TryGetValue("class", out ElementTitle);
                }
                else
                {
                    ElementTitle = "Element";
                }

                return ElementTitle.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
} 