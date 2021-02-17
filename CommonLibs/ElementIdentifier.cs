using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.CommonLibs
{
    class ElementIdentifier : WebActions
    {

        public string InputLabel;

        IWebElement inputField => driver.FindElement(By.XPath("" + InputLabel + ""));


        public void EnterDataInGrid()
        {

        }



    }
}
