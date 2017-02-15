using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SmartHomeUI
{

    class Device : INotifyPropertyChanged
    {
        private string deviceID, deviceType, floor, room, status, onOff;

        public string DeviceID
        {
            get { return deviceID; }
            set { deviceID = value; RaisePropertyChanged("DeviceID"); }
        }

        public string DeviceType
        {
            get { return deviceType; }
            set { deviceType = value; RaisePropertyChanged("DeviceType"); }
        }

        public string Floor
        {
            get { return floor; }
            set { floor = value; RaisePropertyChanged("Floor"); }
        }

        public string Room
        {
            get { return room; }
            set { room = value; RaisePropertyChanged("Room"); }
        }

        public string Status
        {
            get { return status; }
            set { status = value; RaisePropertyChanged("Status"); }
        }

        public string OnOff
        {
            get { return onOff; }
            set { onOff = value; RaisePropertyChanged("OnOff"); }
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
