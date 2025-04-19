using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace proyectofinal_appmoviles.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://adamix.net/defensa_civil/def/";

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };
        }

        public void SetToken(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                Preferences.Set("token", token);
            }
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            try
            {
                var response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(json);
                }
                else
                {
                    Console.WriteLine($"❌ Error GET: {response.StatusCode}");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🚨 Excepción en GET: {ex.Message}");
                return default;
            }
        }
        public async Task<JsonElement?> PostFormDataAsync(string endpoint, Dictionary<string, string> formData)
        {
            try
            {
                var content = new MultipartFormDataContent();

                foreach (var kv in formData)
                {
                    content.Add(new StringContent(kv.Value), kv.Key);
                }

                var response = await _httpClient.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<JsonElement>(jsonResponse);
                }
                else
                {
                    Console.WriteLine($"❌ Error POST FormData: {response.StatusCode}");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🚨 Excepción en POST FormData: {ex.Message}");
                return default;
            }
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<TResponse>(jsonResponse);
                }
                else
                {
                    Console.WriteLine($"❌ Error POST: {response.StatusCode}");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🚨 Excepción en POST: {ex.Message}");
                return default;
            }
        }

        // New method to get services list
        public async Task<Models.ServicioResponseDto?> GetServiciosAsync()
        {
            return await GetAsync<Models.ServicioResponseDto>("servicios.php");
        }

        // New method to get videos list
        public async Task<List<Models.VideoDto>?> GetVideosAsync()
        {
            return await GetAsync<List<Models.VideoDto>>("videos.php");
        }

        // New method to get preventive measures list
        public async Task<Models.MedidaResponseDto?> GetMedidasAsync()
        {
            return await GetAsync<Models.MedidaResponseDto>("medidas.php");
        }

        // New method to get members list
        public async Task<Models.MiembroResponseDto?> GetMiembrosAsync()
        {
            return await GetAsync<Models.MiembroResponseDto>("miembros.php");
        }

        // New method to post volunteer data
        public async Task<TResponse?> PostVoluntarioAsync<TResponse>(object data)
        {
            return await PostAsync<object, TResponse>("voluntarios.php", data);
        }

        // New method to get albergues list
        public async Task<Models.AlbergueResponseDto?> GetAlberguesAsync()
        {
            return await GetAsync<Models.AlbergueResponseDto>("albergues.php");
        }
    }
}
