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
        private string DeviceID;
        private string DeviceType;
        private string Floor;
        private string Room;
        private string Status;
        private string OnOff;

        public string deviceID
        {
            get
            {
                return DeviceID;
            }
            set
            {
                if (DeviceID != value)
                {
                    DeviceID = value;
                    RaisePropertyChanged("DeviceID");
                }
            }
        }

        public string deviceType
        {
            get
            {
                return DeviceType;
            }
            set
            {
                if (DeviceType != value)
                {
                    DeviceType = value;
                    this.RaisePropertyChanged("DeviceType");
                }
            }
        }

        public string floor
        {
            get
            {
                return Floor;
            }
            set
            {
                if (Floor != value)
                {
                    Floor = value;
                    RaisePropertyChanged("Floor");
                }
            }
        }

        public string room
        {
            get
            {
                return Room;
            }
            set
            {
                if (Room != value)
                {
                    Room = value;
                    RaisePropertyChanged("Room");
                }
            }
        }

        public string status
        {
            get
            {
                return Status;
            }
            set
            {
                if (Status != value)
                {
                    Status = value;
                    RaisePropertyChanged("Status");
                }
            }
        }

        public string onOff
        {
            get
            {
                return OnOff;
            }
            set
            {
                if (OnOff != value)
                {
                    OnOff = value;
                    RaisePropertyChanged("OnOff");
                }
            }
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
