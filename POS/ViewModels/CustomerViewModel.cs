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

        ServiceManager service;
        public ICommand AddEmployee { get; }

        public event EventHandler ShowLoading;
        public event EventHandler HideLoading;


        public CustomerViewModel()
        {
            View = new CustomerView();
            View.DataContext = this;
        }

        public async Task Initialize()
        {
            CustomerInstance = CustomerModel.GetInstance();
            service = ServiceManager.GetInstance();
            await CustomerInstance.GetDataFromDB();
            CustomerInstance.Customers = await service.GetCustomers();
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
