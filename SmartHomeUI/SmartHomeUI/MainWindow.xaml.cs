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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new
            {
                IB = Instances.Models[(int)Models.InfoBar],
                NAV = Instances.ViewModels[(int)ViewModels.NavVM],
                SC = Instances.ViewModels[(int)ViewModels.ScenVM]
            };
        }

        private void DragWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            (Instances.Models[(int)Models.XMLHandler] as XMLHandler).devicesToXML(Instances.AllDevice, "Devices.xml");
            (Instances.Models[(int)Models.XMLHandler] as XMLHandler).tasksToXML((Instances.ViewModels[(int)ViewModels.HistVM] as HistViewModel).ShoppingList, "Tasks/ShoppingList.xml");
            (Instances.Models[(int)Models.XMLHandler] as XMLHandler).tasksToXML((Instances.ViewModels[(int)ViewModels.HistVM] as HistViewModel).DailyTasks, "Tasks/DailyTasks.xml");
            (Instances.Models[(int)Models.XMLHandler] as XMLHandler).tasksToXML((Instances.ViewModels[(int)ViewModels.HistVM] as HistViewModel).JaneToDo, "Tasks/JaneTodos.xml");
            (Instances.Models[(int)Models.XMLHandler] as XMLHandler).tasksToXML((Instances.ViewModels[(int)ViewModels.HistVM] as HistViewModel).JoeToDo, "Tasks/JoeTodos.xml");
            Close();
        }

        private void MinimizeButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
