﻿using System;
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
    /// Interaction logic for gear.xaml
    /// </summary>
    public partial class GearView : UserControl
    {
        public GearView()
        {
            InitializeComponent();
            this.DataContext = new
            {
                IB = Instances.Models[(int)Models.InfoBar],
                GEARVM = Instances.ViewModels[(int)ViewModels.GearVM],
            };
        }
    }
}
