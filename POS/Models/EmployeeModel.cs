using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class EmployeeModel : INotifyPropertyChanged
    {
        private static EmployeeModel? _instance;


        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            set
            {
                _employees = value;
                OnPropertyChanged("employees");
            }
            get { return _employees; }
        }

        public EmployeeModel()
        {
            Employees = new ObservableCollection<Employee>();
            GetDataFromDB();
        }

        public static EmployeeModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EmployeeModel();
            }
            return _instance;
        }


        #region Methods

        public async Task GetDataFromDB()
        {
            //await Task.Delay(999);
        }

        public void AddEmployee(string name, int id)
        {
            Employees.Add(new Employee { Name = name, Id = id });
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class Employee : INotifyPropertyChanged
    {

        #region Properties

        [JsonIgnore]
        private int _id;
        public int Id
        {
            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
            get { return _id; }
        }

        [JsonIgnore]
        private string? _name;
        public string? Name
        {
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
            get { return _name; }
        }

        [JsonIgnore]
        private ObservableCollection<Employee> _attendances;
        public ObservableCollection<Employee> Attendances
        {
            set
            {
                _attendances = value;
                OnPropertyChanged("attendances");
            }
            get { return _attendances; }
        }

        [JsonIgnore]
        private ObservableCollection<Payment> _payments;
        public ObservableCollection<Payment> Payments
        {
            set
            {
                _payments = value;
                OnPropertyChanged("payments");
            }
            get { return _payments; }
        }

        [JsonIgnore]
        private int _payableThisMonth;
        public int PayableThisMonth
        {
            set
            {
                _payableThisMonth = value;
                OnPropertyChanged("payableThisMonth");
            }
            get { return _payableThisMonth; }
        }

        #endregion

        public Employee()
        {
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class Attendance : INotifyPropertyChanged
    {

        #region Properties

        [JsonIgnore]
        private int _year;
        public int Year
        {
            set
            {
                _year = value;
                OnPropertyChanged("year");
            }
            get { return _year; }
        }

        [JsonIgnore]
        private int _month;
        public int Month
        {
            set
            {
                _month = value;
                OnPropertyChanged("month");
            }
            get { return _month; }
        }

        [JsonIgnore]
        private int _presentDays;
        public int PresentDays
        {
            set
            {
                _presentDays = value;
                OnPropertyChanged("presentDays");
            }
            get { return _presentDays; }
        }

        [JsonIgnore]
        private int _monthlySalary;
        public int MonthlySalary
        {
            set
            {
                _monthlySalary = value;
                OnPropertyChanged("monthlySalary");
            }
            get { return _monthlySalary; }
        }

        [JsonIgnore]
        private int _payableThisMonth;
        public int PayableThisMonth
        {
            set
            {
                _payableThisMonth = value;
                OnPropertyChanged("payableThisMonth");
            }
            get { return _payableThisMonth; }
        }

        [JsonIgnore]
        private int _paidAmount;
        public int PaidAmount
        {
            set
            {
                _paidAmount = value;
                OnPropertyChanged("paidAmount");
            }
            get { return _paidAmount; }
        }

        #endregion

        public Attendance()
        {
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class Payment : INotifyPropertyChanged
    {

        #region Properties

        [JsonIgnore]
        private DateTime _date;
        public DateTime Date
        {
            set
            {
                _date = value;
                OnPropertyChanged("date");
            }
            get { return _date; }
        }

        [JsonIgnore]
        private int _amountPaid;
        public int AmountPaid
        {
            set
            {
                _amountPaid = value;
                OnPropertyChanged("amountPaid");
            }
            get { return _amountPaid; }
        }

        #endregion

        public Payment()
        {
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
