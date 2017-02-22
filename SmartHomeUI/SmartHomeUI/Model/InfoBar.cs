using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Threading;
using System.ComponentModel;
using System.Net;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace SmartHomeUI
{
    class InfoBar : INotifyPropertyChanged
    {
        private string currentTime = DateTime.Now.ToString("HH:mm"),
                       currentDate = DateTime.Now.ToString("yyyy-MM-dd"),
                       city = "Józsefváros", sunset, sunrise, humidity,
                       outdoorTemperature, lastUpdate, condition, icon;

        public ObservableCollection<string> AlarmStatus { get; set; }
        Dictionary<string, string> WeatherDaylightConditionIcons;
        Dictionary<string, string> WeatherNightConditionIcons;
        private const string CurrentUrl = "http://api.openweathermap.org/data/2.5/weather?" + "q=@LOC@&mode=xml&units=metric&APPID=943e2efdf23a6323a04150361b9aeca7";

        public InfoBar()
        {
            instantiateWeatherConditionDictionaries();
            Instances.refreshData(WeatherConditions, OutdoorTemperature, (int)Timers.oneMinute);
            Instances.refreshData(Clock, CurrentTime, (int)Timers.oneSecond);
            Instances.refreshData(Date, CurrentDate, (int)Timers.oneDay);
            setAlarmStatus();
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
            set { city = value; WeatherConditions(); RaisePropertyChanged("City"); }
        }

        public string OutdoorTemperature
        {
            get { return outdoorTemperature; }
            set { outdoorTemperature = value; RaisePropertyChanged("OutdoorTemperature"); }
        }

        public string Condition
        {
            get { return condition; }
            set { condition = value; RaisePropertyChanged("Condition"); }
        }

        public string ConditionIcon
        {
            get { return icon; }
            set { icon = value; RaisePropertyChanged("ConditionIcon"); }
        }

        public string Humidity
        {
            get { return humidity; }
            set { humidity = value; RaisePropertyChanged("Humidity"); }
        }

        public string Sunrise
        {
            get { return sunrise; }
            set { sunrise = value; RaisePropertyChanged("Sunrise"); }
        }

        public string Sunset
        {
            get { return sunset; }
            set { sunset = value; RaisePropertyChanged("Sunset"); }
        }

        public string LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; RaisePropertyChanged("LastUpdate"); }
        }

        private void WeatherConditions()
        {
            string url = CurrentUrl.Replace("@LOC@", City);
            using (WebClient client = new WebClient())
            {
                var xml_document = XDocument.Load(url);
                OutdoorTemperature = (Math.Round((double)xml_document.Root.Element("temperature").Attribute("value"))).ToString();
                Condition = (xml_document.Root.Element("weather").Attribute("value")).ToString().Replace("value=", null).Replace("\"", "");       
                Condition = (char.ToUpper(Condition[0]) + Condition.Substring(1)).ToString();
                ConditionIcon = ((double)xml_document.Root.Element("weather").Attribute("number")).ToString();
                Humidity = ((double)xml_document.Root.Element("humidity").Attribute("value")).ToString();
                Sunrise = (xml_document.Root.Element("city").Element("sun").Attribute("rise")).ToString().Replace("rise=", null).Replace("\"", "").Replace(":", "").Remove(0, 11);
                Sunset = (xml_document.Root.Element("city").Element("sun").Attribute("set")).ToString().Replace("set=", null).Replace("\"", "").Replace(":", "").Remove(0, 11);
                LastUpdate = DateTime.Now.ToString("yyyy-MM-dd, HH:mm");
                setConditionIcon(ConditionIcon);
                (Instances.Models[(int)Models.Log] as Logger).logToFile("MainWindow - InfoBar: Fetched weather data from openweathermap.org");
            }
        }

        private void setConditionIcon(string conditionNumber)
        {
            if (int.Parse(DateTime.Now.ToString("HHmmss")) > int.Parse(Sunrise) && int.Parse(DateTime.Now.ToString("HHmmss")) < int.Parse(Sunset))
            {
                if (WeatherDaylightConditionIcons.ContainsKey(conditionNumber))
                {
                    ConditionIcon = WeatherDaylightConditionIcons[conditionNumber];
                }
            }
            else
            {
                if (WeatherNightConditionIcons.ContainsKey(conditionNumber))
                {
                    ConditionIcon = WeatherNightConditionIcons[conditionNumber];
                }
            }
        }

        private void instantiateWeatherConditionDictionaries()
        {
            WeatherDaylightConditionIcons = new Dictionary<string, string>();
            WeatherDaylightConditionIcons.Add("800", "Images/WeatherIcons/sunny.png");

            WeatherDaylightConditionIcons.Add("801", "Images/WeatherIcons/few_clouds.png");
            WeatherDaylightConditionIcons.Add("802", "Images/WeatherIcons/scattered_clouds.png");
            WeatherDaylightConditionIcons.Add("803", "Images/WeatherIcons/broken_clouds.png");
            WeatherDaylightConditionIcons.Add("804", "Images/WeatherIcons/broken_clouds.png");

            WeatherDaylightConditionIcons.Add("200", "Images/WeatherIcons/thunderstorm.png");
            WeatherDaylightConditionIcons.Add("201", "Images/WeatherIcons/thunderstorm.png");
            WeatherDaylightConditionIcons.Add("202", "Images/WeatherIcons/thunderstorm.png");
            WeatherDaylightConditionIcons.Add("210", "Images/WeatherIcons/thunderstorm.png");
            WeatherDaylightConditionIcons.Add("211", "Images/WeatherIcons/thunderstorm.png");
            WeatherDaylightConditionIcons.Add("212", "Images/WeatherIcons/thunderstorm.png");
            WeatherDaylightConditionIcons.Add("221", "Images/WeatherIcons/thunderstorm.png");
            WeatherDaylightConditionIcons.Add("230", "Images/WeatherIcons/thunderstorm.png");
            WeatherDaylightConditionIcons.Add("231", "Images/WeatherIcons/thunderstorm.png");
            WeatherDaylightConditionIcons.Add("232", "Images/WeatherIcons/thunderstorm.png");

            WeatherDaylightConditionIcons.Add("500", "Images/WeatherIcons/shower_rain.png");
            WeatherDaylightConditionIcons.Add("501", "Images/WeatherIcons/shower_rain.png");
            WeatherDaylightConditionIcons.Add("502", "Images/WeatherIcons/shower_rain.png");
            WeatherDaylightConditionIcons.Add("503", "Images/WeatherIcons/shower_rain.png");
            WeatherDaylightConditionIcons.Add("504", "Images/WeatherIcons/shower_rain.png");

            WeatherDaylightConditionIcons.Add("300", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("301", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("302", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("310", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("311", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("312", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("313", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("314", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("321", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("511", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("520", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("521", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("522", "Images/WeatherIcons/rain.png");
            WeatherDaylightConditionIcons.Add("531", "Images/WeatherIcons/rain.png");

            WeatherDaylightConditionIcons.Add("600", "Images/WeatherIcons/snow.png");
            WeatherDaylightConditionIcons.Add("601", "Images/WeatherIcons/snow.png");
            WeatherDaylightConditionIcons.Add("602", "Images/WeatherIcons/snow.png");
            WeatherDaylightConditionIcons.Add("611", "Images/WeatherIcons/snow.png");
            WeatherDaylightConditionIcons.Add("612", "Images/WeatherIcons/snow.png");
            WeatherDaylightConditionIcons.Add("615", "Images/WeatherIcons/snow.png");
            WeatherDaylightConditionIcons.Add("616", "Images/WeatherIcons/snow.png");
            WeatherDaylightConditionIcons.Add("620", "Images/WeatherIcons/snow.png");
            WeatherDaylightConditionIcons.Add("621", "Images/WeatherIcons/snow.png");
            WeatherDaylightConditionIcons.Add("622", "Images/WeatherIcons/snow.png");

            WeatherDaylightConditionIcons.Add("701", "Images/WeatherIcons/mist.png");
            WeatherDaylightConditionIcons.Add("711", "Images/WeatherIcons/mist.png");
            WeatherDaylightConditionIcons.Add("721", "Images/WeatherIcons/mist.png");
            WeatherDaylightConditionIcons.Add("731", "Images/WeatherIcons/mist.png");
            WeatherDaylightConditionIcons.Add("741", "Images/WeatherIcons/mist.png");

            WeatherNightConditionIcons = new Dictionary<string, string>();
            WeatherNightConditionIcons.Add("800", "Images/WeatherIcons/night_clear_sky.png");

            WeatherNightConditionIcons.Add("801", "Images/WeatherIcons/night_few_clouds.png");
            WeatherNightConditionIcons.Add("802", "Images/WeatherIcons/scattered_clouds.png");
            WeatherNightConditionIcons.Add("803", "Images/WeatherIcons/broken_clouds.png");
            WeatherNightConditionIcons.Add("804", "Images/WeatherIcons/broken_clouds.png");

            WeatherNightConditionIcons.Add("200", "Images/WeatherIcons/thunderstorm.png");
            WeatherNightConditionIcons.Add("201", "Images/WeatherIcons/thunderstorm.png");
            WeatherNightConditionIcons.Add("202", "Images/WeatherIcons/thunderstorm.png");
            WeatherNightConditionIcons.Add("210", "Images/WeatherIcons/thunderstorm.png");
            WeatherNightConditionIcons.Add("211", "Images/WeatherIcons/thunderstorm.png");
            WeatherNightConditionIcons.Add("212", "Images/WeatherIcons/thunderstorm.png");
            WeatherNightConditionIcons.Add("221", "Images/WeatherIcons/thunderstorm.png");
            WeatherNightConditionIcons.Add("230", "Images/WeatherIcons/thunderstorm.png");
            WeatherNightConditionIcons.Add("231", "Images/WeatherIcons/thunderstorm.png");
            WeatherNightConditionIcons.Add("232", "Images/WeatherIcons/thunderstorm.png");

            WeatherNightConditionIcons.Add("500", "Images/WeatherIcons/night_shower_rain.png");
            WeatherNightConditionIcons.Add("501", "Images/WeatherIcons/night_shower_rain.png");
            WeatherNightConditionIcons.Add("502", "Images/WeatherIcons/night_shower_rain.png");
            WeatherNightConditionIcons.Add("503", "Images/WeatherIcons/night_shower_rain.png");
            WeatherNightConditionIcons.Add("504", "Images/WeatherIcons/night_shower_rain.png");

            WeatherNightConditionIcons.Add("300", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("301", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("302", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("310", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("311", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("312", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("313", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("314", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("321", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("511", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("520", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("521", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("522", "Images/WeatherIcons/rain.png");
            WeatherNightConditionIcons.Add("531", "Images/WeatherIcons/rain.png");

            WeatherNightConditionIcons.Add("600", "Images/WeatherIcons/snow.png");
            WeatherNightConditionIcons.Add("601", "Images/WeatherIcons/snow.png");
            WeatherNightConditionIcons.Add("602", "Images/WeatherIcons/snow.png");
            WeatherNightConditionIcons.Add("611", "Images/WeatherIcons/snow.png");
            WeatherNightConditionIcons.Add("612", "Images/WeatherIcons/snow.png");
            WeatherNightConditionIcons.Add("615", "Images/WeatherIcons/snow.png");
            WeatherNightConditionIcons.Add("616", "Images/WeatherIcons/snow.png");
            WeatherNightConditionIcons.Add("620", "Images/WeatherIcons/snow.png");
            WeatherNightConditionIcons.Add("621", "Images/WeatherIcons/snow.png");
            WeatherNightConditionIcons.Add("622", "Images/WeatherIcons/snow.png");

            WeatherNightConditionIcons.Add("701", "Images/WeatherIcons/mist.png");
            WeatherNightConditionIcons.Add("711", "Images/WeatherIcons/mist.png");
            WeatherNightConditionIcons.Add("721", "Images/WeatherIcons/mist.png");
            WeatherNightConditionIcons.Add("731", "Images/WeatherIcons/mist.png");
            WeatherNightConditionIcons.Add("741", "Images/WeatherIcons/mist.png");
        }

        private void Clock()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm");
        }

        private void Date()
        {
            CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void setAlarmStatus()
        {
            AlarmStatus = new ObservableCollection<string>() { "Disarmed", "Images/InfoBarIcons/lockout.png" };
            if(Instances.AllDevice[0].Status == 1)
            {
                AlarmStatus[0] = ("Armed");
                AlarmStatus[1] = ("Images/InfoBarIcons/lockin.png");
            }
            else if (Instances.AllDevice[0].Status == 0)
            {
                AlarmStatus[0] = ("Disarmed");
                AlarmStatus[1] = ("Images/InfoBarIcons/lockout.png");
            }
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
