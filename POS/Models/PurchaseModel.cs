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
    public class PurchaseModel : INotifyPropertyChanged
    {
        private static PurchaseModel? _instance;


        private ObservableCollection<Purchase> _purchases;
        public ObservableCollection<Purchase> Purchases
        {
            set
            {
                _purchases = value;
                OnPropertyChanged("purchases");
            }
            get { return _purchases; }
        }

        public PurchaseModel()
        {
            Purchases = new ObservableCollection<Purchase>();
            GetDataFromDB();
        }

        public static PurchaseModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PurchaseModel();
            }
            return _instance;
        }


        #region Methods

        public async Task GetDataFromDB()
        {

        }

        public void AddPurchase(Purchase purchase)
        {
            Purchases.Add(purchase);
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

    public class Purchase : INotifyPropertyChanged
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

        public Purchase() { }
        public Purchase(int id, DateTime dateTime, string name, int amount)
        {
            Id = id;
            Date = dateTime;
            Name = name;
            Amount = amount;
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
