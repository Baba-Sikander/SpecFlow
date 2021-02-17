using System;
using System.Linq;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace SpecFlow.Utilities.TestDataUtil
{
    public class XMLTestDataReader
    {

        public static string xmlName = string.Empty;
        /*
         * Reads the data from the XML file based on the mentioned Scenario/Feature
         * @parameters : tagName = node/variable name
         */
        public string ReadData(string tagName)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string path = projectPath.Replace(@"\bin\Debug\", "") + @"\TestData\" + XMLName() + ".xml";

            XDocument xml = XDocument.Load(path);
            string text = string.Empty;
            var nodes = (from n in xml.Descendants("TestData").
             Where(r => r.Parent.Attribute("ScenarioName").Value == EnvironVariables.ScenarioName)
                         select new
                         {
                             testData = (string)n.Element(tagName).Value,
                         });
            foreach (var n in nodes)
            {
                text = n.testData;
            }
            return text;
        }

        public string XMLName()
        {
            xmlName = EnvironVariables.FeatureID;
            return xmlName;
        }
    }
}
