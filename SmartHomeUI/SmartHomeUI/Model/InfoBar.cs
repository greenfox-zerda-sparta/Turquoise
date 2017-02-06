using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeUI
{
    class InfoBar
    {
        private string Temperature = "22°C";

        public string temperature
        {
            get
            {
                return Temperature;
            }
            set
            {
                if (Temperature != value)
                {
                    Temperature = value;
                }
            }
        }
    }
}
