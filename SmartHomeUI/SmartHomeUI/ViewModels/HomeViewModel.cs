using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartHomeUI
{
    class HomeViewModel
    {
        public ObservableCollection<string> Consumptions { get; set; }
        public ObservableCollection<Task> DailyTasks { get; set; }
        public ICommand SetAlarmCommand { get; set; }

        public HomeViewModel()
        {
            SetAlarmCommand = new NavigationCommands(param => SetAlarm());
            Instances.refreshData(getConsumptions, Consumptions, (int)Timers.halfHour);
            getDailyTasks();
        }

        public void getDailyTasks()
        {
            DailyTasks = (Instances.ViewModels[(int)ViewModels.HistVM] as HistViewModel).DailyTasks;
        }

        public void getConsumptions()
        {
            ObservableCollection<string> consumptions = new ObservableCollection<string>();
            //(Instances.Models[(int)Models.Communication] as Communication).connectToBroadcast();

            //(Instances.Models[(int)Models.Communication] as Communication).send("watercons_cmd");
            //consumptions.Add(((Instances.Models[(int)Models.Communication] as Communication).recieve()).ToString());

            //(Instances.Models[(int)Models.Communication] as Communication).send("month_electricity_cmd");
            //consumptions.Add(((Instances.Models[(int)Models.Communication] as Communication).recieve()).ToString());

            //(Instances.Models[(int)Models.Communication] as Communication).send("actual_electricity_cmd");
            //consumptions.Add(((Instances.Models[(int)Models.Communication] as Communication).recieve()).ToString());

            //(Instances.Models[(int)Models.Communication] as Communication).closeConnection();

            consumptions.Add((3.9).ToString());
            consumptions.Add((4.17).ToString());
            consumptions.Add((613).ToString());

            Consumptions = consumptions;
            (Instances.Models[(int)Models.Log] as Logger).logToFile("Home screen: Fetched consumption data from server");
        }

        public void SetAlarm()
        {
            if (Instances.AllDevice[0].Status == 0)
            {
                Instances.AllDevice[0].Status = 1;
            }
            else if (Instances.AllDevice[0].Status == 1)
            {
                Instances.AllDevice[0].Status = 0;
            }
            (Instances.Models[(int)Models.InfoBar] as InfoBar).setAlarmStatus();
        }
    }
}
