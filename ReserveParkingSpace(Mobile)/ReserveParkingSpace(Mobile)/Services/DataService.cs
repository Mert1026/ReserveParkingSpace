
using ReserveParkingSpace_Mobile_.Data.Models;
using ReserveParkingSpace_Mobile_.Data.Models.AddingReservation_Models;
using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_Models;
using ReserveParkingSpace_Mobile_.Data.Models.Login_Models;
using ReserveParkingSpace_Mobile_.Data.Models.UserCredintalsChange_Models;
using ReserveParkingSpace_Mobile_.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<ApiResponse> ChangeUserCredidentialsAsync(UserProfile profile, string token)
        {
            try
            {
                var url = $"https://reserve-parking-space.vercel.app/api/user/profile";
                var request = new HttpRequestMessage(HttpMethod.Put, url);

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var jsonContent = JsonSerializer.Serialize(profile, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase//testvam
                });

                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                return new ApiResponse
                {
                    IsSuccess = response.IsSuccessStatusCode,
                    StatusCode = (int)response.StatusCode,
                    Content = responseContent
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = 0,
                    Content = $"Exception: {ex.Message}"
                };
            }
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

        public async Task<ApiResponse> CreateParkingReservationAsync(ParkingReservationRequest reservation, string bearerToken)
        {
            try
            {
                var url = $"https://reserve-parking-space.vercel.app/api/parking/reservations";
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
                request.Headers.Add("Origin", "https://reserve-parking-space.vercel.app");

                // Create boundary
                var boundary = $"----formdata-{Guid.NewGuid()}";

                // Build multipart form data manually
                var formDataContent = new List<byte>();

                // Add form fields
                AddFormField(formDataContent, boundary, "spaceId", reservation.SpaceId.ToString());
                AddFormField(formDataContent, boundary, "startDate", reservation.StartDate.ToString("yyyy-MM-dd"));
                AddFormField(formDataContent, boundary, "endDate", reservation.EndDate.ToString("yyyy-MM-dd"));
                AddFormField(formDataContent, boundary, "shiftType", reservation.ShiftType);

                // Add file if present
                if (reservation.ScheduleDocument != null && reservation.ScheduleDocument.Length > 0)
                {
                    AddFileField(formDataContent, boundary, "scheduleDocument",
                        reservation.ScheduleDocumentFileName ?? "schedule.pdf",
                        "application/pdf",
                        reservation.ScheduleDocument);
                }

                // Add final boundary
                var finalBoundary = $"--{boundary}--\r\n";
                formDataContent.AddRange(System.Text.Encoding.UTF8.GetBytes(finalBoundary));

                // Create content
                var content = new ByteArrayContent(formDataContent.ToArray());
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data")
                {
                    Parameters = { new System.Net.Http.Headers.NameValueHeaderValue("boundary", boundary) }
                };

                request.Content = content;

                Console.WriteLine($"Content-Type: {request.Content.Headers.ContentType}");
                Console.WriteLine($"Content-Length: {formDataContent.Count}");

                var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Response Status: {response.StatusCode}");
                Console.WriteLine($"Response Content: {responseContent}");

                return new ApiResponse
                {
                    IsSuccess = response.IsSuccessStatusCode,
                    StatusCode = (int)response.StatusCode,
                    Content = responseContent
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception: {ex.Message}");
                return new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = 0,
                    Content = $"Exception: {ex.Message}"
                };
            }

        }

        private void AddFormField(List<byte> formDataContent, string boundary, string name, string value)
        {
            var fieldHeader = $"--{boundary}\r\nContent-Disposition: form-data; name=\"{name}\"\r\n\r\n";
            formDataContent.AddRange(System.Text.Encoding.UTF8.GetBytes(fieldHeader));
            formDataContent.AddRange(System.Text.Encoding.UTF8.GetBytes(value));
            formDataContent.AddRange(System.Text.Encoding.UTF8.GetBytes("\r\n"));
        }

        private void AddFileField(List<byte> formDataContent, string boundary, string name, string filename, string contentType, byte[] fileData)
        {
            var fileHeader = $"--{boundary}\r\nContent-Disposition: form-data; name=\"{name}\"; filename=\"{filename}\"\r\nContent-Type: {contentType}\r\n\r\n";
            formDataContent.AddRange(System.Text.Encoding.UTF8.GetBytes(fileHeader));
            formDataContent.AddRange(fileData);
            formDataContent.AddRange(System.Text.Encoding.UTF8.GetBytes("\r\n"));
        }



        
    }
}
