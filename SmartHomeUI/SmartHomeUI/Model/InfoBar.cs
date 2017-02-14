using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Threading;
using System.ComponentModel;
using System.Net;
using System.Xml.Linq;

namespace SmartHomeUI
{
    class InfoBar : INotifyPropertyChanged
    {
        private string currentTime = DateTime.Now.ToString("HH:mm"), currentDate = DateTime.Now.ToString("yyyy-MM-dd"), city = "Budapest", outdoorTemperature, conditions, humidity, lastUpdate;
        private const string CurrentUrl = "http://api.openweathermap.org/data/2.5/weather?" + "q=@LOC@&mode=xml&units=metric&APPID=943e2efdf23a6323a04150361b9aeca7";

        public InfoBar()
        {
            RefreshWeather();
            Clock();
            Date();
        }

        public string CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value; RaisePropertyChanged("CurrentTime"); }
        }

        public string CurrentDate
        {
            get { return currentDate; }
            set { currentDate = value; RaisePropertyChanged("CurrentDate"); }
        }

        public string City
        {
            get { return city; }
            set { city = value; RaisePropertyChanged("City"); }
        }

        public string OutdoorTemperature
        {
            get { return outdoorTemperature; }
            set { outdoorTemperature = value; RaisePropertyChanged("OutdoorTemperature"); }
        }

        public string Conditions
        {
            get { return conditions; }
            set { conditions = value; RaisePropertyChanged("Conditions"); }
        }

        public string Humidity
        {
            get { return humidity; }
            set { humidity = value; RaisePropertyChanged("Humidity"); }
        }

        public string LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; RaisePropertyChanged("LastUpdate"); }
        }

        private void WeatherConditions(string location)
        {
            string url = CurrentUrl.Replace("@LOC@", location);
            using (WebClient client = new WebClient())
            {
                var xml_document = XDocument.Load(url);
                OutdoorTemperature = (Math.Round((double)xml_document.Root.Element("temperature").Attribute("value"))).ToString() + "°C";
                Conditions = (xml_document.Root.Element("weather").Attribute("value")).ToString().Replace("value=", null).Replace("\"", "");       
                Conditions = (char.ToUpper(Conditions[0]) + Conditions.Substring(1)).ToString();
                Humidity = ((double)xml_document.Root.Element("humidity").Attribute("value")).ToString() + "%";
                LastUpdate = DateTime.Now.ToString("yyyy-MM-dd, HH:mm");
            }
        }

        private void Clock()
        {
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.IsEnabled = true;
            timer.Tick += (s, e) => { CurrentTime = DateTime.Now.ToString("HH:mm"); };
        }

        private void Date()
        {
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromDays(1);
            timer.IsEnabled = true;
            timer.Tick += (s, e) => { CurrentDate = DateTime.Now.ToString("yyyy-MM-dd"); };
        }

        private void RefreshWeather()
        {
            if (outdoorTemperature == null)
            {
                WeatherConditions(City);
            }
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromMinutes(30);
            timer.IsEnabled = true;
            timer.Tick += (s, e) => { WeatherConditions(City); };
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
