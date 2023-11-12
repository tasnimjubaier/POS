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
    public class BillModel : INotifyPropertyChanged
    {
        private static BillModel? _instance;


        private ObservableCollection<Bill> _bills;
        public ObservableCollection<Bill> Bills
        {
            set
            {
                _bills = value;
                OnPropertyChanged("bills");
            }
            get { return _bills; }
        }

        public BillModel()
        {
            Bills = new ObservableCollection<Bill>();
            GetDataFromDB();
        }

        public static BillModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BillModel();
            }
            return _instance;
        }


        #region Methods

        public async Task GetDataFromDB()
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

    public class Bill : INotifyPropertyChanged
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
        private string? _customerName;
        public string? CustomerName
        {
            set
            {
                _customerName = value;
                OnPropertyChanged("customerName");
            }
            get { return _customerName; }
        }

        [JsonIgnore]
        private int _customerId;
        public int CustomerId
        {
            set
            {
                _customerId = value;
                OnPropertyChanged("customerId");
            }
            get { return _customerId; }
        }

        [JsonIgnore]
        private int _amount;
        public int Amount
        {
            set
            {
                _amount = value;
                OnPropertyChanged("amount");
            }
            get { return _amount; }
        }

        [JsonIgnore]
        private int _amountCollected;
        public int AmountCollected
        {
            set
            {
                _amountCollected = value;
                OnPropertyChanged("amountCollected");
            }
            get { return _amountCollected; }
        }

        [JsonIgnore]
        private ObservableCollection<ReceivedPayment> _payments;
        public ObservableCollection<ReceivedPayment> Payments
        {
            set
            {
                _payments = value;
                OnPropertyChanged("payments");
            }
            get { return _payments; }
        }

        [JsonIgnore]
        private Status _status;
        public Status Status
        {
            set
            {
                _status = value;
                OnPropertyChanged("status");
            }
            get { return _status; }
        }

        #endregion

        public Bill()
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

    public class ReceivedPayment : INotifyPropertyChanged
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
        private int _amount;
        public int Amount
        {
            set
            {
                _amount = value;
                OnPropertyChanged("amount");
            }
            get { return _amount; }
        }

        #endregion

        public ReceivedPayment()
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

    public enum Status
    {
        Paid,
        Unpaid,
        Due
    }
}
