using OnlyMyKeyClient.Domain.Entities;
using OnlyMyKeyClient.Infrastructure.API;
using OnlyMyKeyClient.Infrastructure.Security;
using OnlyMyKeyClient.Infrastructure.Storage;
using System.Diagnostics;
using System.Windows.Forms;

namespace OnlyMyKeyClient.Presentation.Forms
{
    public partial class MainForm : Form
    {
        private readonly ApiService _apiService;

        public MainForm(UserData user)
        {
            InitializeComponent();
            _apiService = new ApiService();

            UpdateUserData(user);
            UpdateDataGrid();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            await LoadUserDataAsync();
        }

        private async void UpdateDataGrid()
        {
            try
            {
                var data = await _apiService.GetPasswordsAsync();

                if (data != null)
                {
                    foreach (var item in data)
                    {

                        if (!string.IsNullOrEmpty(item.EncryptedPassword))
                        {
                            try
                            {
                                item.EncryptedPassword = EncryptionHelper.Decrypt(item.EncryptedPassword);
                            }
                            catch (FormatException ex)
                            {
                                item.EncryptedPassword = "Invalid Format";
                            }
                        }
                    }

                    dataGridView1.DataSource = new BindingSource { DataSource = data };
                }
                else
                {
                    MessageBox.Show("Failed to fetch data or no data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUserDataAsync()
        {
            try
            {
                var authToken = TokenStorage.TryLoadToken("token");

                if (string.IsNullOrEmpty(authToken))
                {
                    MessageBox.Show("Token not found. Please log in first.");
                    return;
                }

                var userData = await _apiService.GetUserDataAsync(authToken);

                if (userData == null)
                {
                    MessageBox.Show("Failed to retrieve user data. Invalid token or server error.");
                }
                else
                {
                    UpdateUserData(userData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void UpdateUserData(UserData userData)
        {
            var encryption = TokenStorage.TryLoadToken("key");

            if (encryption == null)
            {
                TokenStorage.SaveToken(EncryptionHelper.GenerateKey(), "key");
                TokenStorage.SaveToken(EncryptionHelper.GenerateKey(), "iv");
            }

            pictureBox1.LoadAsync(userData.AvatarUrl);

            label1.Text = userData.Username;
        }

        private async void btnAddPass_Click(object sender, EventArgs e)
        {
            await _apiService.CreatePasswordAsync(textBox1.Text,
                EncryptionHelper.Encrypt(textBox2.Text), textBox3.Text);

            UpdateDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TokenStorage.DeleteToken("token");

            this.Hide();

            var loginForm = new LoginForm();
            loginForm.Show();

            loginForm.FormClosed += (s, e) => this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnDeletePass.Visible = dataGridView1.CurrentRow != null;
        }

        private async void btnDeletePass_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int rowIndex = dataGridView1.CurrentRow.Index;

                await _apiService.DeletePasswordByIndexAsync(rowIndex);

                UpdateDataGrid();

                btnDeletePass.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OnlyMyKey");

                if (Directory.Exists(folderPath))
                {
                    Process.Start("explorer.exe", folderPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
