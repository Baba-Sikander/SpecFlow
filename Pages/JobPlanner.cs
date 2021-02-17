using OpenQA.Selenium;
using SpecFlow.CommonLibs;
using System.Collections;
using System.Collections.Generic;

namespace SpecFlow.Pages
{
    class JobPlanner : WebActions
    {
        IList<IWebElement> tabs => driver.FindElements(By.XPath("//div[@class='SiteMenuTab---nav_label']"));
        IWebElement CargoPlan => driver.FindElement(By.XPath("//div[@class='SiteMenuTab---nav_label'][text()='Plan Cargo']"));
        IWebElement VoyagePlan => driver.FindElement(By.XPath("//div[@class='SiteMenuTab---nav_label'][text()='Plan Voyage']"));
        IWebElement Dashboard => driver.FindElement(By.XPath("//div[@class='SiteMenuTab---nav_label'][text()='Dashboard']"));

        public void ClickTab(string TabName)
        {
            foreach(IWebElement element in tabs)
            {
                if(element.GetAttribute("innerText").ToUpper() == TabName)
                {
                    ClickOn(element);
                    Wait(2);
                }
            }            
        }
    }
}
