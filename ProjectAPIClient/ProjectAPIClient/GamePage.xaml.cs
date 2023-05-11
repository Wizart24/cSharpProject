using Newtonsoft.Json;
using ProjectAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace ProjectAPIClient
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();

            GetData();
        }

        private async Task GetData()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:7031/api/Games");

            if (response.IsSuccessStatusCode)
            {
                var games = await response.Content.ReadAsAsync<List<GameModel>>();
                dtgGames.ItemsSource = games;
            }
        }

        private async void btnAdded_Click(object sender, RoutedEventArgs e)
        {
            var addGameWindow = new AddGameWindow();
            addGameWindow.ShowDialog();
            dtgGames.Items.Refresh();
        }

        private async void dtgGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = dtgGames.SelectedItem;
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selectedGame = dtgGames.SelectedItem as GameModel;
            if (selectedGame != null)
            {
                var updateGameWindow = new UpdateGameWindow(selectedGame);
                if (updateGameWindow.ShowDialog() == true)
                {
                    var updatedGame = updateGameWindow.UpdatedGame;
                    int index = ((List<GameModel>)dtgGames.ItemsSource).IndexOf(selectedGame);
                    ((List<GameModel>)dtgGames.ItemsSource)[index] = updatedGame;

                    dtgGames.Items.Refresh();
                }
            }
        }
    }
}
