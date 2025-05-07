using OnlyMyKeyClient.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OnlyMyKeyClient.Domain.Responses;
using OnlyMyKeyClient.Infrastructure.Storage;

namespace OnlyMyKeyClient.Infrastructure.API
{
    public class ApiService
    {
        private readonly HttpClient _httpClient = new();
        private const string BaseApiUrl = "https://omk.chasman.engineer";

        public async Task<UserData?> GetUserDataAsync(string authToken)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( authToken);

                var response = await _httpClient.GetAsync(BaseApiUrl + "/api/user/me");

                if (!response.IsSuccessStatusCode)
                    return null;

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<UserData>(content);
            }
            catch
            {
                return null;
            }
        }

        public async Task<Authorize?> SendCodeToServerAsync(string? code)
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseApiUrl + $"/api/auth/callback?code={code}");

                if (!response.IsSuccessStatusCode)
                    return null;

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Authorize>(content);
            }
            catch
            {
                return null;
            }
        }

        public async Task<UrlData?> GetUrlDataAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseApiUrl + $"/api/auth/url");

                if (!response.IsSuccessStatusCode)
                    return null;

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<UrlData>(content);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<PasswordData>?> GetPasswordsAsync()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(TokenStorage.TryLoadToken("token"));

                var response = await _httpClient.GetAsync(BaseApiUrl + $"/api/password");

                if (!response.IsSuccessStatusCode)
                    return null;

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<PasswordData>>(content);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreatePasswordAsync(string login, string password, string note)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(TokenStorage.TryLoadToken("token"));

                var payload = new
                {
                    login,
                    password,
                    note
                };

                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(BaseApiUrl + "/api/password", content);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeletePasswordByIndexAsync(int index)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(TokenStorage.TryLoadToken("token"));

                var response = await _httpClient.DeleteAsync($"{BaseApiUrl}/api/password/{index}");

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
