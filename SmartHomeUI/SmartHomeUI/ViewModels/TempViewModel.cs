using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SmartHomeUI
{
    class TempViewModel : INotifyPropertyChanged
    {
        private string filecontent;
        public string fileContent
        {
            get { return filecontent; }
            set { filecontent = value; RaisePropertyChanged("fileContent"); }
        }

        public TempViewModel()
        {
            fileContent = (Instances.Models[(int)Models.Log] as Logger).fileContent("log.txt");
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
