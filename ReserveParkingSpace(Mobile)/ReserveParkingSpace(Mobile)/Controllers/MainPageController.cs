
using ReserveParkingSpace_Mobile_.Controllers.IControllers;
using ReserveParkingSpace_Mobile_.Data.Models;
using ReserveParkingSpace_Mobile_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Controllers
{
    public class MainPageController : IMainPageController
    {
        public DataService DataService { get; set; }
        public MainPageController(DataService _dataService)
        {
            DataService = _dataService;
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {
            try
            {
                List<Reservation> UserReservations = await DataService.GetReservationsAsync();
                if (UserReservations == null || UserReservations.Count == 0)
                {
                    await System.Console.Out.WriteLineAsync("No reservations found.");
                    return new List<Reservation>();
                }
                await System.Console.Out.WriteLineAsync($"Found {UserReservations.Count} reservations.");
                return UserReservations;
            }
            catch (Exception ex)
            {
                await System.Console.Out.WriteLineAsync($"Error: {ex.Message}");
                return new List<Reservation>();

            }
        }

        public async Task<LoginResponse>? LoginAsync(string email, string password)
        {
            try
            {
                var loginResult = await DataService.LoginAsync("john.doe@example.com", "Secure123!");

                if (loginResult != null && loginResult.success)
                {
                    return loginResult;
                }
                else
                {
                    await Console.Out.WriteLineAsync("Login failed!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error during login: {ex.Message}");
                return null;
            }

        }
    }
}
