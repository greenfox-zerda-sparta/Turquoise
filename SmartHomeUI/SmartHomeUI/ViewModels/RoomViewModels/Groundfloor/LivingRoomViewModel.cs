﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;

namespace SmartHomeUI
{
    class LivingRoomViewModel : INotifyPropertyChanged
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

    private ObservableCollection<Device> livingRoom = new ObservableCollection<Device>();
    public ObservableCollection<Device> LivingRoom
        {
        get { return livingRoom; }
        set { livingRoom = value; RaisePropertyChanged("LivingRoom"); }
    }

    public ObservableCollection<string> ConnectionStatus { get; set; }


    public LivingRoomViewModel() {
     LivingRoom = new ObservableCollection<Device>(Instances.LoadDevicesToRoom(Instances.AllDevice, 4));
      InstantiateCommands();
      InstantiateConnectionStatus();
    }



    private void InstantiateCommands() {
      IncrementLightCommand = new NavigationCommands(param => ChangeStatusProperty(LivingRoom, 0, 10));
      DecrementLightCommand = new NavigationCommands(param => ChangeStatusProperty(LivingRoom, 0, -10));
      TurnLightOnOffCommand = new NavigationCommands(param => ChangeOnOffProperty(LivingRoom, 0, 100));
      IncrementHeatingCommand = new NavigationCommands(param => ChangeStatusProperty(LivingRoom, 1, 1));
      DecrementHeatingCommand = new NavigationCommands(param => ChangeStatusProperty(LivingRoom, 1, -1));
      IncrementCoolingCommand = new NavigationCommands(param => ChangeStatusProperty(LivingRoom, 2, 1));
      DecrementCoolingCommand = new NavigationCommands(param => ChangeStatusProperty(LivingRoom, 2, -1));
      IncrementBlindsCommand = new NavigationCommands(param => ChangeStatusProperty(LivingRoom, 3, 10));
      DecrementBlindsCommand = new NavigationCommands(param => ChangeStatusProperty(LivingRoom, 3, -10));
      TurnBlindsOnOffCommand = new NavigationCommands(param => ChangeOnOffProperty(LivingRoom, 3, 100));
    }

    private void ChangeStatusProperty(ObservableCollection<Device> room, int deviceIndex, int changeAmount) {
      room[deviceIndex].Status += changeAmount;
    }

    private void ChangeOnOffProperty(ObservableCollection<Device> room, int deviceIndex, int changeAmount) {
      if(room[deviceIndex].Status == 0) {
        room[deviceIndex].Status += 100;
      } else {
        room[deviceIndex].Status = 0;
      }
    }


    private void InstantiateConnectionStatus() {
      ConnectionStatus = new ObservableCollection<string>();
      foreach(Device device in LivingRoom) {
        if(device.Connected == 1) {
          ConnectionStatus.Add("Connected");
        } else {
          ConnectionStatus.Add("Disconnected");
        }
      }
    }
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
