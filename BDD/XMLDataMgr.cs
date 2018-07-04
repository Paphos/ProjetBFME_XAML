using lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BDD
{
    public class XMLDataMgr : IDataManager
    {
        public DataContractSerializer serializer = new DataContractSerializer(typeof(Manager));
        DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());

        public void Load(out Manager manager)
        {
            string dirData = string.Format("{0}\\BDD\\XML\\", dirInfo.Parent.Parent.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "manager.xml");

            Stream reader = File.OpenRead(xmlFile);
            manager = serializer.ReadObject(reader) as Manager;
            reader.Close();
        }

        public void Save(Manager manager)
        {
            string dirData = string.Format("{0}\\BDD\\XML\\", dirInfo.Parent.Parent.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "manager.xml");

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            XmlWriter writer = XmlWriter.Create(xmlFile, settings);
            //Stream writer = File.Create("C:\\Users\\THEOPHILE\\Desktop\\test.xml");
            serializer.WriteObject(writer, manager);

            writer.Close();
        }


    }
}
