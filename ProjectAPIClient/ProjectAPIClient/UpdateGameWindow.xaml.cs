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
    /// Interaction logic for UpdateGameWindow.xaml
    /// </summary>
    public partial class UpdateGameWindow : Window
    {
		public GameModel UpdatedGame { get; set; }

		public UpdateGameWindow(GameModel game)
        {
            InitializeComponent();

			// Bind the properties of the selected game to the input controls
			txtTitle.Text = game.Title;
			txtGenre.Text = game.Genre;
			txtYear.Text = game.Year.ToString();
			txtPublisher.Text = game.Publisher;
			txtPrice.Text = game.Price.ToString();
			chStatus.IsChecked = false;

			UpdatedGame = game;
		}

		private async void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			UpdatedGame.Title = txtTitle.Text;
			UpdatedGame.Genre = txtGenre.Text;
			UpdatedGame.Year = int.Parse(txtYear.Text);
			UpdatedGame.Publisher = txtPublisher.Text;
			UpdatedGame.Price = decimal.Parse(txtPrice.Text);
			UpdatedGame.InStock = (bool)chStatus.IsChecked;

			var httpClient = new HttpClient();

			var json = JsonConvert.SerializeObject(UpdatedGame);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await httpClient.PatchAsync("https://localhost:7031/api/Games/" + UpdatedGame.Id, content);

			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Game Updated!");
				DialogResult = true;
				this.Close();
			}
		}
	}
}
