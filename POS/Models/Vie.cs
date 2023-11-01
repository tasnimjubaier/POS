using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public DummyClass _selectedItem;
        public DummyClass SelectedItem
        {
            set
            {
                _selectedItem = value;
                OnPropertyChanged("selectedItem");
            }
            get { return _selectedItem; }
        }

        public ObservableCollection<DummyClass> _data;
        public ObservableCollection<DummyClass> Data
        {
            set
            {
                _data = value;
                OnPropertyChanged("data");
            }
            get { return _data; }
        }

        public Vie()
        {
            Data = new ObservableCollection<DummyClass>
            {
                new DummyClass("1", "Rachin"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young"),
                new DummyClass("2", "Conway"),
                new DummyClass("3", "Daryl"),
                new DummyClass("4", "Young")
            };
        }

        public void AddToData()
        {
            Data.Add(new DummyClass("5", "Williamson"));
        }

        public void ChangeData()
        {
            foreach (var data in Data)
            {
                data.Name = "A Player";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DummyClass : INotifyPropertyChanged
    {
        private string _id;
        public string Id
        {
            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
            get { return _id; }
        }
        private string _name;
        public string Name
        {
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
            get { return _name; }
        }
        public DummyClass(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
