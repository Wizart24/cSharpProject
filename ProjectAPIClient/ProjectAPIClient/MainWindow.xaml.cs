using ProjectAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace ProjectAPIClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerModel customer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnGame_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new GamePage();
        }

        private async void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = this.Parent;
        }

        private async void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CustomerPage();
        }

        private async void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new BuyPage(customer);
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new OrdersPage();
        }
    }
}
