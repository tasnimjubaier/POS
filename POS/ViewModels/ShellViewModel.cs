using POS.Commands;
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
            View.SwitchButton(to);

            switch (to)
            {
                case "Purchase":
                    View.LoadingView.Visibility = Visibility.Visible;

                    ContentViewModel = new PurchaseViewModel();
                    await ((PurchaseViewModel)ContentViewModel).Initialize();
                    ((PurchaseViewModel)ContentViewModel).ShowLoading += ShowLoadingEventHandler;
                    ((PurchaseViewModel)ContentViewModel).HideLoading += HideLoadingEventHandler;

                    View.LoadingView.Visibility = Visibility.Collapsed;
                    break;
                case "Employee":
                    View.LoadingView.Visibility = Visibility.Visible;

                    ContentViewModel = new EmployeeViewModel();
                    await ((EmployeeViewModel)ContentViewModel).Initialize();
                    ((EmployeeViewModel)ContentViewModel).ShowLoading += ShowLoadingEventHandler;
                    ((EmployeeViewModel)ContentViewModel).HideLoading += HideLoadingEventHandler;

                    View.LoadingView.Visibility = Visibility.Collapsed;
                    break;
                case "Bills":
                    View.LoadingView.Visibility = Visibility.Visible;

                    ContentViewModel = new BillViewModel();
                    await ((BillViewModel)ContentViewModel).Initialize();
                    ((BillViewModel)ContentViewModel).ShowLoading += ShowLoadingEventHandler;
                    ((BillViewModel)ContentViewModel).HideLoading += HideLoadingEventHandler;

                    View.LoadingView.Visibility = Visibility.Collapsed;
                    break;
                case "Customers":
                    View.LoadingView.Visibility = Visibility.Visible;

                    ContentViewModel = new CustomerViewModel();
                    await ((CustomerViewModel)ContentViewModel).Initialize();
                    ((CustomerViewModel)ContentViewModel).ShowLoading += ShowLoadingEventHandler;
                    ((CustomerViewModel)ContentViewModel).HideLoading += HideLoadingEventHandler;

                    View.LoadingView.Visibility = Visibility.Collapsed;
                    break;
                case "Products":
                    View.LoadingView.Visibility = Visibility.Visible;

                    ContentViewModel = new ProductViewModel();
                    await ((ProductViewModel)ContentViewModel).Initialize();
                    ((ProductViewModel)ContentViewModel).ShowLoading += ShowLoadingEventHandler;
                    ((ProductViewModel)ContentViewModel).HideLoading += HideLoadingEventHandler;

                    View.LoadingView.Visibility = Visibility.Collapsed;
                    break;
                case "Stock":
                    ContentViewModel = new EmployeeViewModel();
                    break;
                case "BillCollection":
                    View.LoadingView.Visibility = Visibility.Visible;

                    ContentViewModel = new BillCollectionViewModel();
                    await ((BillCollectionViewModel)ContentViewModel).Initialize();
                    ((BillCollectionViewModel)ContentViewModel).ShowLoading += ShowLoadingEventHandler;
                    ((BillCollectionViewModel)ContentViewModel).HideLoading += HideLoadingEventHandler;

                    View.LoadingView.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        public void DashboardCommandExecute()
        {
            View.ResetButtons();
            ContentViewModel = new DashboardViewModel();
        }
        public void HideLoadingEventHandler(object? sender, EventArgs e)
        {
            View.LoadingView.Visibility = Visibility.Collapsed;
        }

        public void ShowLoadingEventHandler(object? sender, EventArgs e)
        {
            View.LoadingView.Visibility = Visibility.Visible;
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
