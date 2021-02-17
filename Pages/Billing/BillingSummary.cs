using OpenQA.Selenium;
using SpecFlow.CommonLibs;

namespace SpecFlow.Pages
{
    class BillingSummary : WebActions
    {
        public static IWebElement SummaryView_Label => driver.FindElement(By.XPath("//strong[@class='StrongText---richtext_strong'][text()='Summary View']"));
        public static IWebElement PrintFinal => driver.FindElement(By.XPath("//button[text()='Print Final']"));
        public static IWebElement PrintDraft => driver.FindElement(By.XPath("//button[text()='Print Draft']"));

        public void VerifyBillingSummaryPageDisplayed()
        {
            WaitForObject(SummaryView_Label);
            AssertTrue(SummaryView_Label.Displayed, "Not Navigated to Summary Page");
        }

        public void ClickPrintFinal()
        {
            ScrollElementIntoView(PrintFinal);
            ClickOn(PrintFinal);
        }

        public void ClickPrintDraft()
        {
            ScrollElementIntoView(PrintDraft);
            ClickOn(PrintDraft);
        }

        public void VerifyPrintDraftAndFinalButtonDisplayed()
        {
            ScrollElementIntoView(PrintFinal);
            AssertTrue(PrintDraft.Displayed, "Print Draft button is not displayed");
            AssertTrue(PrintFinal.Displayed, "Print Final button is not displayed");
        }
    }
}
