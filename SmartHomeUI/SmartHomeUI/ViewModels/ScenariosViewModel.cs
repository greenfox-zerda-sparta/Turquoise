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
    class ScenarioViewModel : INotifyPropertyChanged
    {
        public ICommand HomeScenarioCommand { get; set; }
        public ICommand NightScenarioCommand { get; set; }
        public ICommand AwayScenarioCommand { get; set; }
        public ICommand VacationScenarioCommand { get; set; }
        public ICommand FavoriteScenarioCommand { get; set; }

        public ScenarioViewModel()
        {
            InstantiateScenarioCommands();
        }

        private void InstantiateScenarioCommands()
        {
            HomeScenarioCommand = new NavigationCommands(LoadHomeScenario);
            NightScenarioCommand = new NavigationCommands(LoadNightScenario);
            AwayScenarioCommand = new NavigationCommands(LoadAwayScenario);
            VacationScenarioCommand = new NavigationCommands(LoadVacationScenario);
            FavoriteScenarioCommand = new NavigationCommands(LoadFavoriteScenario);
        }

        private void LoadHomeScenario(object obj)
        {
            (Instances.Models[(int)Models.Scenarios] as Scenarios).ReloadAllDevice("Scenarios/Home.xml");
            (Instances.Models[(int)Models.Scenarios] as Scenarios).ReloadAllDeviceToRoom();
            (Instances.Models[(int)Models.Log] as Logger).logToFile("Home scenario loaded");
        }

        private void LoadNightScenario(object obj)
        {
            (Instances.Models[(int)Models.Scenarios] as Scenarios).ReloadAllDevice("Scenarios/Night.xml");
            (Instances.Models[(int)Models.Scenarios] as Scenarios).ReloadAllDeviceToRoom();
            (Instances.Models[(int)Models.Log] as Logger).logToFile("Night scenario loaded");
        }

        private void LoadAwayScenario(object obj)
        {
            (Instances.Models[(int)Models.Scenarios] as Scenarios).ReloadAllDevice("Scenarios/Away.xml");
            (Instances.Models[(int)Models.Scenarios] as Scenarios).ReloadAllDeviceToRoom();
            (Instances.Models[(int)Models.Log] as Logger).logToFile("Away scenario loaded");
        }

        private void LoadVacationScenario(object obj)
        {
            (Instances.Models[(int)Models.Scenarios] as Scenarios).ReloadAllDevice("Scenarios/Vacation.xml");
            (Instances.Models[(int)Models.Scenarios] as Scenarios).ReloadAllDeviceToRoom();
            (Instances.Models[(int)Models.Log] as Logger).logToFile("Vacation scenario loaded");
        }

        private void LoadFavoriteScenario(object obj)
        {
            (Instances.Models[(int)Models.Scenarios] as Scenarios).ReloadAllDevice("Scenarios/Favorite.xml");
            (Instances.Models[(int)Models.Scenarios] as Scenarios).ReloadAllDeviceToRoom();
            (Instances.Models[(int)Models.Log] as Logger).logToFile("Favorite scenario loaded");

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
