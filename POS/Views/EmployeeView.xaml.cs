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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.Views
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();
        }

        private void AttendenceButtonClick(object sender, RoutedEventArgs e)
        {
            ((EmployeeViewModel)this.DataContext).AttendenceCommandExecute(sender);
        }

        private void PaymentsButtonClick(object sender, RoutedEventArgs e)
        {
            ((EmployeeViewModel)this.DataContext).PaymentsCommandExecute(sender);
        }
    }
}
