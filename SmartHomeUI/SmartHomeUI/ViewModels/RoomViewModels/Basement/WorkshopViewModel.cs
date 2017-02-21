using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SmartHomeUI
{
    class WorkshopViewModel 
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

    public ObservableCollection<Device> Workshop { get; set; }
    public ObservableCollection<string> ConnectionStatus { get; set; }


    public WorkshopViewModel() {
      InstantiateCommands();

      //Instances.LoadDevicesToRoom(Workshop, ..., 02, 00);
      Workshop = new ObservableCollection<Device>();
      Workshop.Add(new Device { DeviceID = 01, DeviceType = 01, Floor = 03, Room = 01, Status = 70, OnOff = 1, Connected = 1 });
      Workshop.Add(new Device { DeviceID = 01, DeviceType = 03, Floor = 03, Room = 01, Status = 99, OnOff = 1, Connected = 1 });
      Workshop.Add(new Device { DeviceID = 01, DeviceType = 04, Floor = 03, Room = 01, Status = 18, OnOff = 1, Connected = 0 });
      Workshop.Add(new Device { DeviceID = 01, DeviceType = 02, Floor = 03, Room = 01, Status = 10, OnOff = 1, Connected = 1 });
      InstantiateConnectionStatus();
    }



    private void InstantiateCommands() {
      IncrementLightCommand = new NavigationCommands(param => ChangeStatusProperty(Workshop, 0, 10));
      DecrementLightCommand = new NavigationCommands(param => ChangeStatusProperty(Workshop, 0, -10));
      TurnLightOnOffCommand = new NavigationCommands(param => ChangeOnOffProperty(Workshop, 0, 100));
      IncrementHeatingCommand = new NavigationCommands(param => ChangeStatusProperty(Workshop, 1, 1));
      DecrementHeatingCommand = new NavigationCommands(param => ChangeStatusProperty(Workshop, 1, -1));
      IncrementCoolingCommand = new NavigationCommands(param => ChangeStatusProperty(Workshop, 2, 1));
      DecrementCoolingCommand = new NavigationCommands(param => ChangeStatusProperty(Workshop, 2, -1));
      IncrementBlindsCommand = new NavigationCommands(param => ChangeStatusProperty(Workshop, 3, 10));
      DecrementBlindsCommand = new NavigationCommands(param => ChangeStatusProperty(Workshop, 3, -10));
      TurnBlindsOnOffCommand = new NavigationCommands(param => ChangeOnOffProperty(Workshop, 3, 100));
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
      foreach(Device device in Workshop) {
        if(device.Connected == 1) {
          ConnectionStatus.Add("Connected");
        } else {
          ConnectionStatus.Add("Disconnected");
        }
      }
    }
  }
}
