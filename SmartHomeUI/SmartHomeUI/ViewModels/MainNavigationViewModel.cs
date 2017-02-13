using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartHomeUI
{
    public class MainNavigationViewModel : INotifyPropertyChanged
    {
        public ICommand HomeCommand { get; set; }
        public ICommand RoomCommand { get; set; }
        public ICommand HistCommand { get; set; }
        public ICommand TempCommand { get; set; }
        public ICommand LockCommand { get; set; }
        public ICommand GearCommand { get; set; }

        private object selectedViewModel = Instances.ViewModels[(int)ViewModels.HomeVM];

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        public MainNavigationViewModel()
        {
            InstantiateNavigationCommands();
        }

        private void InstantiateNavigationCommands()
        {
            HomeCommand = new NavigationCommands(OpenHome);
            RoomCommand = new NavigationCommands(OpenRoom);
            HistCommand = new NavigationCommands(OpenHist);
            TempCommand = new NavigationCommands(OpenTemp);
            LockCommand = new NavigationCommands(OpenLock);
            GearCommand = new NavigationCommands(OpenGear);
        }

        private void OpenHome(object obj)
        {
            SelectedViewModel = Instances.ViewModels[(int)ViewModels.HomeVM];
            (Instances.Models[(int)Models.Log] as Logger).logToFile("Changed to Home screen");
        }

        private void OpenRoom(object obj)
        {
            SelectedViewModel = Instances.ViewModels[(int)ViewModels.RoomNavVM];
        }

        private void OpenHist(object obj)
        {
            SelectedViewModel = Instances.ViewModels[(int)ViewModels.HistVM];
        }

        private void OpenTemp(object obj)
        {
            SelectedViewModel = Instances.ViewModels[(int)ViewModels.TempVM];
        }

        private void OpenLock(object obj)
        {
            SelectedViewModel = Instances.ViewModels[(int)ViewModels.LockVM];
        }

        private void OpenGear(object obj)
        {
            SelectedViewModel = Instances.ViewModels[(int)ViewModels.GearVM];
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
