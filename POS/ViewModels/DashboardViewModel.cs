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
    public class DashboardViewModel : INotifyPropertyChanged
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

        public Dashboard View;

        public DashboardViewModel(Dashboard view)
        {
            View = view;
            Purchase = new Die();
            Message = "hello heaven";
            MyCommand = new CustomCommand(ChangeExecute);
        }

        private void ChangeExecute()
        {
            Message += "changed message";
            Purchase.Message += "added message";
            Purchase.ChangeVie();
        }

        public void SelectionChangedExecute(object sender)
        {
            DummyClass dc = (DummyClass)((DataGrid)sender).CurrentItem;
            Purchase.Vie.SelectedItem = dc;
            View.RowPopup.IsOpen = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CustomCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public CustomCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke();
        }
    }

}
