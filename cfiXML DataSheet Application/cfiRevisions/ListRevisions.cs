using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace cfiXML_Revisions
{
    public class ListRevisions
    {
        public string Xml_Path { get ; set; }
        public List<string> GetRevisions(string xml_Path)
        {
            Xml_Path = xml_Path;

            List<string> revisions = new List<string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xml_Path);

            XmlNamespaceManager nsm = new XmlNamespaceManager(xmldoc.NameTable);
            nsm.AddNamespace("eqRotDoc", "http://www.cfixml.org/document/eqRotDoc");
            nsm.AddNamespace("obj", "http://www.cfixml.org/obj");

            XmlNodeList nodes = xmldoc.SelectNodes("/eqRotDoc:centrifugalPumpDataSheet/obj:transaction/obj:revision", nsm);
            foreach (XmlNode node in nodes)
            {
                revisions.Add(node.FirstChild.Value);
            }
            return revisions.Distinct().ToList();
        }

    }
}
