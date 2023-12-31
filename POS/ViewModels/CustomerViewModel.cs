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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class CustomerViewModel : IViewModel, INotifyPropertyChanged
    {
        public UserControl _view;
        public UserControl View
        {
            set
            {
                _view = value;
                OnPropertyChanged("view");
            }
            get { return _view; }
        }

        private CustomerModel _customerInstance;
        public CustomerModel CustomerInstance
        {
            set
            {
                _customerInstance = value;
                OnPropertyChanged("customerInstance");
            }
            get { return _customerInstance; }
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged("selectedCustomer");
            }
            get { return _selectedCustomer; }
        }

        private string _newEmployeeName;
        public string NewEmployeeName
        {
            set
            {
                _newEmployeeName = value;
                OnPropertyChanged("newEmployeeName");
            }
            get { return _newEmployeeName; }
        }

        private int _newEmployeeId;
        public int NewEmployeeId
        {
            set
            {
                _newEmployeeId = value;
                OnPropertyChanged("newEmployeeId");
            }
            get { return _newEmployeeId; }
        }

        #region UIs

        private Visibility _rootVisibility;
        public Visibility RootVisibility
        {
            set
            {
                _rootVisibility = value;
                OnPropertyChanged("rootVisibility");
            }
            get { return _rootVisibility; }
        }

        private Visibility _customerVisibility;
        public Visibility CustomerVisibility 
        {
            set
            {
                _customerVisibility = value;
                OnPropertyChanged("customerVisibility");
            }
            get { return _customerVisibility; }
        }

        private bool _popupVisibility;
        public bool PopupVisibility
        {
            set
            {
                _popupVisibility = value;
                OnPropertyChanged("popupVisibility");
            }
            get { return _popupVisibility; }
        }
        #endregion

        ServiceManager service;
        public ICommand AddCustomer { get; }
        public ICommand ClosePopup { get; }
        public ICommand GoBack { get; }
        public ICommand SaveCustomer { get; }

        public event EventHandler ShowLoading;
        public event EventHandler HideLoading;


        public CustomerViewModel()
        {
            View = new CustomerView();
            View.DataContext = this;

            AddCustomer = new RelayCommand(AddCustomerExecute);
            ClosePopup = new RelayCommand(ClosePopupExecute);
            GoBack = new RelayCommand(GoBackExecute);
            SaveCustomer = new RelayCommand(SaveCustomerExecute);
        }

        public async Task Initialize()
        {
            CustomerInstance = CustomerModel.GetInstance();
            service = ServiceManager.GetInstance();
            await CustomerInstance.GetDataFromDB();
            CustomerInstance.Customers = await service.GetCustomers();
        }

        public void AddCustomerExecute(object o)
        {
            PopupVisibility = true;
        }

        public void ClosePopupExecute(object o)
        {
            PopupVisibility = false;
        }

        public void GoBackExecute(object o)
        {
            RootVisibility = Visibility.Visible;
            CustomerVisibility = Visibility.Collapsed;
        }

        public void SeeDetailsCommandExecute(object sender)
        {
            Customer e = (Customer)((Button)sender).DataContext;
            SelectedCustomer = e;
            RootVisibility = Visibility.Collapsed;
            CustomerVisibility = Visibility.Visible;
        }

        public async void SaveCustomerExecute(object o)
        {
            ShowLoading?.Invoke(this, EventArgs.Empty);

            PopupVisibility = false;
            //EmployeeInstance.AddEmployee(NewEmployeeName, NewEmployeeId);
            //await service.WriteEmployees(EmployeeInstance.Employees);

            HideLoading?.Invoke(this, EventArgs.Empty);
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
