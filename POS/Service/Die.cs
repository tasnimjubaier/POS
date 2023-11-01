using POS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class Die : INotifyPropertyChanged
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

        public ObservableCollection<DummyClass> _data;
        public ObservableCollection<DummyClass> Data
        {
            set
            {
                _data = value;
                OnPropertyChanged("dataa");
            }
            get { return _data; }
        }
        public static int Count = 1;
        public Die()
        {
            Message = "hello saik";
            Vie = new Vie();
            Vie.Message = "Vie message";
            Data = Vie.Data;
        }

        public void ChangeVie()
        {
            Vie.Message += "message changed";
            
            if(Count == 1)
            {
                Vie.AddToData();
            }
            else
            {
                Vie.ChangeData();
                Vie.Data.RemoveAt(0);
            }

            Count = Count + 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
