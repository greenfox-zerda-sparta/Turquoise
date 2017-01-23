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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DragWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void home_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            home_indicator.Background = Brushes.Green;
            list_indicator.Background = Brushes.Transparent;
            hist_indicator.Background = Brushes.Transparent;
            temp_indicator.Background = Brushes.Transparent;
            lock_indicator.Background = Brushes.Transparent;
            gear_indicator.Background = Brushes.Transparent;

            frame.Navigate(new home());
        }

        private void list_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            home_indicator.Background = Brushes.Transparent;
            list_indicator.Background = Brushes.Green;
            hist_indicator.Background = Brushes.Transparent;
            temp_indicator.Background = Brushes.Transparent;
            lock_indicator.Background = Brushes.Transparent;
            gear_indicator.Background = Brushes.Transparent;

            frame.Navigate(new list());
        }

        private void hist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            home_indicator.Background = Brushes.Transparent;
            list_indicator.Background = Brushes.Transparent;
            hist_indicator.Background = Brushes.Green;
            temp_indicator.Background = Brushes.Transparent;
            lock_indicator.Background = Brushes.Transparent;
            gear_indicator.Background = Brushes.Transparent;

            frame.Navigate(new hist());
        }

        private void temp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            home_indicator.Background = Brushes.Transparent;
            list_indicator.Background = Brushes.Transparent;
            hist_indicator.Background = Brushes.Transparent;
            temp_indicator.Background = Brushes.Green;
            lock_indicator.Background = Brushes.Transparent;
            gear_indicator.Background = Brushes.Transparent;

            frame.Navigate(new temp());
        }

        private void lock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            home_indicator.Background = Brushes.Transparent;
            list_indicator.Background = Brushes.Transparent;
            hist_indicator.Background = Brushes.Transparent;
            temp_indicator.Background = Brushes.Transparent;
            lock_indicator.Background = Brushes.Green;
            gear_indicator.Background = Brushes.Transparent;

            frame.Navigate(new @lock());
        }

        private void gear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            home_indicator.Background = Brushes.Transparent;
            list_indicator.Background = Brushes.Transparent;
            hist_indicator.Background = Brushes.Transparent;
            temp_indicator.Background = Brushes.Transparent;
            lock_indicator.Background = Brushes.Transparent;
            gear_indicator.Background = Brushes.Green;

            frame.Navigate(new gear());
        }
    }
}
