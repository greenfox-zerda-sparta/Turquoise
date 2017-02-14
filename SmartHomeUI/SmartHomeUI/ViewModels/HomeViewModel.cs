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
        bool first_try = true;

        public HomeViewModel()
        {
            RefreshDatas();
        }

        private void RefreshDatas()
        {
            if (first_try == true)
            {
                getConsumptions();
                first_try = false;
            }
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromMinutes(0.5);
            timer.IsEnabled = true;
            timer.Tick += (s, e) => { Consumptions[0] = 4.1; };
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
