using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class ProductModel : INotifyPropertyChanged
    {
        private static ProductModel? _instance;


        public ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            set
            {
                _products = value;
                OnPropertyChanged("products");
            }
            get { return _products; }
        }

        public ProductModel()
        {
            Products = new ObservableCollection<Product>();
            GetDataFromDB();
        }

        public static ProductModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductModel();
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

    public class Product : INotifyPropertyChanged
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

        public Unit _unit;
        public Unit Unit
        {
            set
            {
                _unit = value;
                OnPropertyChanged("unit");
            }
            get { return _unit; }
        }

        public int _unitPrice;
        public int UnitPrice
        {
            set
            {
                _unitPrice = value;
                OnPropertyChanged("unitPrice");
            }
            get { return _unitPrice; }
        }

        public int _inStock;
        public int InStock
        {
            set
            {
                _inStock = value;
                OnPropertyChanged("inStock");
            }
            get { return _inStock; }
        }

        public string? _category;
        public string? Category
        {
            set
            {
                _category = value;
                OnPropertyChanged("category");
            }
            get { return _category; }
        }

        #endregion

        public Product()
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

    public enum Unit
    {
        Dozen,
        Piece
    }
}
