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
    [XmlRoot("Devices")]
    public class Device : INotifyPropertyChanged
    {
        private int deviceID, deviceType, floor, room, status, onOff, connected;

        [XmlElement("DeviceType")]
        public int DeviceType
        {
            get { return deviceType; }
            set { deviceType = value; RaisePropertyChanged("DeviceType"); }
        }

        [XmlElement("DeviceID")]
        public int DeviceID 
        {
            get { return deviceID; }
            set { deviceID = value; RaisePropertyChanged("DeviceID"); }
        }

        [XmlElement("Floor")]
        public int Floor
        {
            get { return floor; }
            set { floor = value; RaisePropertyChanged("Floor"); }
        }

        [XmlElement("Room")]
        public int Room
        {
            get { return room; }
            set { room = value; RaisePropertyChanged("Room"); }
        }

        [XmlElement("Status")]
        public int Status
        {
            get { return status; }
            set 
            {
                if(value <= 100 && value >= 0) 
                {
                    status = value;
                    RaisePropertyChanged("Status");
                }
            }
        }

        [XmlElement("OnOff")]
        public int OnOff
        {
            get { return onOff; }
            set { onOff = value; RaisePropertyChanged("OnOff"); }
        }

        [XmlElement("Connected")]
        public int Connected 
        {
            get { return connected; }
            set { connected = value; RaisePropertyChanged("Connected"); }
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
