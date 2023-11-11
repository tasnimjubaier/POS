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
    public class BillCollectionViewModel : IViewModel, INotifyPropertyChanged
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

        private BillModel _billInstance;
        public BillModel BillInstance
        {
            set
            {
                _billInstance = value;
                OnPropertyChanged("billInstance");
            }
            get { return _billInstance; }
        }

        ServiceManager service;
        public ICommand AddEmployee { get; }

        public event EventHandler ShowLoading;
        public event EventHandler HideLoading;


        public BillCollectionViewModel()
        {
            View = new BillCollectionView();
            View.DataContext = this;
        }

        public async Task Initialize()
        {
            BillInstance = BillModel.GetInstance();
            service = ServiceManager.GetInstance();
            await BillInstance.GetDataFromDB();
            BillInstance.Bills = await service.GetBills();
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
