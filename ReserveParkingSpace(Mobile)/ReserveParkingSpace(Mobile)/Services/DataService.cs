
using ReserveParkingSpace_Mobile_.Data.Models;
using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_Models;
using ReserveParkingSpace_Mobile_.Data.Models.Login_Models;
using ReserveParkingSpace_Mobile_.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public DataService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer lp7APiOuP8ciT9e2TAhCePiJVi2");
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<ParkingDashboardResponse> GetParkingDashboardAsync(string date)
        {

            string url = $"https://reserve-parking-space.vercel.app/api/parking/dashboard?date={date}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonString = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            ParkingDashboardResponse result = JsonSerializer.Deserialize<ParkingDashboardResponse>(jsonString, options);
            return result;
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            try
            {

                 string url = "https://reserve-parking-space.vercel.app/api/auth/login";
                var loginRequest = new LoginRequest
                {
                    email = email,
                    password = password
                };

                // Serialize to JSON
                var jsonContent = JsonSerializer.Serialize(loginRequest, _jsonOptions);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send POST request
                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent, _jsonOptions);
                    return loginResponse;
                }
                else
                {
                    throw new HttpRequestException($"Login failed with status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during login: {ex.Message}", ex);
            }
        }
    }
}
