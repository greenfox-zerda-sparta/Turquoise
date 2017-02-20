using System;
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
        public ICommand IncrementTemperatureCommand { get; set; }
        public ICommand DecrementTemperatureCommand { get; set; }

        public ObservableCollection<Device> NorthBedroom { get; set; }

        public NorthBedroomViewModel()
        {
            InstantiateCommands();
            //Instances.LoadDevicesToRoom(NorthBedroom, ..., 02, 00);
            NorthBedroom = new ObservableCollection<Device>();
            NorthBedroom.Add(new Device { DeviceID = 01, DeviceType = 02, Floor = 02, Room = 00, Status = 70, OnOff = 1 });
            NorthBedroom.Add(new Device { DeviceID = 01, DeviceType = 03, Floor = 02, Room = 00, Status = 23, OnOff = 1 });
        }



        private void InstantiateCommands()
        {
            IncrementLightCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 0, 10));
            DecrementLightCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 0, -10));
            TurnLightOnOffCommand = new NavigationCommands(param => ChangeOnOffProperty(NorthBedroom, 0, 100));
            IncrementTemperatureCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 1, 1));
            DecrementTemperatureCommand = new NavigationCommands(param => ChangeStatusProperty(NorthBedroom, 1, -1));
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
    }
}
