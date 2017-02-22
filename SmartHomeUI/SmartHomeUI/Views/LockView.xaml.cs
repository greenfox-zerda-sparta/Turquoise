using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartHomeUI
{
    /// <summary>
    /// Interaction logic for @lock.xaml
    /// </summary>
    public partial class LockView : UserControl
    {
        public LockView()
        {
            InitializeComponent();
        }
        private void door_MediaEnded(object sender, RoutedEventArgs e) {
            door.Position = new TimeSpan(0, 0, 3);
            door.Play();
        }
    }
}
