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
    public class EmployeeViewModel : IViewModel, INotifyPropertyChanged
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

        private EmployeeModel _employeeInstance;
        public EmployeeModel EmployeeInstance
        {
            set
            {
                _employeeInstance = value;
                OnPropertyChanged("employeeInstance");
            }
            get { return _employeeInstance; }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("selectedEmployee");
            }
            get { return _selectedEmployee; }
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

        private Visibility _attendenceVisibility;
        public Visibility AttendenceVisibility
        {
            set
            {
                _attendenceVisibility = value;
                OnPropertyChanged("attendenceVisibility");
            }
            get { return _attendenceVisibility; }
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

        ServiceManager service;
        public ICommand AddEmployee { get; }
        public ICommand ClosePopup { get; }
        public ICommand GoBack { get; }
        public ICommand SaveEmployee { get; }

        public event EventHandler ShowLoading;
        public event EventHandler HideLoading;

        public EmployeeViewModel()
        {
            View = new EmployeeView();
            View.DataContext = this;

            AddEmployee = new RelayCommand(AddEmployeeExecute);
            ClosePopup = new RelayCommand(ClosePopupExecute);
            GoBack = new RelayCommand(GoBackExecute);
            SaveEmployee = new RelayCommand(SaveEmployeeExecute);

            RootVisibility = Visibility.Visible;
            AttendenceVisibility = Visibility.Collapsed;
            PaymentsVisibility = Visibility.Collapsed;
            PopupVisibility = false;
        }

        public async Task Initialize()
        {
            EmployeeInstance = EmployeeModel.GetInstance();
            service = ServiceManager.GetInstance();
            await EmployeeInstance.GetDataFromDB();
            EmployeeInstance.Employees = await service.GetEmployees();
        }

        public void AddEmployeeExecute(object o)
        {
            PopupVisibility = true;
            NewEmployeeId = EmployeeInstance.Employees.Count + 1;
        }

        public void ClosePopupExecute(object o)
        {
            PopupVisibility = false;
        }

        public void AttendenceCommandExecute(object sender)
        {
            Employee e = (Employee)((Button)sender).DataContext;
            SelectedEmployee = e;
            RootVisibility = Visibility.Collapsed;
            AttendenceVisibility = Visibility.Visible;
        }

        public void PaymentsCommandExecute(object sender)
        {
            Employee e = (Employee)((Button)sender).DataContext;
            SelectedEmployee = e;
            RootVisibility = Visibility.Collapsed;
            PaymentsVisibility = Visibility.Visible;
        }

        public void GoBackExecute(object o)
        {
            RootVisibility = Visibility.Visible;
            AttendenceVisibility = Visibility.Collapsed;
            PaymentsVisibility = Visibility.Collapsed;
        }

        public async void SaveEmployeeExecute(object o)
        {
            ShowLoading?.Invoke(this, EventArgs.Empty);

            PopupVisibility = false;
            EmployeeInstance.AddEmployee(NewEmployeeName, NewEmployeeId);
            await service.WriteEmployees(EmployeeInstance.Employees);

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
