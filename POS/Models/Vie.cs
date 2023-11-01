using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Vie : INotifyPropertyChanged
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

        public Vie()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
