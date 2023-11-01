using POS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class Purchase : INotifyPropertyChanged
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


        public Vie _vie;
        public Vie Vie 
        {
            set
            {
                _vie = value;
                OnPropertyChanged("vie");
            }
            get { return _vie; }
        }

        public Purchase()
        {
            Message = "hello saik";
            Vie = new Vie();
            Vie.Message = "Vie message";
        }

        public void ChangeVie()
        {
            Vie.Message += "message changed";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
