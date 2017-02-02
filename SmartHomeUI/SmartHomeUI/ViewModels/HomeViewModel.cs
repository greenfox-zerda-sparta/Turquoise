using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHomeUI
{
    class HomeViewModel
    {
        public static string test;
        public ObservableCollection<Device> Devices
        {
            get;
            set;
        }

        public HomeViewModel()
        {
            LoadDevices();
            Communication();
        }

        public void Communication()
        {
            Communication comLink = new Communication();
            comLink.connectToBroadcast();
            comLink.send("00000000");
            comLink.send("Hello evoSoft!");
            test = comLink.recieve();
        }

        public void LoadDevices()
        {
            ObservableCollection<Device> devices = new ObservableCollection<Device>();

            devices.Add(new Device { deviceID = "01", deviceType = "01", floor = "02", room = "01", status = "100", onOff = "01" });
            devices.Add(new Device { deviceID = "01", deviceType = test, floor = "03", room = "02", status = "23", onOff = "01" });
            devices.Add(new Device { deviceID = "01", deviceType = "06", floor = "01", room = "01", status = "00", onOff = "01" });

            Devices = devices;
        }
    }
}
