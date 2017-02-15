using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SmartHomeUI
{
    class RoomViewModel
    {
        public ObservableCollection<Device> NorthBedroom { get; set; }
        public ObservableCollection<Device> SouthBedroom { get; set; }
        public ObservableCollection<Device> Kidroom { get; set; }
        public ObservableCollection<Device> FloorBathroom { get; set; }
        public ObservableCollection<Device> LivingRoom { get; set; }
        public ObservableCollection<Device> Kitchen { get; set; }
        public ObservableCollection<Device> GroundfloorBahtroom { get; set; }
        public ObservableCollection<Device> Garage { get; set; }
        public ObservableCollection<Device> Workshop { get; set; }

        public RoomViewModel()
        {
            LoadRooms();
        }

        private void LoadDevicesToRooms(ObservableCollection<Device> room, ObservableCollection<Device> devices, string floorID, string roomID)
        {
            room = new ObservableCollection<Device>();
            for (int i = 0; i < devices.Count; i++)
            {
                if (devices[i].Floor == floorID && devices[i].Room == roomID)
                {
                    room.Add(devices[i]);
                }
            }
        }

        private void LoadRooms()
        {
            //LoadDevicesToRooms(NorthBedroom, ... , "02", "00");
            //LoadDevicesToRooms(SouthBedroom, ... , "02", "01");
            //LoadDevicesToRooms(Kidroom, ... , "02", "02");
            //LoadDevicesToRooms(FloorBathroom, ... , "02", "03");
            //LoadDevicesToRooms(LivingRoom, ... , "01", "00");
            //LoadDevicesToRooms(Kitchen, ... , "01", "01");
            //LoadDevicesToRooms(GroundfloorBahtroom, ... , "01", "02");
            //LoadDevicesToRooms(Garage, ... , "00", "00");
            //LoadDevicesToRooms(Workshop, ... , "00", "01");
        }
    }
}
