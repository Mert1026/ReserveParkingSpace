using ReserveParkingSpace_Mobile_.Controllers.IControllers;
using ReserveParkingSpace_Mobile_.Data.Models;
using ReserveParkingSpace_Mobile_.Data.Models.AddingReservation_Models;
using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_Models;
using ReserveParkingSpace_Mobile_.Data.Models.Login_Models;
using ReserveParkingSpace_Mobile_.Data.Models.UserCredintalsChange_Models;
using ReserveParkingSpace_Mobile_.Services;
namespace ReserveParkingSpace_Mobile_.Controllers
{
    public class MainPageController : IMainPageController
    {

        public DataService DataService;
        public MainPageController(DataService _dataService)
        {
            DataService = new DataService();
        }

        public async Task<bool> ChangeUserCredidentialsAsync(UserProfile profile, string token)
        {
            var response = await DataService.ChangeUserCredidentialsAsync(profile, token);
            Console.WriteLine($"Update successful: {response.IsSuccess}");

            if (response.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ApiResponse> CreateParkingReservationAsync(ParkingReservationRequest reservation, string bearerToken)
        {
            if (reservation == null
                || bearerToken == "")
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Content = "Invalid reservation data or token.",
                };
            }
            return await DataService.CreateParkingReservationAsync(reservation, bearerToken); // oshte error handling moje bi
            
        }

        public async Task<ParkingDashboardResponse> GetParkingDashboardAsync(string date)
        {
            DateTime? parsedDate = DateTime.TryParse(date, out var tempDate) 
                ? tempDate : (DateTime?)null;
            if (parsedDate == null)
            {
                return new ParkingDashboardResponse
                {
                    Date = date,//opa
                    Success = false,
                    Spaces = new List<ParkingSpace>(),
                };
            }
            return await DataService.GetParkingDashboardAsync(date); //TO DO: exception handlign problem(napravi try-catch!)
        }

        public async Task<bool> LoginAsync(string email, string password, bool tokenSet = false)
        {
            DataService dataService = new DataService();
            if (tokenSet)
            {
                LoginResponse loginResponse = await dataService.LoginAsync(email, password);
                if (string.IsNullOrEmpty(loginResponse.token))
                {
                    return false;
                }
                await SecureStorage.SetAsync("token", loginResponse.token);
                return true;
            }
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            try
            {
                LoginResponse loginResponse = await dataService.LoginAsync(email, password);
                if (loginResponse != null && loginResponse.success)
                {
                    //await Navigation.PushAsync(new MainPage());
                    await SecureStorage.SetAsync("token", loginResponse.token);
                    await SecureStorage.SetAsync("password", password);
                    Preferences.Set("email", email);    
                    Preferences.Set("Username", loginResponse.user.username);
                    Preferences.Set("FirstName", loginResponse.user.firstName);
                    Preferences.Set("Surname", loginResponse.user.lastName); //TC TC TC mnogo greshno
                    Preferences.Set("Department", loginResponse.user.department.ToLower());
                    Preferences.Set("Language", "en");// en-bg
                    Preferences.Set("Color", "white");

                    return true;
                }
                else
                {
                    //await DisplayAlert("Login Failed", "Invalid credentials.", "OK"); - nz shto ne raboti. vece razbarh
                    return false;
                }
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK"); - oshte nz. naistina ne moje
                return false;
            }
        }
    }
}
