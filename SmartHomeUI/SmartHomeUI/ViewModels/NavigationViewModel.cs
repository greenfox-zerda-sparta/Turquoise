﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartHomeUI
{
    class NavigationViewModel : INotifyPropertyChanged
    {
        public ICommand HomeCommand { get; set; }
        public ICommand ListCommand { get; set; }
        public ICommand HistCommand { get; set; }
        public ICommand TempCommand { get; set; }
        public ICommand LockCommand { get; set; }
        public ICommand GearCommand { get; set; }

        private object selectedViewModel;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }


        public NavigationViewModel()
        {
            HomeCommand = new BaseCommand(OpenHome);
            ListCommand = new BaseCommand(OpenList);
            HistCommand = new BaseCommand(OpenHist);
            TempCommand = new BaseCommand(OpenTemp);
            LockCommand = new BaseCommand(OpenLock);
            GearCommand = new BaseCommand(OpenGear);
        }

        private void OpenHome(object obj)
        {
            SelectedViewModel = new HomeViewModel();
        }

        private void OpenList(object obj)
        {
            SelectedViewModel = new ListViewModel();
        }

        private void OpenHist(object obj)
        {
            SelectedViewModel = new HistViewModel();
        }

        private void OpenTemp(object obj)
        {
            SelectedViewModel = new TempViewModel();
        }

        private void OpenLock(object obj)
        {
            SelectedViewModel = new LockViewModel();
        }

        private void OpenGear(object obj)
        {
            SelectedViewModel = new GearViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

    public class BaseCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _method;
        public event EventHandler CanExecuteChanged;

        public BaseCommand(Action<object> method)
            : this(method, null)
        {
        }

        public BaseCommand(Action<object> method, Predicate<object> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }
    }
}