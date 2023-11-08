using POS.Commands;
using POS.Interfaces;
using POS.Models;
using POS.Service;
using POS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class PurchaseViewModel : IViewModel, INotifyPropertyChanged
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

        public PurchaseModel _purchaseInstance;
        public PurchaseModel PurchaseInstance
        {
            set
            {
                _purchaseInstance = value;
                OnPropertyChanged("purchaseInstance");
            }
            get { return _purchaseInstance; }
        }

        ServiceManager service;
        public ICommand SaveData { get; }

        public PurchaseViewModel()
        {
            View = new PurchaseView();
            View.DataContext = this;
            SaveData = new RelayCommand(SaveCommandExecute);
        }

        public async Task Initialize()
        {
            PurchaseInstance = PurchaseModel.GetInstance();
            await PurchaseInstance.GetDataFromDB();
            service = ServiceManager.GetInstance();
            PurchaseInstance.Purchases = await service.GetPurchases();
        }

        public async void SaveCommandExecute(object o)
        {
            await service.WritePurchases(PurchaseInstance.Purchases);
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
