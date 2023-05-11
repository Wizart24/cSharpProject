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
	/// Interaction logic for OrdersPage.xaml
	/// </summary>
	public partial class OrdersPage : Page
	{
		public OrdersPage()
		{
			InitializeComponent();

			GetData();
		}

		private async Task GetData()
		{
			var httpClient = new HttpClient();

			var response = await httpClient.GetAsync("https://localhost:7031/api/Orders");

			if (response.IsSuccessStatusCode)
			{
				var orders = await response.Content.ReadAsAsync<List<OrderModel>>();
				dtgOrders.ItemsSource = orders;
			}
		}
	}
}
