using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartHomeUI
{
    class LockViewModel
    {
        public ICommand SetAlarmCommand { get; set; }
        public LockViewModel()
        {
            SetAlarmCommand = new NavigationCommands(param => SetAlarm());
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
