using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace SmartHomeUI
{
    class RoomNavigationViewModel : INotifyPropertyChanged
    {
        public ICommand NBedroomCommand { get; set; }
        public ICommand SBedroomCommand { get; set; }
        public ICommand KidRoomCommand { get; set; }
        public ICommand FloorBathroomCommand { get; set; }
        public ICommand LivingRoomCommand { get; set; }
        public ICommand KitchenCommand { get; set; }
        public ICommand GroundfloorBathroomCommand { get; set; }
        public ICommand GarageCommand { get; set; }
        public ICommand WorkshopCommand { get; set; }

        private object selectedRoom = Instances.ViewModels[(int)ViewModels.HomeVM];

        public object SelectedRoom
        {
            get { return selectedRoom; }
            set { selectedRoom = value; OnPropertyChanged("SelectedRoom"); }
        }

        public RoomNavigationViewModel()
        {
            InstantiateNavigationCommands();
        }

        private void InstantiateNavigationCommands()
        {
            NBedroomCommand = new NavigationCommands(OpenNBedroom);
            SBedroomCommand = new NavigationCommands(OpenSBedroom);
            KidRoomCommand = new NavigationCommands(OpenKidRoom);
            FloorBathroomCommand = new NavigationCommands(OpenFloorBathroom);
            LivingRoomCommand = new NavigationCommands(OpenLivingRoom);
            KitchenCommand = new NavigationCommands(OpenKitchen);
            GroundfloorBathroomCommand = new NavigationCommands(OpenGroundfloorBathroom);
            GarageCommand = new NavigationCommands(OpenGarage);
            WorkshopCommand = new NavigationCommands(OpenWorkshop);
        }

        private void OpenNBedroom(object obj)
        {
            SelectedRoom = Instances.ViewModels[(int)ViewModels.HomeVM];
        }

        private void OpenSBedroom(object obj)
        {
            SelectedRoom = Instances.ViewModels[(int)ViewModels.HistVM];
        }

        private void OpenKidRoom(object obj)
        {

        }

        private void OpenFloorBathroom(object obj)
        {

        }

        private void OpenLivingRoom(object obj)
        {

        }

        private void OpenKitchen(object obj)
        {

        }

        private void OpenGroundfloorBathroom(object obj)
        {

        }

        private void OpenGarage(object obj)
        {

        }

        private void OpenWorkshop(object obj)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
