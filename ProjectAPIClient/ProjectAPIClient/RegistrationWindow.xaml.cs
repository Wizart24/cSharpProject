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
	/// Interaction logic for RegistrationWindow.xaml
	/// </summary>
	public partial class RegistrationWindow : Window
	{
		public RegistrationWindow()
		{
			InitializeComponent();
		}

		private async void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			var httpCLient = new HttpClient();

			var response = await httpCLient.GetAsync("https://localhost:7031/api/Customers");

			if (response.IsSuccessStatusCode)
			{
				var customer = new CustomerModel()
				{
					Name = txtName.Text,
					Password = txtPassword.Password,
					Email = txtEmail.Text,
					PhoneNumber = int.Parse(txtPhone.Text),
					Address = txtAddress.Text,
					Role = "user"
				};

				var json = JsonConvert.SerializeObject(customer);

				response = await httpCLient.PostAsync("https://localhost:7031/api/Customers",
					new StringContent(json, Encoding.UTF8, "application/json"));
			}

			MessageBox.Show("Account Created!");
			Close();
		}
	}
}
