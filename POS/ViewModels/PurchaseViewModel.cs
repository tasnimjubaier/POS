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
        private UserControl _view;
        public UserControl View
        {
            set
            {
                _view = value;
                OnPropertyChanged("view");
            }
            get { return _view; }
        }

        private PurchaseModel _purchaseInstance;
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

        public event EventHandler ShowLoading;
        public event EventHandler HideLoading;

        public PurchaseViewModel()
        {
            View = new PurchaseView();
            View.DataContext = this;
            SaveData = new RelayCommand(SaveCommandExecute);
        }

        public async Task Initialize()
        {
            PurchaseInstance = PurchaseModel.GetInstance();
            service = ServiceManager.GetInstance();
            await PurchaseInstance.GetDataFromDB();
            PurchaseInstance.Purchases = await service.GetPurchases();
        }

        public async void SaveCommandExecute(object o)
        {
            ShowLoading?.Invoke(this, EventArgs.Empty);

            await service.WritePurchases(PurchaseInstance.Purchases);

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
