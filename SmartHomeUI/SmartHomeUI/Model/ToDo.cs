using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SmartHomeUI
{
    [Serializable()]
    [XmlRoot("Tasks")]
    public class Task : INotifyPropertyChanged
    {
        private string taskName;

        [XmlElement("TaskName")]
        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; RaisePropertyChanged("TaskName"); }
        }

        public Task() { }

        public Task(string taskname)
        {
            TaskName = taskname;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
