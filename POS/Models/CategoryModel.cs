using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class CategoryModel : INotifyPropertyChanged
    {
        private static CategoryModel? _instance;


        public ObservableCollection<string> _categories;
        public ObservableCollection<string> Categories
        {
            set
            {
                _categories = value;
                OnPropertyChanged("categories");
            }
            get { return _categories; }
        }

        public CategoryModel()
        {
            Categories = new ObservableCollection<string>();
            GetDataFromDB();
        }

        public static CategoryModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CategoryModel();
            }
            return _instance;
        }


        #region Methods

        public void GetDataFromDB()
        {

        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
