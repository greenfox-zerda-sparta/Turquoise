using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace SmartHomeUI
{
    class XMLHandler
    {
        public void devicesToXML(ObservableCollection<Device> list, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(list.GetType());
            StreamWriter fileWriter = new StreamWriter(filename);
            serializer.Serialize(fileWriter, list);
        }

        public void devicesFromXML(ref ObservableCollection<Device> list, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Device>));
            FileStream fileReader = new FileStream(filename, FileMode.Open);
            list = (ObservableCollection<Device>)serializer.Deserialize(fileReader);
        }

        public void tasksToXML(ObservableCollection<Task> list, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(list.GetType());
            StreamWriter fileWriter = new StreamWriter(filename);
            serializer.Serialize(fileWriter, list);
        }

        public void tasksFromXML(ref ObservableCollection<Task> list, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Task>));
            FileStream fileReader = new FileStream(filename, FileMode.Open);
            list = (ObservableCollection<Task>)serializer.Deserialize(fileReader);
        }
    }
}
