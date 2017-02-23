using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;

namespace SmartHomeUI
{
    class GearViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> DeviceTypes { get; set; }
        public ObservableCollection<string> Rooms { get; set; }
        private int deviceTypeIndex, roomIndex;

        public int DeviceTypeIndex
        {
            get { return deviceTypeIndex; }
            set { deviceTypeIndex = value; RaisePropertyChanged("DeviceTypeIndex"); }
        }

        public int RoomIndex
        {
            get { return roomIndex; }
            set { roomIndex = value; RaisePropertyChanged("RoomIndex"); }
        }

        public ICommand AddDeviceCommand { get; set; }
        public ICommand SetFavScenarioCommand { get; set; }

        public GearViewModel()
        {
            InitiateListsAndCommands();
        }

        public void InitiateListsAndCommands()
        {
            Rooms = new ObservableCollection<string>() { "All", "Garage", "Workshop", "Kitchen", "Living Room", "Half Bathroom", "North Bedroom", "South Bedroom", "Kid's Room", "Bathroom" };
            DeviceTypes = new ObservableCollection<string>() { "All", "Lamp", "Heating", "Cooling", "Blinds", "Alarm" };
            AddDeviceCommand = new NavigationCommands(param => AddDevice(Instances.AllDevice));
            SetFavScenarioCommand = new NavigationCommands(SetFavScenario);
        }

        public void AddDevice(ObservableCollection<Device> AllDevice)
        {
            Instances.AllDevice.Add(new Device() { DeviceType = DeviceTypeIndex, Room = RoomIndex });
        }

        public void SetFavScenario(object obj)
        {
            (Instances.Models[(int)Models.XMLHandler] as XMLHandler).devicesToXML(Instances.AllDevice, "Scenarios/Favorite.xml");
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
