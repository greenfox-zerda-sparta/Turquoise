using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace SmartHomeUI
{
    public class Scenarios
    {

        public void ReloadAllDevice(string filename)
        {
            Instances.AllDevice.Clear();
            (Instances.Models[(int)Models.XMLHandler] as XMLHandler).devicesFromXML(ref Instances.AllDevice, filename);
            ReloadAllDeviceToRoom();
        }

        public void ReloadAllDeviceToRoom()
        {
            (Instances.RoomViews[(int)RoomViews.Garage] as GarageViewModel).Garage = Instances.LoadDevicesToRoom(Instances.AllDevice, 1);
            Instances.LoadDevicesToRoom(Instances.AllDevice, 2);
            Instances.LoadDevicesToRoom(Instances.AllDevice, 3);
            Instances.LoadDevicesToRoom(Instances.AllDevice, 4);
            Instances.LoadDevicesToRoom(Instances.AllDevice, 5);
            Instances.LoadDevicesToRoom(Instances.AllDevice, 6);
            Instances.LoadDevicesToRoom(Instances.AllDevice, 7);
            Instances.LoadDevicesToRoom(Instances.AllDevice, 8);
            Instances.LoadDevicesToRoom(Instances.AllDevice, 9);
        }
    }
}