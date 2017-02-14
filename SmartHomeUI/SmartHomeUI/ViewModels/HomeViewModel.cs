using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHomeUI {
    class HomeViewModel
    {
        public ObservableCollection<double> Consumptions { get; set; }

        public HomeViewModel()
        {
            Instances.refreshData(getConsumptions, Consumptions, (int)Timers.halfHour);
        }

        public void getConsumptions()
        {
            ObservableCollection<double> consumptions = new ObservableCollection<double>();

            consumptions.Add(3.9);
            consumptions.Add(31.67);
            consumptions.Add(613);

            Consumptions = consumptions;
        }
    }
}
