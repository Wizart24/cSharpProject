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

namespace ProjectAPIClient
{
    /// <summary>
    /// Interaction logic for AddGameWindow.xaml
    /// </summary>
    public partial class AddGameWindow : Window
    {
        public AddGameWindow()
        {
            InitializeComponent();
        }

		private async void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			var httpClient = new HttpClient();

			var response = await httpClient.GetAsync("https://localhost:7031/api/Games");

            if (response.IsSuccessStatusCode) 
            {
				var game = new GameModel()
				{
					Title = txtTitle.Text,
					Genre = txtGenre.Text,
					Year = int.Parse(txtYear.Text),
					Publisher = txtPublisher.Text,
					Price = decimal.Parse(txtPrice.Text),
					InStock = (bool)chStatus.IsChecked
				};

				var json = JsonConvert.SerializeObject(game);

				response = await httpClient.PostAsync(
					"https://localhost:7031/api/Games",
					new StringContent(json, Encoding.UTF8, "application/json"));
			}

			MessageBox.Show("Game Added!");
			this.Close();
		}
    }
}
