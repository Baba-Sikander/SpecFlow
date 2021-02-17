using OpenQA.Selenium;
using SpecFlow.CommonLibs;

namespace SpecFlow.Pages
{
    class Dashboard : WebActions
    {
        public static string PageName = null;
        IWebElement Page => driver.FindElement(By.XPath("//strong[@class='StrongText---richtext_strong'][text()='" + PageName + "']"));

        public void NavigateToPage(string pageName)
        {
            PageName = pageName;
            WaitForObject(Page);
            ClickOn(Page);
            Wait(2);
            SwitchToLastWindow();
            Wait(5);
        }

        public void ClickOnGivenLink(string labelName)
        {
            string xPath = "//a[@class='LinkedItem---standalone_richtext_link LinkedItem---inStrongText elements---global_a'][text()=' " + labelName + "']";
            Wait(10);            
            ClickOn(driver.FindElement(By.XPath(xPath)));
        }
    }
}
