using Microsoft.Extensions.Logging;
using ReserveParkingSpace_Mobile_.Data.Models;
using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_models;
using ReserveParkingSpace_Mobile_.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ReserveParkingSpace_Mobile_.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;

        public DataService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer lp7APiOuP8ciT9e2TAhCePiJVi2");
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
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
    }
}
