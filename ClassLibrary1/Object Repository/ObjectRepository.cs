using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClassLibrary1.Object_Repository
{
    class ObjectRepository
    {

        public string readXMLFile(String projectName, string ModuleName, String key, String fileName)
        {
            string path = "D:\\Selenium\\ClassLibrary1\\ClassLibrary1\\Object Repository\\" + fileName;
            string requireddata = null;
            XmlTextReader reader = new XmlTextReader(path);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("Configuration");

            XmlNodeList projectNodeList = node.SelectNodes("Project");
            foreach (XmlNode tempNode in projectNodeList)
            {
                //get the value of 'name' attribute of current project node
                String attribute = tempNode.Attributes["name"].Value;
                if (attribute.Equals(projectName))
                {
                    XmlNodeList modulenodelist = tempNode.ChildNodes;
                    string eleAttribute = null;
                    foreach (XmlNode tempModuleNode in modulenodelist)
                    {
                        String attributeOfModuleNode = tempModuleNode.Attributes["name"].Value;
                        if (attributeOfModuleNode.Equals(ModuleName))
                        {
                            XmlNodeList elemnetNodeList = tempModuleNode.ChildNodes;
                            foreach (XmlNode tempElementNode in elemnetNodeList)
                            {
                                eleAttribute = tempElementNode.Attributes["key"].Value;
                                
                                if (eleAttribute.Equals(key))
                                {
                                    requireddata = tempElementNode.InnerText;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            reader.Close();
            reader.Dispose();
            return requireddata;


        }
    }
}
