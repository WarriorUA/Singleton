using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Singleton
{
    class Singleton
    {
        private static Singleton instance;
        public Dictionary<string,Language> langDictionary = new Dictionary<string, Language>();
        private Singleton()
        {
            XmlDocument langugeList=new XmlDocument();
            langugeList.Load("configuration.xml");
            XmlElement xRoot = langugeList.DocumentElement;
            string languageTime = null;
            foreach (XmlNode xNode in xRoot)
            {
                string open = null;
                string save = null;
                string close = null;
                if (xNode.Attributes.Count > 0)
                {
                    XmlNode attr = xNode.Attributes.GetNamedItem("leng");
                    if(attr!=null) languageTime=attr.Value;
                }
                foreach (XmlNode childNode in xNode.ChildNodes)
                {
                    if (childNode.Name == "menuOpenWinIndex") open = childNode.InnerText;
                    else if (childNode.Name == "menuSaveWinIndex") save = childNode.InnerText;
                    else close = childNode.InnerText;
                }
                langDictionary.Add(languageTime,new Language() {menuOpenWinIndex = open, menuCloseWinIndex = close, menuSaveWinIndex = save});
            }
        }

        public static Singleton GetInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }

    class Language
    {
        public string menuOpenWinIndex;
        public string menuSaveWinIndex;
        public string menuCloseWinIndex;

        public Language()
        {
            
        }
    }
}
