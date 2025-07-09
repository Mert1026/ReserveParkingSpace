

using ReserveParkingSpace_Mobile_.Controllers;
using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_Models;
using ReserveParkingSpace_Mobile_.Data.Models.AddingReservation_Models;
using ReserveParkingSpace_Mobile_.Services;
using ReserveParkingSpace_Mobile_.Services.IServices;
using System.Globalization;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPageController _controller;

        public MainPage()
        {
            InitializeComponent();
            _controller = new MainPageController(new DataService());
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
          
        }
        private async void OnInfoClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new SettingsPage());//TO DO: napravi datata s smotaniq kalendar!
        }
        private void ShowCalendar(object sender, EventArgs e)
        {
            CalendarLayout.IsVisible = !CalendarLayout.IsVisible;
        }

        private async void CalendarLayout_SelectionChanged(object sender, Syncfusion.Maui.Calendar.CalendarSelectionChangedEventArgs e)
        {
            DateTime? startDate = this.CalendarLayout.SelectedDateRange.StartDate;
            DateTime? endDate = this.CalendarLayout.SelectedDateRange.EndDate ?? startDate;

            List<ImageButton> cars = new List<ImageButton>
            {
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10,
                car11, car12, car13, car14, car15, car16, car17, car18, car19, car20
            };  

            bool[] carsHidden = new bool[cars.Count];

            // Create all date requests in parallel
            var dateRange = Enumerable.Range(0, (endDate.Value - startDate.Value).Days + 1)
                .Select(i => startDate.Value.AddDays(i))
                .ToList();

            var tasks = dateRange.Select(date =>
                _controller.GetParkingDashboardAsync(date.ToString("yyyy-MM-dd"))
            ).ToArray();

            try
            {
                // Wait for all API calls to complete
                var results = await Task.WhenAll(tasks);

                string shift = ShiftPicker.SelectedItem.ToString();

                // Process all results
                for (int dateIndex = 0; dateIndex < results.Length; dateIndex++)
                {
                    var reservedSpaces = results[dateIndex];
                    var currentDate = dateRange[dateIndex];

                    if (reservedSpaces?.Spaces?.Count == 20)
                    {
                        ProcessParkingSpaces(reservedSpaces, cars, carsHidden, shift, startDate.Value, currentDate);
                    }
                    else
                    {
                        await DisplayAlert("Error", $"Failed to load parking spaces for {currentDate:yyyy-MM-dd}.", "OK");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load parking data: {ex.Message}", "OK");
                return;
            }

        }

        private void ProcessParkingSpaces(ParkingDashboardResponse reservedSpaces, List<ImageButton> cars,
             bool[] carsHidden, string shift, DateTime startDate, DateTime currentDate)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                var space = reservedSpaces.Spaces[i];

                switch (shift)
                {
                    case "morning":
                        // Check if space is available for morning AND not reserved for full day
                        bool morningAvailable = space.IsAvailable.Morning && space.IsAvailable.FullDay;

                        if (morningAvailable && startDate == currentDate)
                        {
                            cars[i].Source = ""; // todo brt
                            carsHidden[i] = true;
                        }
                        else if (carsHidden[i] == false)
                        {
                            cars[i].Source = $"car{i + 1}.png";
                        }
                        break;

                    case "afternoon":
                        // Check if space is available for afternoon AND not reserved for full day
                        bool afternoonAvailable = space.IsAvailable.Afternoon && space.IsAvailable.FullDay;

                        if (afternoonAvailable && startDate == currentDate)
                        {
                            cars[i].Source = ""; // todo brt
                            carsHidden[i] = true;
                        }
                        else if (carsHidden[i] == false)
                        {
                            cars[i].Source = $"car{i + 1}.png";
                        }
                        break;

                    case "fullday":
                        if (startDate == currentDate)
                        {
                            cars[i].Source = ""; // todo brt
                            carsHidden[i] = true;
                        }
                        else if (carsHidden[i] == false)
                        {
                            cars[i].Source = $"car{i + 1}.png";
                        }
                        break;
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)     
        {
            await _controller.CreateParkingReservationAsync(new ParkingReservationRequest()
            {
                SpaceId = "1",
                StartDate =  DateTime.Now.AddDays(16),
                EndDate = DateTime.Now.AddDays(16),
                ShiftType = "14:00-21:00",
            }, await SecureStorage.GetAsync("token"));

        }
    }
}

