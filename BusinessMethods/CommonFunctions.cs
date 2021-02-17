using OpenQA.Selenium;
using SpecFlow.CommonLibs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SpecFlow.BusinessMethods
{
    public class CommonFunctions : WebActions
    {
        public string LabelName = null;
        public IList<IWebElement> BillingTabs => driver.FindElements(By.XPath("//div[@class='SiteMenuTab---nav_label']"));
        //
        IWebElement FormHeader => driver.FindElement(By.XPath("//h1[@class='FormLayout---title']"));
        IWebElement ScreenHeader => driver.FindElement(By.XPath("//h1[@class='TitleText---page_header TitleText---inLightBackground']"));
        IWebElement ButtonElement => driver.FindElement(By.XPath("//button[text()=\"" + LabelName + "\"]"));
        IWebElement ProgressBar => driver.FindElement(By.XPath("//div[@class='LoadingBar---nprogress LoadingBar---bar_background']"));

        string ProgressBar_XPath = "//div[@class='LoadingBar---nprogress LoadingBar---bar_background']";

        public void ClickTab(string TabName)
        {
            foreach(IWebElement element in BillingTabs)
            {
                if(element.GetAttribute("innerText").ToUpper() == TabName.ToUpper())
                {
                    ClickOn(element);
                    Wait(5);
                    break;
                }
            }
        }

        public void SelectValueFromPicker(IWebElement inputElement, string TextToSearch, string ValueToSelect)
        {
            EnterText(inputElement, TextToSearch);
            //CheckProgressBar();
            Wait(3);
            IList<IWebElement> PickerField = driver.FindElements(By.CssSelector("ul.MenuWidget---listbox.MenuWidget---relative li p"));
            foreach (IWebElement element in PickerField)
            {
                if (element.GetAttribute("innerText").ToUpper() == ValueToSelect.ToUpper())
                {
                    ClickOn(element);
                    Wait(1);
                    break;
                }
            }
        }

        public void SelectItemFromPickerField(string LabelName, string ValueToSearch, string ValueToPick)
        {
            IWebElement PickerInput = driver.FindElement(By.XPath("//span[text()='"+ LabelName +"']//parent::div/following-sibling::div//input"));


            EnterText(PickerInput, ValueToSearch);

            //CheckProgressBar();
            Wait(3);
            IList<IWebElement> PickerField = driver.FindElements(By.CssSelector("ul.MenuWidget---listbox.MenuWidget---relative li p"));

            foreach (IWebElement element in PickerField)
            {
                if (element.GetAttribute("innerText") == ValueToPick)
                {
                    ClickOn(element);
                    Wait(1);
                    break;
                }
            }
            Wait(1);
        }


        public void SelectItemFromPickerField(IWebElement PickerInput, string ValueToSearch, string ValueToPick)
        {
            //IWebElement PickerInput = driver.FindElement(By.XPath("//span[text()='" + LabelName + "']//parent::div/following-sibling::div//input"));


            EnterText(PickerInput, ValueToSearch);
            //CheckProgressBar();
            Wait(3);
            IList<IWebElement> PickerField = driver.FindElements(By.CssSelector("ul.MenuWidget---listbox.MenuWidget---relative li p"));

            foreach (IWebElement element in PickerField)
            {
                if (element.GetAttribute("innerText") == ValueToPick)
                {
                    ClickOn(element);
                    Wait(3);
                    break;
                }
            }
            Wait(2);
        }


        public void SelectValueFromDropDown(string defaultText, string ValueToSelect)
        {
            IWebElement dropdown = driver.FindElement(By.XPath("//span[text()='"+defaultText+"']//parent::div"));
            ClickOn(dropdown);
            Wait(2);
            ClickOn(driver.FindElement(By.XPath("//ul[contains(@class,'MenuWidget---listbox')]/li/div[text()='" + ValueToSelect + "']")));
        }

        public void SelectValueFromDropDownWithinGrid(IWebElement dropDown, string defaultText, string ValueToSelect)
        {
            ClickOn(dropDown);
            Wait(2);
            ClickOn(driver.FindElement(By.XPath("//ul[contains(@class,'MenuWidget---listbox')]/li/div[text()='" + ValueToSelect + "']")));
        }

        public void ClickButtonByLabelName(string labelName)
        {
            LabelName = labelName;
            WaitForObject(ButtonElement);
            ClickOn(ButtonElement);
            PageSync();
            Wait(5);
        }

        public void SelectValueFromDropDown(IWebElement dropdown, IList<IWebElement> webElements, string ValueToSelect)
        {
            ClickOn(dropdown);
            Wait(1);
            foreach (IWebElement element in webElements)
            {
                if (element.GetAttribute("innerText") == ValueToSelect)
                {
                    ClickOn(element);
                    Wait(1);
                    break;
                }
            }
        }

        public void BillingDashboard_SearchFilter(string FilterName, IWebElement element, string FilterValue)
        {
            switch (FilterName.ToUpper())
            {
                case "CUSTOMER NAME":
                    EnterText(element, FilterValue);
                    break;
                case "OPERATIONAL PROCESS":
                    SelectFromDropDown(SelectionType.selectByText, element, FilterValue);
                    break;
                case "JOB NUMBER":
                    EnterText(element, FilterValue);
                    break;
                case "BUSINESS AREA":
                    SelectFromDropDown(SelectionType.selectByText, element, FilterValue);
                    break;
                case "BILLING STATUS":
                    SelectFromDropDown(SelectionType.selectByText, element, FilterValue);
                    break;
                case "BILLING PRIORITY":
                    SelectFromDropDown(SelectionType.selectByText, element, FilterValue);
                    break;
            }
                 
        }

        public void SelectValueFromDropDown(IWebElement dropdown, string ValueToSelect)
        {
            try
            {
                ClickOn(dropdown);
                Wait(5);
                
                IList<IWebElement> webElements = driver.FindElements(By.CssSelector("ul.MenuWidget---listbox.MenuWidget---relative li div"));

                foreach (IWebElement element in webElements)
                {
                    if (element.GetAttribute("innerText").ToUpper() == ValueToSelect.ToUpper())
                    {
                        ClickOn(element);
                        Wait(1);
                        break;
                    }
                }
            }
            catch(StaleElementReferenceException)
            {
                IList<IWebElement> webElements = driver.FindElements(By.CssSelector("ul.MenuWidget---listbox.MenuWidget---relative li div"));

                foreach (IWebElement element in webElements)
                {
                    if (element.GetAttribute("innerText") == ValueToSelect)
                    {
                        ClickOn(element);
                        Wait(1);
                        break;
                    }
                }
            }
            Wait(3);
        }

        public void EnterUsingPlaceHolder(string placeHolderText, string inputText)
        {
            IWebElement TextField = driver.FindElement(By.XPath("//span[text()='" + placeHolderText + "']//parent::div/input"));

            EnterText(TextField, inputText);
        }

        public void ExpandSubSectionHeader(string sectionName)
        {
            IWebElement SubsectionHead = driver.FindElement(By.XPath("//div[@class='BoxLayout---box_label'][text()='" + sectionName + "']"));
            ClickOn(SubsectionHead);
            Wait(1);
        }

        public void enterEstimatedTime(string ETType, string DtInmm_dd_yyyy, string TmInhh_mm)
        {
            IWebElement etDate = driver.FindElement(By.XPath("//*[text()='" + ETType + "']/../following-sibling::div//input[contains(@aria-describedby,'datePicker_placeholder')]"));
            IWebElement etTime = driver.FindElement(By.XPath("//*[text()='" + ETType + "']/../following-sibling::div//input[contains(@aria-describedby,'timePicker_placeholder')]"));
            //DtInmm_dd_yyyy.Replace('_', '/');
            //TmInhh_mm.Replace('_', '/');
            etDate.Clear();
            Wait(1);
            etTime.Clear();
            Wait(1);
            etDate.SendKeys(DtInmm_dd_yyyy);
            ///SendKeystrokes("PressTab");
            etTime.SendKeys(TmInhh_mm);
            // SendKeystrokes("PressTab");
        }
        public string getScreenHeader()
        {
            return ScreenHeader.Text;
        }

        public string getFormHeader()
        {
            return FormHeader.Text;
        }
        public string getFirstName()
        {
            //UserName
            return username.Split('.')[0];
        }

        public void CheckProgressBar()
        {
            Wait(3);
            for(int i=0; i<30; i++) 
            {
                if (ProgressBar.Displayed)
                {
                    Wait(1);
                }
                else if(ElementNotPresent(ProgressBar_XPath)){
                    break;
                }
            }
        }
    }
}
