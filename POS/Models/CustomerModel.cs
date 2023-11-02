using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class CustomerModel : INotifyPropertyChanged
    {
        private static CustomerModel? _instance;


        public ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            set
            {
                _customers = value;
                OnPropertyChanged("customers");
            }
            get { return _customers; }
        }

        public CustomerModel()
        {
            Customers = new ObservableCollection<Customer>();
            GetDataFromDB();
        }

        public static CustomerModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CustomerModel();
            }
            return _instance;
        }


        #region Methods

        public void GetDataFromDB()
        {

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

    public class Customer : INotifyPropertyChanged
    {

        #region Properties

        public int _id;
        public int Id
        {
            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
            get { return _id; }
        }

        public string? _name;
        public string? Name
        {
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
            get { return _name; }
        }

        public string? _address;
        public string? Address
        {
            set
            {
                _address = value;
                OnPropertyChanged("address");
            }
            get { return _address; }
        }

        public ObservableCollection<Bill> _bills;
        public ObservableCollection<Bill> Bills
        {
            set
            {
                _bills = value;
                OnPropertyChanged("bills");
            }
            get { return _bills; }
        }

        #endregion

        public Customer()
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
