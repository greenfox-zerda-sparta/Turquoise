using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeUI
{
    class HomeViewModel
    {
        public ObservableCollection<Device> Devices
        {
            get;
            set;
        }

        public void LoadDevices()
        {
            ObservableCollection<Device> devices = new ObservableCollection<Device>();

            devices.Add(new Device { deviceID = "01", deviceType = "01", floor = "02", room = "01", status = "", onOff = "01" });
            devices.Add(new Device { deviceID = "01", deviceType = "03", floor = "03", room = "02", status = "23", onOff = "01" });
            devices.Add(new Device { deviceID = "01", deviceType = "06", floor = "01", room = "01", status = "00", onOff = "01" });

            Devices = devices;
        }
    }
}
