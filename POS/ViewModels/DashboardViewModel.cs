using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ICommand MyCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DashboardViewModel()
        {
            Message = "hello heaven";
            MyCommand = new CustomCommand(ChangeExecute);
        }
        private void ChangeExecute()
        {
            Message += "changed message";
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
