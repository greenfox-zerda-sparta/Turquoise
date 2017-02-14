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
        HomeVM, RoomVM, HistVM, TempVM, LockVM, GearVM, RoomNavVM, NavVM
    }

    public enum RoomViews
    {
        NorthBedroom, SouthBedroom, KidRoom, FloorBathroom, LivingRoom, Kitchen, GroundfloorBathroom, Garage, Workshop
    }

    public enum Models
    {
        InfoBar, Communication, Log
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
            ViewModels.Add(new RoomViewModel());
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
            RoomViews.Add(new NorthBedroomView());
            RoomViews.Add(new SouthBedroomView());
            RoomViews.Add(new KidRoomView());
            RoomViews.Add(new FloorBathroomView());
            RoomViews.Add(new LivingRoomView());
            RoomViews.Add(new KitchenView());
            RoomViews.Add(new GroundfloorBathroomView());
            RoomViews.Add(new GarageView());
            RoomViews.Add(new WorkshopView());
        }

        private static void InstantiateModels()
        {
            Models = new List<object>();
            Models.Add(new InfoBar());
            Models.Add(new Communication());
            Models.Add(new Logger());
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
    }
}
