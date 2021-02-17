using System.Linq;
using System.Xml.Linq;

namespace SpecFlow.Utilities.TestDataUtil
{
    class XmlReader
    {
        public static XDocument xml;
        public string RootElement = "";
        public XmlReader LoadXML(string xmlFilePath)
        {
            xml = XDocument.Load(xmlFilePath);
            return new XmlReader();
        }

        public string ReadTagValue(string TagName, string ParentTag = "")
        {
            if (ParentTag.Equals(""))
            {
                ParentTag = xml.Root.Name.ToString();
            }
            string TagValue = string.Empty;

            var nodes = (from n in xml.Descendants(ParentTag)
                         select new
                         {
                             textValue = (string)n.Element(TagName).Value,
                         });
            foreach (var item in nodes)
            {
                TagValue = item.textValue;
            }
            return TagValue;
        }

        public string ReadTagValueList(string TagName, string ParentTag = "")
        {
            if (ParentTag.Equals(""))
            {
                ParentTag = xml.Root.Name.ToString();
            }
            string TagValue = string.Empty;

            var nodes = (from n in xml.Descendants(ParentTag)
                         select new
                         {
                             textValue = (string)n.Element(TagName).Value,
                         });
            foreach (var item in nodes)
            {
                TagValue = item.textValue;
            }
            return TagValue;
        }
    }
}
