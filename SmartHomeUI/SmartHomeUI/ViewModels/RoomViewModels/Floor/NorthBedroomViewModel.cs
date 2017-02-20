﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SmartHomeUI
{
    class NorthBedroomViewModel
    {
        public ICommand IncrementLightCommand { get; set; }
        public ICommand DecrementLightCommand { get; set; }
        public ICommand TurnLightOnOffCommand { get; set; }
        public ICommand IncrementHeatingCommand { get; set; }
        public ICommand DecrementHeatingCommand { get; set; }
        public ICommand IncrementCoolingCommand { get; set; }
        public ICommand DecrementCoolingCommand { get; set; }
        public ICommand IncrementBlindsCommand { get; set; }
        public ICommand DecrementBlindsCommand { get; set; }
        public ICommand TurnBlindsOnOffCommand { get; set; }        

        public ObservableCollection<Device> NorthBedroom { get; set; }
        public ObservableCollection<string> ConnectionStatus { get; set; }


    public NorthBedroomViewModel()
        {
            InstantiateCommands();

            //Instances.LoadDevicesToRoom(NorthBedroom, ..., 02, 00);
            NorthBedroom = new ObservableCollection<Device>();
            NorthBedroom.Add(new Device { DeviceID = 01, DeviceType = 01, Floor = 02, Room = 00, Status = 80, OnOff = 1, Connected = 1 });
            NorthBedroom.Add(new Device { DeviceID = 01, DeviceType = 03, Floor = 02, Room = 00, Status = 23, OnOff = 1, Connected = 1 });
            NorthBedroom.Add(new Device { DeviceID = 01, DeviceType = 04, Floor = 02, Room = 00, Status = 23, OnOff = 1, Connected = 0 });
            NorthBedroom.Add(new Device { DeviceID = 01, DeviceType = 02, Floor = 02, Room = 00, Status = 10, OnOff = 1, Connected = 1 });
            InstantiateConnectionStatus();
    }



        private void InstantiateCommands()
        {
            IncrementLightCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 0, 10));
            DecrementLightCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 0, -10));
            TurnLightOnOffCommand = new NavigationCommands(param => ChangeOnOffProperty(NorthBedroom, 0, 100));            
            IncrementHeatingCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 1, 1));
            DecrementHeatingCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 1, -1));
            IncrementCoolingCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 2, 1));
            DecrementCoolingCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 2, -1));
            IncrementBlindsCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 3, 10));
            DecrementBlindsCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 3, -10));
            TurnBlindsOnOffCommand = new NavigationCommands(param => ChangeOnOffProperty(NorthBedroom, 3, 100));
        }

    private void ChangeStatusProperty(ObservableCollection<Device> room, int deviceIndex, int changeAmount)
        {
            room[deviceIndex].Status += changeAmount;
        }

        private void ChangeOnOffProperty(ObservableCollection<Device> room, int deviceIndex, int changeAmount)
        {
            if (room[deviceIndex].Status == 0)
            {
                room[deviceIndex].Status += 100;
            }
            else
            {
                room[deviceIndex].Status = 0;
            }
        }
       

       private void InstantiateConnectionStatus() 
       {
           ConnectionStatus = new ObservableCollection<string>();
           foreach(Device device in NorthBedroom) 
           {
               if(device.Connected == 1)
               {
                   ConnectionStatus.Add("Connected");
               }
               else 
               {
                   ConnectionStatus.Add("Disconnected");
               }
           }
       }
    }
}
