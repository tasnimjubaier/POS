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
    public class ProductViewModel : IViewModel, INotifyPropertyChanged
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

        private ProductModel _productInstance;
        public ProductModel ProductInstance
        {
            set
            {
                _productInstance = value;
                OnPropertyChanged("productInstance");
            }
            get { return _productInstance; }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("selectedProduct");
            }
            get { return _selectedProduct; }
        }

        ServiceManager service;
        public ICommand AddEmployee { get; }

        public event EventHandler ShowLoading;
        public event EventHandler HideLoading;


        public ProductViewModel()
        {
            View = new ProductView();
            View.DataContext = this;
        }

        public async Task Initialize()
        {
            ProductInstance = ProductModel.GetInstance();
            service = ServiceManager.GetInstance();
            await ProductInstance.GetDataFromDB();
            ProductInstance.Products = await service.GetProducts();
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
