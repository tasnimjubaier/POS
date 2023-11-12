using POS.Interfaces;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
            this.DataContext = new ShellViewModel(this);
        }

        public void SwitchButton(string button)
        {
            ResetButtons();
            switch (button)
            {
                case "Purchase":
                    B1.Background = new SolidColorBrush(Color.FromRgb(0x2C, 0x4C, 0x61));
                    break;
                case "Employee":
                    B2.Background = new SolidColorBrush(Color.FromRgb(0x2C, 0x4C, 0x61));
                    break;
                case "Bills":
                    B3.Background = new SolidColorBrush(Color.FromRgb(0x2C, 0x4C, 0x61));
                    break;
                case "Customers":
                    B4.Background = new SolidColorBrush(Color.FromRgb(0x2C, 0x4C, 0x61));
                    break;
                case "Products":
                    B5.Background = new SolidColorBrush(Color.FromRgb(0x2C, 0x4C, 0x61));
                    break;
                case "Stock":
                    B6.Background = new SolidColorBrush(Color.FromRgb(0x2C, 0x4C, 0x61));
                    break;
                case "BillCollection":
                    B7.Background = new SolidColorBrush(Color.FromRgb(0x2C, 0x4C, 0x61));
                    break;
            }
        }

        public void ResetButtons()
        {
            B1.Background = new SolidColorBrush(Color.FromRgb(0x4D, 0x89, 0xB0));
            B2.Background = new SolidColorBrush(Color.FromRgb(0x4D, 0x89, 0xB0));
            B3.Background = new SolidColorBrush(Color.FromRgb(0x4D, 0x89, 0xB0));
            B4.Background = new SolidColorBrush(Color.FromRgb(0x4D, 0x89, 0xB0));
            B5.Background = new SolidColorBrush(Color.FromRgb(0x4D, 0x89, 0xB0));
            B6.Background = new SolidColorBrush(Color.FromRgb(0x4D, 0x89, 0xB0));
            B7.Background = new SolidColorBrush(Color.FromRgb(0x4D, 0x89, 0xB0));
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((ShellViewModel)this.DataContext).DashboardCommandExecute();
        }
    }
}
