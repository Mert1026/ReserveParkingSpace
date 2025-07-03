using ReserveParkingSpace_Mobile_.Data.Models;
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

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer lp7APiOuP8ciT9e2TAhCePiJVi2");
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Reservation>> GetReservationsAsync()
        {
            {
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Get,
                        "https://reserve-parking-space-back-end.vercel.app/api/parking/reservations");

                    request.Headers.Add("Authorization", "Bearer lp7APiOuP8ciT9e2TAhCePiJVi2");
                    request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await _httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    var jsonString = await response.Content.ReadAsStringAsync();
                    var reservations = JsonSerializer.Deserialize<List<Reservation>>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return reservations;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            try
            {
                var loginRequest = new LoginRequest
                {
                    email = email,
                    password = password
                };

                var json = JsonSerializer.Serialize(loginRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(
                    "https://reserve-parking-space-back-end.vercel.app/api/auth/login",
                    content);

                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return loginResponse;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
