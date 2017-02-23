using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SmartHomeUI
{
    class GarageViewModel 
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
        public ICommand GarageDoorCommand { get; set; }
    
        public ObservableCollection<Device> Garage { get; set; }
        public ObservableCollection<string> ConnectionStatus { get; set; }
        public ObservableCollection<string> GarageDoorStatus { get; set; }


        public GarageViewModel()
        {
            Garage = new ObservableCollection<Device>(Instances.LoadDevicesToRoom(Instances.AllDevice, 1));
            InstantiateCommands();
            InstantiateConnectionStatus();
            InstantiateGarageDoorStatus();
        }



        private void InstantiateCommands()
        {
            IncrementLightCommand = new NavigationCommands(param => ChangeStatusProperty(Garage, 0, 10));
            DecrementLightCommand = new NavigationCommands(param => ChangeStatusProperty(Garage, 0, -10));
            TurnLightOnOffCommand = new NavigationCommands(param => ChangeOnOffProperty(Garage, 0, 100));
            IncrementHeatingCommand = new NavigationCommands(param => ChangeStatusProperty(Garage, 1, 1));
            DecrementHeatingCommand = new NavigationCommands(param => ChangeStatusProperty(Garage, 1, -1));
            IncrementCoolingCommand = new NavigationCommands(param => ChangeStatusProperty(Garage, 2, 1));
            DecrementCoolingCommand = new NavigationCommands(param => ChangeStatusProperty(Garage, 2, -1));
            GarageDoorCommand = new NavigationCommands(param => ChangeOnOffProperty(Garage, 3, 100));
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
            if (room[deviceIndex].DeviceType == 04 && room[deviceIndex].Status == 100)
            {
                GarageDoorStatus[0] = "Closed";
            }
            else if (room[deviceIndex].DeviceType == 04 && room[deviceIndex].Status == 0)
            {
                GarageDoorStatus[0] = "Open";
            }
        }


        private void InstantiateConnectionStatus() 
        {
            ConnectionStatus = new ObservableCollection<string>();
            foreach(Device device in Garage) {
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

        private void InstantiateGarageDoorStatus()
        {
            GarageDoorStatus = new ObservableCollection<string>();
            if (Garage[3].DeviceType == 04 && Garage[3].Status == 100)
            {
                GarageDoorStatus.Add("Closed");
            }
            else if (Garage[3].DeviceType == 04 && Garage[3].Status == 0)
            {
                GarageDoorStatus.Add("Open");
            }
        }
    }
}
