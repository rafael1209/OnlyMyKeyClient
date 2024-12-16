using OnlyMyKeyClient.Infrastructure.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OnlyMyKeyClient.Infrastructure.Storage;
using static OnlyMyKeyClient.Presentation.Forms.LoginForm;
using System.Security.Principal;

namespace OnlyMyKeyClient.Infrastructure.Network
{
    public class NetworkService(ApiService apiService, AccountHandler account)
    {
        private readonly HttpListener _httpListener = new();
        private readonly ApiService _apiService = apiService;
        private readonly AccountHandler _account = account;

        private const string BaseUrl = "http://localhost:1209/";

        private bool _isListening = false;

        public void StartListening()
        {
            try
            {
                StopListening();

                _isListening = true;
                _httpListener.Prefixes.Add(BaseUrl);
                _httpListener.Start();

                Task.Run(async () => await ListenForRequests());
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        private void StopListening()
        {
            _isListening = false;

            if (!_httpListener.IsListening)
                return;

            _httpListener.Stop();
            _httpListener.Close();
        }

        private async Task ListenForRequests()
        {
            while (_isListening)
            {
                try
                {
                    var context = await _httpListener.GetContextAsync();
                    var request = context.Request;

                    if (request.HttpMethod != "GET" || request.QueryString["code"] == null)
                    {
                        SendResponse(context.Response, "Invalid request. Missing 'code' parameter.");
                        continue;
                    }

                    var code = request.QueryString["code"];

                    var serverResponse = await _apiService.SendCodeToServerAsync(code);

                    if (serverResponse != null && !string.IsNullOrEmpty(serverResponse.AuthToken))
                    {
                        TokenStorage.SaveToken(serverResponse.AuthToken, "token");

                        _account.Invoke();

                        SendResponse(context.Response, "Authorization successful. You can return to the application.");
                    }
                    else
                    {
                        SendResponse(context.Response, "Failed to process the authorization code.");
                    }

                    StopListening();
                }
                catch (HttpListenerException)
                {
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void SendResponse(HttpListenerResponse response, string responseMessage)
        {
            try
            {
                var buffer = System.Text.Encoding.UTF8.GetBytes(
                    $"<html><body><h2>{responseMessage}</h2></body></html>"
                );

                response.ContentLength64 = buffer.Length;
                response.ContentType = "text/html";
                response.StatusCode = (int)HttpStatusCode.OK;

                using var output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send response: {ex.Message}");
            }
        }
    }
}
