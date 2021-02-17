using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlow.CommonLibs;
using SpecFlow.BusinessMethods;
using NUnit.Framework;

namespace SpecFlow.Pages.VesselTracking
{
    class VT_ServicesCharges : WebActions
    {
        readonly CommonFunctions cf = new CommonFunctions();

       
        public string SectionHeaders;

        IWebElement SectionHeading => driver.FindElement(By.XPath("//div[@class='BoxLayout---box_label'][@title='" + SectionHeaders + "']"));
        IWebElement VT_LabelHeader => driver.FindElement(By.XPath("//strong[contains(text(),'VESSEL TRACKING')]"));
        IWebElement CreateButton => driver.FindElement(By.XPath("//button[text()='Create']"));

        
        IWebElement VT_SC_Grid => driver.FindElement(By.XPath("(//table[contains(@class,'EditableGridLayout---table')])[2]"));

        IWebElement VT_SC_TBody => VT_SC_Grid.FindElement(By.XPath("//tbody"));

        //Service1 & Charges
        IWebElement VT_Row1 => VT_SC_TBody.FindElement(By.XPath("//tr[1]"));
        IWebElement VT_Col3_UOM => VT_Row1.FindElement(By.XPath("//td[3]/div/div"));
        IWebElement VT_Col5_Supplier => VT_Row1.FindElement(By.XPath("//td[5]//input"));
        IWebElement VT_Col6_SRN => VT_Row1.FindElement(By.XPath("//td[6]//input"));
        IWebElement VT_Col7_CostCurr => VT_Row1.FindElement(By.XPath("//td[7]//input"));
        IWebElement VT_Col16_PriceCurrency => VT_Row1.FindElement(By.XPath("//td[16]/div/div"));

        IWebElement VT_Row2 => VT_SC_TBody.FindElement(By.XPath("//tr[2]"));
        IWebElement VT_Col1_Principal => VT_Row2.FindElement(By.XPath("//td[1]//input"));
        IWebElement VT_Col2_BillingParty => VT_Row2.FindElement(By.XPath("//td[2]//input"));
        IWebElement VT_Col4_Qty => VT_Row2.FindElement(By.XPath("//td[4]//input"));
        IWebElement VT_Col8_ActualUnitCost => VT_Row2.FindElement(By.XPath("//td[8]//input"));
        IWebElement VT_Col10_EstTotalCost => VT_Row2.FindElement(By.XPath("//td[10]//input"));
        IWebElement VT_Col11_TaxType => VT_Row2.FindElement(By.XPath("//td[11]//input"));
        IWebElement VT_Col12_TaxRate => VT_Row2.FindElement(By.XPath("//td[12]//input"));
        IWebElement VT_Col17_Margin => VT_Row2.FindElement(By.XPath("//td[17]//input"));
        IWebElement VT_Col18_ActualUnitPrice => VT_Row2.FindElement(By.XPath("//td[18]//input"));
        IWebElement VT_Col20_Discount => VT_Row2.FindElement(By.XPath("//td[20]//input"));
        IWebElement VT_Col25_OperatingIncome => VT_Row2.FindElement(By.XPath("//td[25]/div/div"));

       
        public void ClickLabel()
        {
            ClickOn(VT_LabelHeader);
            Wait(5);
        }

        public void EnterServicesAndCharges()
        {
            cf.SelectValueFromDropDown(VT_Col3_UOM, "BULK LIQUID");
            cf.SelectValueFromPicker(VT_Col5_Supplier, "Blue Mountain", "Blue Mountain Tankers AS");
            cf.SelectValueFromPicker(VT_Col7_CostCurr, "AED", "AED");
            cf.SelectValueFromPicker(VT_Col1_Principal, "Blanchard", "Blanchard Cat Power Systems");

            EnterText(VT_Col4_Qty, "20");
            EnterText(VT_Col8_ActualUnitCost, "350");
            EnterText(VT_Col10_EstTotalCost, "7000");
            EnterText(VT_Col11_TaxType, "VAT");
            EnterText(VT_Col12_TaxRate, "5");

            EnterText(VT_Col17_Margin, "10");
            EnterText(VT_Col18_ActualUnitPrice, "");
            Wait(5);

            //ClickOn(VT_CreateJob.NextButton);
            
        }

        public void ClickCreate()
        {
            ClickOn(CreateButton);
            PageSync();
            Wait(10);
        }
        

        

       

        public void VerifySectionHeaders(string SectionHeaders)
        {
            
            Assert.True(SectionHeading.GetAttribute("innerText").Contains(SectionHeaders), "Section Header - " + SectionHeaders + " is Displayed");
            
        }

    }
}