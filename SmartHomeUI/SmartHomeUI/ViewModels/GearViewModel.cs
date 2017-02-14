using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;



namespace SmartHomeUI
{
    class GearViewModel : INotifyPropertyChanged {
    private string town;
    public string Town {
      get { return town; }
      set {
        // Implement with property changed handling for INotifyPropertyChanged
        if(!string.Equals(town, value)) {
          town = value;
          RaisePropertyChanged("Town"); // Method to raise the PropertyChanged event in your BaseViewModel class...
        }
      }
    }

    //public List<City> Cities { get; set; }
    public ObservableCollection<InfoBar> cities { get; set; }
    public ObservableCollection<InfoBar> Cities { get; private set; }

    public GearViewModel() {
      LoadCities();
    }
    public void LoadCities () {
      ObservableCollection<InfoBar> cities = new ObservableCollection<InfoBar>();
      cities.Add(new InfoBar { City = "Budapest" });
      Cities = cities;
    }


    public event PropertyChangedEventHandler PropertyChanged;

    private void RaisePropertyChanged(string property) {
      if(PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(property));
      }
    }

  }
}

