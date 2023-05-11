using Newtonsoft.Json;
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
using System.Windows.Shapes;
using static ProjectAPIClient.BuyPage;

namespace ProjectAPIClient
{
	/// <summary>
	/// Interaction logic for ConfirmOrderWindow.xaml
	/// </summary>
	public partial class ConfirmOrderWindow : Window
	{
		public GameModel Game { get; private set; }

		public ConfirmOrderWindow(GameModel game)
		{
			InitializeComponent();
			//_resultCallback = resultCallback;

			Game = game; 
		}

		private async void btnConfirm_Click(object sender, RoutedEventArgs e)
		{
			var httpClient = new HttpClient();

			var response = await httpClient.GetAsync("https://localhost:7031/api/Customers");

			if (response.IsSuccessStatusCode)
			{
				var user = await response.Content.ReadAsAsync<List<CustomerModel>>();

				bool isConfirmed = user.Any(u => u.Email == txtUsername.Text && u.Password == txtPassword.Password);


				if (isConfirmed)
				{
					var Customer = user.FirstOrDefault(u => u.Email == txtUsername.Text && u.Password == txtPassword.Password);
					if (Game.InStock)
					{
						var order = new OrderModel()
						{
							GameName = Game.Title,
							CustomerEmail = Customer.Email,
							DeliveryAddress = Customer.Address,
							OrderDate = DateTime.UtcNow
						};

						var orderResponse = await httpClient.PostAsJsonAsync("https://localhost:7031/api/Orders", order);

						if (orderResponse.IsSuccessStatusCode)
						{
							Game.InStock = false;
							var gameUpdateResponse = await httpClient.PatchAsync("https://localhost:7031/api/Games/" + Game.Id,
								new StringContent(JsonConvert.SerializeObject(Game), Encoding.UTF8, "application/json"));

							MessageBox.Show("You bought a game!");
							Close();
						}
					}
					else
					{
						MessageBox.Show("We don't have this game at the moment...");
					}
				}
				else
				{
					MessageBox.Show("Invalid Email or Password");
				}
			}
		}
    }
}
