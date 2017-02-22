using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SmartHomeUI
{
    public enum ViewModels
    {
        HomeVM, HistVM, TempVM, LockVM, GearVM, RoomNavVM, NavVM
    }

    public enum RoomViews
    {
        NorthBedroom, SouthBedroom, KidRoom, FloorBathroom, LivingRoom, Kitchen, GroundfloorBathroom, Garage, Workshop
    }

    public enum Models
    {
        Log, InfoBar, Communication
    }

    public enum DeviceType 
    {
        All, Lamps, Heating, Cooling, Blinds, Alarm
    }

    public enum Floor 
    {
        All, Basement, Groundfloor, FirstFloor
    }

    public enum Room 
    {
        All, Garage, Workshop, Kitchen, LivingRoom, HalfBathroom, NorthBedroom, SouthBedroom, KidRoom, Bathroom
    }

  public enum Timers
    {
        oneSecond = 1, oneMinute = 60, halfHour = 1800, oneHour = 3600, oneDay = 86400
    }

    static class Instances
    {
        static public List<object> ViewModels;
        static public List<object> RoomViews;
        static public List<object> Models;
        static public ObservableCollection<Device> AllDevice;

        static Instances()
        {
            InstantiateAllDevice();
            InstantiateModels();
            InstantiateRoomViews();
            InstantiateViewModels();
        }

        private static void InstantiateViewModels()
        {
            ViewModels = new List<object>();
            ViewModels.Add(new HomeViewModel());
            ViewModels.Add(new HistViewModel());
            ViewModels.Add(new TempViewModel());
            ViewModels.Add(new LockViewModel());
            ViewModels.Add(new GearViewModel());
            ViewModels.Add(new RoomNavigationViewModel());
            ViewModels.Add(new MainNavigationViewModel());
        }

        private static void InstantiateRoomViews()
        {
            RoomViews = new List<object>();
            RoomViews.Add(new NorthBedroomViewModel());
            RoomViews.Add(new SouthBedroomViewModel());
            RoomViews.Add(new KidRoomViewModel());
            RoomViews.Add(new FloorBathroomViewModel());
            RoomViews.Add(new LivingRoomViewModel());
            RoomViews.Add(new KitchenViewModel());
            RoomViews.Add(new GroundfloorBathroomViewModel());
            RoomViews.Add(new GarageViewModel());
            RoomViews.Add(new WorkshopViewModel());
        }

        private static void InstantiateModels()
        {
            Models = new List<object>();
            Models.Add(new Logger());
            Models.Add(new InfoBar());
            Models.Add(new Communication());
        }

        private static void InstantiateAllDevice() 
        {
            AllDevice = new ObservableCollection<Device>(); 
            //Alarm
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Alarm, DeviceID = 01, Floor = (int)Floor.All, Room = (int)Room.All, Status = 0, OnOff = 1, Connected = 1 });
            //Lamps
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Lamps, DeviceID = 01, Floor = (int)Floor.Basement, Room = (int)Room.Garage, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Lamps, DeviceID = 02, Floor = (int)Floor.Basement, Room = (int)Room.Workshop, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Lamps, DeviceID = 03, Floor = (int)Floor.Groundfloor, Room = (int)Room.Kitchen, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Lamps, DeviceID = 04, Floor = (int)Floor.Groundfloor, Room = (int)Room.LivingRoom, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Lamps, DeviceID = 05, Floor = (int)Floor.Groundfloor, Room = (int)Room.HalfBathroom, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Lamps, DeviceID = 06, Floor = (int)Floor.FirstFloor, Room = (int)Room.NorthBedroom, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Lamps, DeviceID = 07, Floor = (int)Floor.FirstFloor, Room = (int)Room.SouthBedroom, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Lamps, DeviceID = 08, Floor = (int)Floor.FirstFloor, Room = (int)Room.KidRoom, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Lamps, DeviceID = 09, Floor = (int)Floor.FirstFloor, Room = (int)Room.Bathroom, Status = 100, OnOff = 1, Connected = 1 });

            //Heating
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Heating, DeviceID = 01, Floor = (int)Floor.Basement, Room = (int)Room.Garage, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Heating, DeviceID = 02, Floor = (int)Floor.Basement, Room = (int)Room.Workshop, Status = 22, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Heating, DeviceID = 03, Floor = (int)Floor.Groundfloor, Room = (int)Room.Kitchen, Status = 22, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Heating, DeviceID = 04, Floor = (int)Floor.Groundfloor, Room = (int)Room.LivingRoom, Status = 23, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Heating, DeviceID = 05, Floor = (int)Floor.Groundfloor, Room = (int)Room.HalfBathroom, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Heating, DeviceID = 06, Floor = (int)Floor.FirstFloor, Room = (int)Room.NorthBedroom, Status = 23, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Heating, DeviceID = 07, Floor = (int)Floor.FirstFloor, Room = (int)Room.SouthBedroom, Status = 22, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Heating, DeviceID = 08, Floor = (int)Floor.FirstFloor, Room = (int)Room.KidRoom, Status = 20, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Heating, DeviceID = 09, Floor = (int)Floor.FirstFloor, Room = (int)Room.Bathroom, Status = 20, OnOff = 1, Connected = 1 });

            //Cooling
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Cooling, DeviceID = 01, Floor = (int)Floor.Basement, Room = (int)Room.Garage, Status = 21, OnOff = 0, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Cooling, DeviceID = 02, Floor = (int)Floor.Basement, Room = (int)Room.Workshop, Status = 21, OnOff = 0, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Cooling, DeviceID = 03, Floor = (int)Floor.Groundfloor, Room = (int)Room.Kitchen, Status = 21, OnOff = 0, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Cooling, DeviceID = 04, Floor = (int)Floor.Groundfloor, Room = (int)Room.LivingRoom, Status = 21, OnOff = 0, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Cooling, DeviceID = 05, Floor = (int)Floor.Groundfloor, Room = (int)Room.HalfBathroom, Status = 21, OnOff = 0, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Cooling, DeviceID = 06, Floor = (int)Floor.FirstFloor, Room = (int)Room.NorthBedroom, Status = 21, OnOff = 0, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Cooling, DeviceID = 07, Floor = (int)Floor.FirstFloor, Room = (int)Room.SouthBedroom, Status = 21, OnOff = 0, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Cooling, DeviceID = 08, Floor = (int)Floor.FirstFloor, Room = (int)Room.KidRoom, Status = 21, OnOff = 0, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Cooling, DeviceID = 09, Floor = (int)Floor.FirstFloor, Room = (int)Room.Bathroom, Status = 21, OnOff = 0, Connected = 1 });

            //Blinds
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Blinds, DeviceID = 01, Floor = (int)Floor.Basement, Room = (int)Room.Garage, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Blinds, DeviceID = 02, Floor = (int)Floor.Basement, Room = (int)Room.Workshop, Status = 0, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Blinds, DeviceID = 03, Floor = (int)Floor.Groundfloor, Room = (int)Room.Kitchen, Status = 0, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Blinds, DeviceID = 04, Floor = (int)Floor.Groundfloor, Room = (int)Room.LivingRoom, Status = 0, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Blinds, DeviceID = 05, Floor = (int)Floor.Groundfloor, Room = (int)Room.HalfBathroom, Status = 0, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Blinds, DeviceID = 06, Floor = (int)Floor.FirstFloor, Room = (int)Room.NorthBedroom, Status = 0, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Blinds, DeviceID = 07, Floor = (int)Floor.FirstFloor, Room = (int)Room.SouthBedroom, Status = 0, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Blinds, DeviceID = 08, Floor = (int)Floor.FirstFloor, Room = (int)Room.KidRoom, Status = 0, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.Blinds, DeviceID = 09, Floor = (int)Floor.FirstFloor, Room = (int)Room.Bathroom, Status = 0, OnOff = 1, Connected = 1 });

            //All device
            AllDevice.Add(new Device { DeviceType = (int)DeviceType.All, DeviceID = 00, Floor = (int)Floor.All, Room = (int)Room.All, Status = 0, OnOff = 0, Connected = 1 });
        }


        public static ObservableCollection<Device> LoadDevicesToRoom(ObservableCollection<Device> AllDevice, int roomID) 
        {
            ObservableCollection<Device> room = new ObservableCollection<Device>();
            for(int i = 1; i < AllDevice.Count; ++i)
            {
                if(AllDevice[i].Room == roomID)
                {
                  room.Add(AllDevice[i]);
                }
            }
          return room;
        }

        public static void refreshData(Action timedMethod, object targetData, int waitSeconds) 
        {
            if(targetData == null)
            {
                timedMethod();
            }
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(waitSeconds);
            timer.IsEnabled = true;
            timer.Tick += (s, e) => { timedMethod(); };
        }
    }
}
