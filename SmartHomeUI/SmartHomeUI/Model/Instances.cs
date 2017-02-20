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

    public enum Timers
    {
        oneSecond = 1, oneMinute = 60, halfHour = 1800, oneHour = 3600, oneDay = 86400
    }

    static class Instances
    {
        static public List<object> ViewModels;
        static public List<object> RoomViews;
        static public List<object> Models;

        static Instances()
        {
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
            ViewModels.Add(new NorthBedroomView());
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

        public static void refreshData(Action timedMethod, object targetData, int waitSeconds)
        {
            if (targetData == null)
            {
                timedMethod();
            }
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(waitSeconds);
            timer.IsEnabled = true;
            timer.Tick += (s, e) => { timedMethod(); };
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
    }
}
