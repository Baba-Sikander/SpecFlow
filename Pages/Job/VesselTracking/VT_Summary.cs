using OpenQA.Selenium;
using SpecFlow.BusinessMethods;
using SpecFlow.CommonLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTalk.SpecFlow.BindingSkeletons;

namespace SpecFlow.Pages.VesselTracking
{
    class VT_Summary : WebActions
    {

        CommonFunctions cf = new CommonFunctions();
        public static string PageName = null;

        IList<IWebElement> DocumentsTab => driver.FindElements(By.ClassName("TabButtonWidget---tab_label"));
        IWebElement EventsSubsectionHeader => driver.FindElement(By.XPath("//div[text()=' Events']"));
        IWebElement EventName => driver.FindElement(By.XPath("//div[contains(@aria-labelledby,'column0')][contains(text(),'event')]"));
        IWebElement EventDate => driver.FindElement(By.XPath("//div[contains(@aria-labelledby,'column0')]/../../following-sibling::td//input[contains(@id,'date')]"));
        IWebElement EventTime => driver.FindElement(By.XPath("//div[contains(@aria-labelledby,'column0')]/../../following-sibling::td//input[contains(@id,'time')]"));
        IWebElement EventsRemarks => driver.FindElement(By.XPath("//div[contains(@aria-labelledby,'column0')]/../../following-sibling::td//input[contains(@aria-labelledby,'column2')]"));
        IWebElement UpdatePage => driver.FindElement(By.XPath("//strong[text()='UPDATE']/../.."));
        IWebElement ETConvertToActual => driver.FindElement(By.XPath("//span[text()='Convert To Actual']/.."));
        IList<IWebElement> AddEvent => driver.FindElements(By.XPath("//a[contains(text(),'Add Event')]"));
        IWebElement ATA => driver.FindElement(By.XPath("//span[text()='ATA']"));
        IWebElement CreateSOFButton => driver.FindElement(By.XPath("//button[text()='Create SOF']"));
        IWebElement CaptainEmail => driver.FindElement(By.XPath("//input[@class='TextInput---text TextInput---align_start']"));
        IWebElement Comments_Paragraph => driver.FindElement(By.XPath("//textarea[contains(@class,'ParagraphWidget')]"));
        IWebElement UploadSignature => driver.FindElement(By.XPath("//div[@class='MultipleFileUploadWidget---uploads_wrapper MultipleFileUploadWidget---drag_drop_zone_wrapper']/input"));
        IWebElement ProceedCheckBox => driver.FindElement(By.XPath("//label[@class='CheckboxGroup---choice_label' and text()='Yes']"));
        IWebElement Approve_Captain => driver.FindElement(By.XPath("//p[contains(text(),'Approve')]/ancestor::div[contains(@class,'ContentLayout---content_layout ContentLayout---padding_less')]"));
        IWebElement Reject_Captain => driver.FindElement(By.XPath("//p[contains(text(),'Reject')]/ancestor::div[contains(@class,'ContentLayout---content_layout ContentLayout---padding_less')]"));

        IWebElement CaptainEmailID => driver.FindElement(By.XPath("//label[text()='Captain Email']/../following-sibling::div//input"));


        IWebElement PreviewSOFDoc => driver.FindElement(By.XPath("//span[text()='Preview SOF Document']"));

        IWebElement AgentComments => driver.FindElement(By.XPath("//label[text()='Comments From Agent']//parent::div//following::div//textarea[@role='textbox']"));

        IWebElement AcceptCapApproval => driver.FindElement(By.XPath("//button[text()=\"Accept Captain's Update\"]"));

        IWebElement RejectCapApproval => driver.FindElement(By.XPath("//button[text()='Return To Captain']"));

        IWebElement AddDocumentLink => driver.FindElement(By.XPath("//a[@class='GridFooter---add_grid_row_link elements---global_a'][text()='Add Document']"));
        IWebElement UploadDocument_Button => driver.FindElement(By.XPath("//button[contains(@class,'Button---inGridLayout')][text()='Upload']"));
        IList<IWebElement> EventDates => driver.FindElements(By.XPath("//div[@class='BoxLayout---box_label'][text()='Stoppage And Remarks']//parent::div//parent::div//following::div[contains(@aria-labelledby,'column0')]/../../following-sibling::td//input[contains(@id,'date')]"));
        
        IList<IWebElement> EventTimes => driver.FindElements(By.XPath("//div[@class='BoxLayout---box_label'][text()='Stoppage And Remarks']//parent::div//parent::div//following::div[contains(@aria-labelledby,'column0')]/../../following-sibling::td//input[contains(@id,'time')]"));


        public void addEvent(string eventType)
        {
            ScrollElementIntoView(UpdatePage);
            switch (eventType)
            {
                case "Events":
                    AddEvent[0].Click();
                    Wait(5);
                    break;
                case "Stoppage And Remarks":
                    AddEvent[1].Click();
                    Wait(5);
                    break;
                case "Bunkers":
                    AddEvent[2].Click();
                    Wait(5);
                    break;
                case "Draft":
                    AddEvent[3].Click();
                    Wait(5);
                    break;
                case "Tugs":
                    AddEvent[4].Click();
                    Wait(5);
                    break;
                case "Cargo Details":
                    AddEvent[5].Click();
                    Wait(5);
                    break;
                default:
                    break;
            }
        }

        public void clickonTextATA()
        {
            //TODO - Make click withJS
            ATA.Click();

            Wait(1);

        }
        public void accessEvents()
        {
            EventsSubsectionHeader.Click();
            Wait(5);

        }

        public void accessEvents(String HeaderName)
        {
            cf.ExpandSubSectionHeader(HeaderName);
            Wait(5);
        }

        public void enterEventName(String eventName)
        {
            cf.SelectValueFromDropDown(EventName, eventName);
        }

        public void enterEventDate(String mm_dd_yyyy)
        {
            try
            {
                mm_dd_yyyy.Replace('_', '/');
            }
            catch { }
            EnterText(EventDate, mm_dd_yyyy);
        }
        public void enterEventTime(string time)
        {
            EnterText(EventTime, time);
        }

        public void enterEventRemarks(string remarks)
        {
            EnterText(EventsRemarks, remarks);
        }

        public void updatePage()
        {
            UpdatePage.Click();
            PageSync();
            Wait(10);
        }

        public void EtConvertToActual()
        {
            ScrollElementIntoView(ETConvertToActual);
            ClickOnJS(ETConvertToActual);
            Wait(5);
        }

        public void createSOF()
        {
            RefreshPage();
            PageSync();
            Wait(10);
            cf.ClickButtonByLabelName("Create SOF");
            PageSync();
            Wait(5);
        }
        public void captainApproval()
        {
            IList<IWebElement> Button = driver.FindElements(By.TagName("button"));

            foreach(IWebElement element in Button)
            {
                if(element.GetAttribute("innerText").Equals("CAPTAIN'S APPROVAL"))
                {
                    ClickOn(element);
                    Wait(10);
                    break;
                }
                else
                    Wait(1);
            }
            //cf.ClickButtonByLabelName("Captain's Approval");
            //Wait(10);
            ////ScrollElementIntoView(UpdatePage);
            ////Wait(5);
        }
        public IWebElement createSOFButton()
        {
            return CreateSOFButton;
        }
        public void enterCommentsInParagraph(String comments)
        {
            EnterText(Comments_Paragraph, comments);
        }
        public void sendMail()
        {
            cf.ClickButtonByLabelName("Send Mail");
            Wait(5);
            RefreshPage();
            Wait(10);
        }

        public void uploadSignature(String filePath)
        {
            EnterText(UploadSignature, filePath);
        }
        public void clickProceedCheckBox()
        {
            ClickOn(ProceedCheckBox);
        }
        public void clickApproveCaptain()
        {
            ClickOn(Approve_Captain);
            Wait(5);
            ClickSendToAgent();
            Wait(2);
            RefreshPage();
            Wait(10);
        }
        public void clickRejectCaptain()
        {
            ClickOn(Reject_Captain);
        }
        public void enterCaptainEmail(String emailID)
        {
            CaptainEmailID.SendKeys(emailID);
        }

        public void ClickPreviewSOF()
        {
            ScrollToEnd();
            ClickOn(PreviewSOFDoc);
            PageSync();
            Wait(2);
        }

        public void EnterAgentComments(string comments)
        {
            EnterText(AgentComments, comments);
        }

        public void AcceptCaptainsApproval()
        {
            ClickOn(AcceptCapApproval);
            PageSync();
            Wait(5);
            RefreshPage();
            Wait(10);
        }

        public void RejectCaptainsApproval()
        {
            ClickOn(RejectCapApproval);
            PageSync();
        }

        public void ClickTabOnSummary(string tabName)
        {
            foreach(IWebElement element in DocumentsTab)
            {
                if (element.GetAttribute("innerText").Contains(tabName))
                {
                    ClickOn(element);
                    break;
                 }
            }
            PageSync();
            Wait(10);
        }

        public void UploadPreDepartureDoc(string fileName)
        {
            cf.ClickButtonByLabelName("Upload & Delete Documents");
            Wait(2);
            ClickOn(AddDocumentLink);
            Wait(1);
            UploadFile(fileName);
            PageSync();
            Wait(10);
        }

        public void UploadFile(String filePath)
        {
            ScrollElementIntoView(UploadSignature);
            EnterText(UploadSignature, filePath);
        }

        //Stopage and Remarks Events
        public void EnterEventStartDate(String mm_dd_yyyy)
        {
            cf.EnterText(EventDates[0], mm_dd_yyyy);
        }
        public void EnterEventStartTime(String time)
        {
            cf.EnterText(EventTimes[0], time);
        }
        public void EnterEventEndDate(String mm_dd_yyyy)
        {

            cf.EnterText(EventDates[1], mm_dd_yyyy);
        }
        public void EnterEventEndTime(String time)
        {
            cf.EnterText(EventTimes[1], time);
        }
        //Bunkers
        public void SelectFuelType(String fuelType)
        {
            cf.SelectValueFromDropDown("--Select Position--", fuelType);
        }
        public void EnterQuantity(String quantityToEnter)
        {
            cf.EnterUsingPlaceHolder("--Enter Quantity--", quantityToEnter);
        }

        public void ClickAgentsReview()
        {
            cf.ClickButtonByLabelName("Agent's Review");
            PageSync();
            Wait(10);
        }

        public void ClickSendToAgent()
        {
            cf.ClickButtonByLabelName("Send To Agent");
            Wait(10);
        }

        public void ClickSave()
        {
            cf.ClickButtonByLabelName("Save");
            PageSync();
            Wait(3);
        }
    }
}
