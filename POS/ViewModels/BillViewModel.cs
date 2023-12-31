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
    public class BillViewModel : IViewModel, INotifyPropertyChanged
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

        private BillModel _billInstance;
        public BillModel BillInstance
        {
            set
            {
                _billInstance = value;
                OnPropertyChanged("billInstance");
            }
            get { return _billInstance; }
        }

        private Bill _selectedBill;
        public Bill SelectedBill
        {
            set
            {
                _selectedBill = value;
                OnPropertyChanged("selectedBill");
            }
            get { return _selectedBill; }
        }

        ServiceManager service;
        public ICommand AddEmployee { get; }

        public event EventHandler ShowLoading;
        public event EventHandler HideLoading;

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

        private Visibility _paymentsVisibility;
        public Visibility PaymentsVisibility
        {
            set
            {
                _paymentsVisibility = value;
                OnPropertyChanged("paymentsVisibility");
            }
            get { return _paymentsVisibility; }
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

        public BillViewModel()
        {
            View = new BillView();
            View.DataContext = this;

            RootVisibility = Visibility.Visible;
            PaymentsVisibility = Visibility.Collapsed;
        }

        public async Task Initialize()
        {
            BillInstance = BillModel.GetInstance();
            service = ServiceManager.GetInstance();
            await BillInstance.GetDataFromDB();
            BillInstance.Bills = await service.GetBills();
        }

        public async void LoadPaymentsView(object sender)
        {
            RootVisibility = Visibility.Collapsed;
            PaymentsVisibility = Visibility.Visible;

            SelectedBill = (Bill)((Button)sender).DataContext;
        }

        public async void PrintCommandExecute(object sender)
        {
            SelectedBill = (Bill)((Button)sender).DataContext;

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
