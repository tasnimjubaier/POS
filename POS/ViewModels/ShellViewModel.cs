﻿using POS.Commands;
using POS.Interfaces;
using POS.Models;
using POS.Service;
using POS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class ShellViewModel : IViewModel, INotifyPropertyChanged
    {
        public IViewModel _contentViewModel;
        public IViewModel ContentViewModel
        {
            set
            {
                _contentViewModel = value;
                OnPropertyChanged("contentViewModel");
            }
            get { return _contentViewModel; }
        }

        public Shell View;
        public ICommand SwitchCommand { get; }


        public ShellViewModel(Shell view)
        {
            View = view;
            ContentViewModel = new DashboardViewModel();
            SwitchCommand = new RelayCommand(SwitchCommandExecute);
        }

        private async void SwitchCommandExecute(object param)
        {
            string to = (string)param;
            switch (to)
            {
                case "Purchase":
                    ContentViewModel = new PurchaseViewModel();
                    break;
                case "Employee":
                    ContentViewModel = new EmployeeViewModel();
                    break;
                case "Bills":
                    ContentViewModel = new EmployeeViewModel();
                    break;
                case "Customers":
                    ContentViewModel = new EmployeeViewModel();
                    break;
                case "Products":
                    ContentViewModel = new EmployeeViewModel();
                    break;
                case "Stock":
                    ContentViewModel = new EmployeeViewModel();
                    break;
                case "BillCollection":
                    ContentViewModel = new EmployeeViewModel();
                    break;
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}