using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace OnlyMyKeyClient.Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpListener httpListener;
        private bool isListening = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void StartListening()
        {
            try
            {
                httpListener = new HttpListener();
                httpListener.Prefixes.Add("http://localhost:1209/"); // ������������� ����� 8080
                httpListener.Start();
                isListening = true;

                Task.Run(() => ListenForRequests());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}");
            }
        }

        private void StopListening()
        {
            if (httpListener != null && isListening)
            {
                httpListener.Stop();
                httpListener.Close();
                isListening = false;
            }
        }

        private async Task ListenForRequests()
        {
            while (isListening)
            {
                try
                {
                    var context = await httpListener.GetContextAsync(); // �������� �������
                    var request = context.Request;

                    // �������� ������ ������� � ������� ��������� "code"
                    if (request.HttpMethod == "GET" && request.QueryString["code"] != null)
                    {
                        string code = request.QueryString["code"]; // ��������� �������� "code"

                        // �������� ���� �� ������� URL
                        string callbackUrl = $"https://localhost:7164/auth/callback?code={code}";
                        string serverResponse = await SendCodeToServerAsync(callbackUrl);

                        // ����������� ������ �� �������
                        Invoke(new Action(() =>
                        {
                            //textBox1.Text = $"����� �� �������:\n{serverResponse}";
                        }));

                        // ����� �������
                        var response = context.Response;
                        string responseString = @"
<html>
<head>
    <title>Authorization Successful</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            color: #333;
            text-align: center;
            margin: 0;
            padding: 0;
        }
        .container {
            margin-top: 10%;
        }
        h1 {
            color: #4CAF50;
            font-size: 2.5em;
        }
        p {
            font-size: 1.2em;
            margin: 20px auto;
            max-width: 600px;
        }
        a {
            color: #4CAF50;
            text-decoration: none;
            font-weight: bold;
        }
        a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <div class='container'>
        <h1>Authorization Successful!</h1>
        <p>You can now safely return to the application.<br>Everything has been completed successfully.</p>
        <p>Thank you for using our service!</p>
    </div>
</body>
</html>";

                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                        response.ContentLength64 = buffer.Length;
                        using (Stream output = response.OutputStream)
                        {
                            output.Write(buffer, 0, buffer.Length);
                        }

                        StopListening(); // ��������� ��������� ����� ���������
                    }
                    else
                    {
                        // �����, ���� "code" �� ������
                        var response = context.Response;
                        string responseString = "<html><body>Invalid request: 'code' parameter is missing.</body></html>";
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                        response.ContentLength64 = buffer.Length;
                        using (Stream output = response.OutputStream)
                        {
                            output.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
                catch (HttpListenerException)
                {
                    // ���������� ���������� ��� ��������� �������
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show($"������: {ex.Message}");
                    }));
                }
            }
        }

        private async Task<string> SendCodeToServerAsync(string callbackUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(callbackUrl);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync(); // ���������� ����� �������
                }
                catch (Exception ex)
                {
                    return $"������ ��� �������� ����: {ex.Message}";
                }
            }
        }


        private async void btnAuth_Click(object sender, EventArgs e)
        {
            StopListening();

            try
            {
                StartListening();

                string requestUrl = "https://localhost:7164/auth/url";

                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                var jsonDoc = JsonDocument.Parse(responseBody);
                string authUrl = jsonDoc.RootElement.GetProperty("url").GetString();

                if (!string.IsNullOrEmpty(authUrl))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = authUrl,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("�� ������� �������� URL �� ������.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}");
            }
        }
    }
}
