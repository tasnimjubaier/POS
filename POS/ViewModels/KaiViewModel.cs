using POS.Commands;
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
    public class KaiViewModel : INotifyPropertyChanged
    {

        public string _message;
        public string Message
        {
            set
            {
                _message = value;
                OnPropertyChanged("message");
            }
            get { return _message; }
        }

        public Die _purchase;
        public Die Purchase
        {
            set
            {
                _purchase = value;
                OnPropertyChanged("purchase");
            }
            get { return _purchase; }
        }

        public ICommand MyCommand { get; }

        public Kai View;
        public KaiViewModel(Kai view)
        {
            View = view;
            Purchase = new Die();
            Message = "hello heaven";
            MyCommand = new RelayCommand(ChangeExecute);
        }


        private void ChangeExecute(object param)
        {
            Message += "changed message";
            Purchase.Message += "added message";
            Purchase.ChangeVie();
        }

        public void SelectionChangedExecute(object sender)
        {
            DummyClass dc = (DummyClass)((DataGrid)sender).CurrentItem;
            //Purchase.Vie.SelectedItem = dc;
        }

        public void SelectionExecute(object sender)
        {
            DummyClass dc = (DummyClass)((Button)sender).DataContext;
            Purchase.Vie.SelectedItem = dc;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
