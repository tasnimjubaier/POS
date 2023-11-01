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


        public ObservableCollection<Purchase> _purchases;
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


        #region

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

    public class Purchase : INotifyPropertyChanged
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

        public DateTime _date;
        public DateTime Date
        {
            set
            {
                _date = value;
                OnPropertyChanged("date");
            }
            get { return _date; }
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

        public int _amount;
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
