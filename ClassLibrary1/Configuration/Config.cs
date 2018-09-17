using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClassLibrary1.Configuration
{
    class Config
    {
        public void WritetoXML(String Projectname, String ModuleName, String SingleNode, String value)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load("D:\\Selenium\\ClassLibrary1\\ClassLibrary1\\Configuration\\ReadWrite.xml");
                XmlNode parentnode = xmldoc.SelectSingleNode("Configuration");
                XmlNodeList SettingeNodeList = parentnode.SelectNodes("Project");
                foreach (XmlNode tempSettingNode in SettingeNodeList)
                {

                    String attribute = tempSettingNode.Attributes["name"].Value;   //get the value of 'Name' attribute of current Setting node.
                    Console.WriteLine("Name Attribute:: " + attribute);
                    if (attribute.Equals(Projectname))
                    {
                        XmlNodeList ModuleNodeList = tempSettingNode.ChildNodes;

                        foreach (XmlNode tempModuleNode in ModuleNodeList)
                        {
                            if ((tempModuleNode.Attributes["name"].Value).Equals(ModuleName))
                            {
                                // XmlNodeList dataListNodes = tempModuleNode.ChildNodes;   //Getting control of all nodes under our required module node.

                                XmlNode requiredNode = tempModuleNode.SelectSingleNode(SingleNode);
                                requiredNode.InnerText = value;
                                //  prefixNode.InnerText = (currentPrefixValue + 1).ToString();
                                break; //Break TempSettingNode for loop
                            }
                        }

                    }

                }
                xmldoc.Save("D:\\Selenium\\ClassLibrary1\\ClassLibrary1\\Configuration\\ReadWrite.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public string readXMLFile(String projectName, string ModuleName, String key, String fileName)
        {
            string path = "D:\\Selenium\\ClassLibrary1\\ClassLibrary1\\" + fileName;
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

                                if (fileName.Equals("Config.xml"))
                                {
                                    eleAttribute = tempElementNode.Attributes["key"].Value;
                                }
                                else if (fileName.Equals("ReadXML.xml"))
                                {
                                    eleAttribute = tempElementNode.Name;
                                    requireddata = tempElementNode.InnerText;
                                }
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
