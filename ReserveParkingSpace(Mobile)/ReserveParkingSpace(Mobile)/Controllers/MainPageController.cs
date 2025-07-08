
using ReserveParkingSpace_Mobile_.Controllers.IControllers;
using ReserveParkingSpace_Mobile_.Data.Models;
using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_Models;
using ReserveParkingSpace_Mobile_.Data.Models.Login_Models;
using ReserveParkingSpace_Mobile_.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Controllers
{
    public class MainPageController : IMainPageController
    {

        public DataService DataService;
        public MainPageController(DataService _dataService)
        {
            DataService = new DataService();
        }

        public async Task<ParkingDashboardResponse> GetParkingDashboardAsync(string date)
        {
            return await DataService.GetParkingDashboardAsync(date); //TO DO: exception handlign problem(napravi try-catch!)
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            try
            {
                var dataService = new DataService();
                var loginResponse = await dataService.LoginAsync(email, password);
                if (loginResponse != null && loginResponse.success)
                {
                    // Navigate to the main page or dashboard
                    //await Navigation.PushAsync(new MainPage());
                    return true;
                }
                else
                {
                    //await DisplayAlert("Login Failed", "Invalid credentials.", "OK"); - nz shto ne raboti
                    return false;
                }
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK"); - oshte nz
                return false;
            }
        }
    }
}
