using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeUI
{
    static class Instances
    {
        static public List<object> ViewModels;
        static public List<object> Models;

        static Instances()
        {
            ViewModels = new List<object>();
            ViewModels.Add(new HomeViewModel());
            ViewModels.Add(new ListViewModel());
            ViewModels.Add(new HistViewModel());
            ViewModels.Add(new TempViewModel());
            ViewModels.Add(new LockViewModel());
            ViewModels.Add(new GearViewModel());
            ViewModels.Add(new NavigationViewModel());

            Models = new List<object>();
            Models.Add(new InfoBar());
            Models.Add(new Communication());
        }
    }
}
