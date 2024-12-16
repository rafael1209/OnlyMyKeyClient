using OnlyMyKeyClient.Infrastructure.API;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using OnlyMyKeyClient.Infrastructure.Network;
using OnlyMyKeyClient.Infrastructure.Storage;

namespace OnlyMyKeyClient.Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private readonly ApiService _apiService;
        private readonly NetworkService _networkService;
        public delegate void AccountHandler();

        public LoginForm()
        {
            InitializeComponent();

            _apiService = new ApiService();
            _networkService = new NetworkService(_apiService, CheckUserCredentials);
            CheckUserCredentials();
        }

        private async void CheckUserCredentials()
        {
            var token = TokenStorage.TryLoadToken("token");

            if (token == null) return;

            var userData = await _apiService.GetUserDataAsync(token);

            if (userData == null) return;

            this.Invoke(() =>
            {
                this.Hide();

                var mainForm = new MainForm(userData);
                mainForm.Show();

                mainForm.FormClosed += (s, e) => this.Close();
            });
        }

        private async void btnAuth_Click(object sender, EventArgs e)
        {
            _networkService.StartListening();

            try
            {
                var response = await _apiService.GetUrlDataAsync();

                if (response != null) 
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = response.Url,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
