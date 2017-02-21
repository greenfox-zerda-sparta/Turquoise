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
            InstantiateModels();
            InstantiateRoomViews();
            InstantiateViewModels();
            InstantiateAllDevice();
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
            //ViewModels.Add(new NorthBedroomView());
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
 
        public static void InstantiateAllDevice() 
        {
            AllDevice = new ObservableCollection<Device>(); 
            //Alarm
            AllDevice.Add(new Device { DeviceType = 05, DeviceID = 01, Floor = 00, Room = 00, Status = 0, OnOff = 1, Connected = 1 });
            //Lamps
            AllDevice.Add(new Device { DeviceType = 01, DeviceID = 01, Floor = 01, Room = 01, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 01, DeviceID = 02, Floor = 01, Room = 02, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 01, DeviceID = 03, Floor = 02, Room = 03, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 01, DeviceID = 04, Floor = 02, Room = 04, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 01, DeviceID = 05, Floor = 02, Room = 05, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 01, DeviceID = 06, Floor = 03, Room = 06, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 01, DeviceID = 07, Floor = 03, Room = 07, Status = 100, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 01, DeviceID = 08, Floor = 03, Room = 08, Status = 100, OnOff = 1, Connected = 1 });
            //Heating
            AllDevice.Add(new Device { DeviceType = 02, DeviceID = 01, Floor = 01, Room = 01, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 02, DeviceID = 02, Floor = 01, Room = 02, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 02, DeviceID = 03, Floor = 02, Room = 03, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 02, DeviceID = 04, Floor = 02, Room = 04, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 02, DeviceID = 05, Floor = 02, Room = 05, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 02, DeviceID = 06, Floor = 03, Room = 06, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 02, DeviceID = 07, Floor = 03, Room = 07, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 02, DeviceID = 08, Floor = 03, Room = 08, Status = 21, OnOff = 1, Connected = 1 });
            //Cooling
            AllDevice.Add(new Device { DeviceType = 03, DeviceID = 01, Floor = 01, Room = 01, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 03, DeviceID = 02, Floor = 01, Room = 02, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 03, DeviceID = 03, Floor = 02, Room = 03, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 03, DeviceID = 04, Floor = 02, Room = 04, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 03, DeviceID = 05, Floor = 02, Room = 05, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 03, DeviceID = 06, Floor = 03, Room = 06, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 03, DeviceID = 07, Floor = 03, Room = 07, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 03, DeviceID = 08, Floor = 03, Room = 08, Status = 21, OnOff = 1, Connected = 1 });
            //Blinds
            AllDevice.Add(new Device { DeviceType = 04, DeviceID = 01, Floor = 01, Room = 01, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 04, DeviceID = 02, Floor = 01, Room = 02, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 04, DeviceID = 03, Floor = 02, Room = 03, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 04, DeviceID = 04, Floor = 02, Room = 04, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 04, DeviceID = 05, Floor = 02, Room = 05, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 04, DeviceID = 06, Floor = 03, Room = 06, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 04, DeviceID = 07, Floor = 03, Room = 07, Status = 21, OnOff = 1, Connected = 1 });
            AllDevice.Add(new Device { DeviceType = 04, DeviceID = 08, Floor = 03, Room = 08, Status = 21, OnOff = 1, Connected = 1 });
            //All device ?
            //AllDevice.Add(new Device { DeviceType = 00, DeviceID = 00, Floor = 00, Room = 00, Status = 0, OnOff = 0, Connected = 1 });
        }

        public static void LoadDevicesToRoom(ObservableCollection<Device> room, ObservableCollection<Device> devices, int floorID, int roomID)
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

        public static void LoadDevicesToRoom2(ObservableCollection<Device> room, ObservableCollection<Device> AllDevice, int roomID) 
        {
          room = new ObservableCollection<Device>();
          for(int i = 01; i < AllDevice.Count; ++i) {
            if(AllDevice[i].Room == roomID) 
            {
              room.Add(AllDevice[i]);
            }
          }
        }

    public static void refreshData(Action timedMethod, object targetData, int waitSeconds) 
        {
          if(targetData == null) {
            timedMethod();
          }
          DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
          timer.Interval = TimeSpan.FromSeconds(waitSeconds);
          timer.IsEnabled = true;
          timer.Tick += (s, e) => { timedMethod(); };
        }
  }
}
