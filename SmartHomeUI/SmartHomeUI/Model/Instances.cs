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
        HistVM, HomeVM, TempVM, LockVM, GearVM, RoomNavVM, NavVM
    }

    public enum RoomViews
    {
        NorthBedroom, SouthBedroom, KidRoom, FloorBathroom, LivingRoom, Kitchen, GroundfloorBathroom, Garage, Workshop
    }

    public enum Models
    {
        XMLHandler, Log, InfoBar, Communication
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
        static public List<object> ViewModels = new List<object>();
        static public List<object> RoomViews = new List<object>();
        static public List<object> Models = new List<object>();
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
            ViewModels.Add(new HistViewModel());
            ViewModels.Add(new HomeViewModel());
            ViewModels.Add(new TempViewModel());
            ViewModels.Add(new LockViewModel());
            ViewModels.Add(new GearViewModel());
            ViewModels.Add(new RoomNavigationViewModel());
            ViewModels.Add(new MainNavigationViewModel());
        }

        private static void InstantiateRoomViews()
        {
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
            Models.Add(new Logger());
            Models.Add(new InfoBar());
            Models.Add(new Communication());
        }

        private static void InstantiateAllDevice() 
        {
            Models.Add(new XMLHandler());
            AllDevice = new ObservableCollection<Device>();
            XMLHandler test = new XMLHandler();
            test.devicesFromXML(ref AllDevice, "Devices.xml");
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
