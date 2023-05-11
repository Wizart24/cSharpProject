using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using static ProjectAPIClient.BuyPage;

namespace ProjectAPIClient
{
	/// <summary>
	/// Interaction logic for BuyPage.xaml
	/// </summary>
	public partial class BuyPage : Page
	{
		private CustomerModel _customer;

		public BuyPage(CustomerModel customer)
		{
			InitializeComponent();

			GetData();

			_customer = customer;
		}

		private async Task GetData()
		{
			var httpClient = new HttpClient();

			var response = await httpClient.GetAsync("https://localhost:7031/api/Games");

			if (response.IsSuccessStatusCode)
			{
				var games = await response.Content.ReadAsAsync<List<GameModel>>();
				dtgData.ItemsSource = games;
			}
		}

		private async void txtSearch_KeyUp(object sender, KeyEventArgs e)
		{
			var httpClient = new HttpClient();

			var response = await httpClient.GetAsync("https://localhost:7031/api/Games");

			if (response.IsSuccessStatusCode)
			{
				var games = await response.Content.ReadAsAsync<List<GameModel>>();
				var filtered = games
					.Where(game => game.Title.StartsWith(txtSearch.Text) ||
					game.Genre.StartsWith(txtSearch.Text));

				dtgData.ItemsSource = filtered;
			}
		}

		private async void btnBuy_Click(object sender, RoutedEventArgs e)
		{
			var game = dtgData.SelectedItem as GameModel;

			var httpClient = new HttpClient();

			var response = await httpClient.GetAsync("https://localhost:7031/api/Games");

			var confirmationWindow = new ConfirmOrderWindow(game);
			confirmationWindow.ShowDialog();

			dtgData.Items.Refresh();
		}
	}
}