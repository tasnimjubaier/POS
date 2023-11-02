using POS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POS.Views
{
    /// <summary>
    /// Interaction logic for Kai.xaml
    /// </summary>
    public partial class Kai : Window
    {
        public Kai()
        {
            InitializeComponent();
            this.DataContext = new KaiViewModel(this);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((KaiViewModel)this.DataContext).SelectionChangedExecute(sender);
        }
    }
}
