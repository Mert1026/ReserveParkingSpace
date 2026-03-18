using ReserveParkingSpace_Mobile_.Data.Models;
using ReserveParkingSpace_Mobile_.Data.Models.AddingReservation_Models;
using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_Models;
using ReserveParkingSpace_Mobile_.Data.Models.Login_Models;
using ReserveParkingSpace_Mobile_.Data.Models.UserCredintalsChange_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Services.IServices
{
    interface IDataService
    {
        public Task<ParkingDashboardResponse> GetParkingDashboardAsync(string date);
        public Task<LoginResponse> LoginAsync(string email, string password);
        public Task<ApiResponse> ChangeUserCredidentialsAsync(UserProfile profile, string token);
        public Task<ApiResponse> CreateParkingReservationAsync(ParkingReservationRequest reservation, string bearerToken);
    }
}