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
            (Instances.RoomViews[(int)RoomViews.Workshop] as WorkshopViewModel).Workshop = Instances.LoadDevicesToRoom(Instances.AllDevice, 2);
            (Instances.RoomViews[(int)RoomViews.Kitchen] as KitchenViewModel).Kitchen = Instances.LoadDevicesToRoom(Instances.AllDevice, 3);
            (Instances.RoomViews[(int)RoomViews.LivingRoom] as LivingRoomViewModel).LivingRoom = Instances.LoadDevicesToRoom(Instances.AllDevice, 4);
            (Instances.RoomViews[(int)RoomViews.GroundfloorBathroom] as GroundfloorBathroomViewModel).GroundfloorBathroom = Instances.LoadDevicesToRoom(Instances.AllDevice, 5);
            (Instances.RoomViews[(int)RoomViews.NorthBedroom] as NorthBedroomViewModel).NorthBedroom = Instances.LoadDevicesToRoom(Instances.AllDevice, 6);
            (Instances.RoomViews[(int)RoomViews.SouthBedroom] as SouthBedroomViewModel).SouthBedroom = Instances.LoadDevicesToRoom(Instances.AllDevice, 7);
            (Instances.RoomViews[(int)RoomViews.KidRoom] as KidRoomViewModel).KidBedroom = Instances.LoadDevicesToRoom(Instances.AllDevice, 8);
            (Instances.RoomViews[(int)RoomViews.FloorBathroom] as FloorBathroomViewModel).FloorBathroom = Instances.LoadDevicesToRoom(Instances.AllDevice, 9);
        }
    }
}