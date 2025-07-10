using ReserveParkingSpace_Mobile_.Controllers;
using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_Models;
using ReserveParkingSpace_Mobile_.Data.Models.AddingReservation_Models;
using ReserveParkingSpace_Mobile_.Services;
using ReserveParkingSpace_Mobile_.Services.IServices;
using System.Globalization;
using System.Threading.Tasks;
using ReserveParkingSpace_Mobile_.Data.Models;

namespace ReserveParkingSpace_Mobile_
{
    public partial class MainPage : ContentPage
    {
        private string _selectedSpace = "Not selected";
        private string _shift = "morning";
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;
        private MainPageController _controller;
        private byte[]? _pdfFile;
        private string? _pdfFileName;


        public MainPage()
        {
            InitializeComponent();
            _controller = new MainPageController(new DataService());
            ShiftPicker.SelectedIndex = 0;
            //ThemeChanging();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {

        }
        private async void OnInfoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
        private void ShowCalendar(object sender, EventArgs e)
        {
            CalendarLayout.IsVisible = !CalendarLayout.IsVisible;
        }

        private async void CalendarLayout_SelectionChanged(object sender, Syncfusion.Maui.Calendar.CalendarSelectionChangedEventArgs e)
        {
            DateTime? startDate = this.CalendarLayout.SelectedDateRange.StartDate;
            DateTime? endDate = this.CalendarLayout.SelectedDateRange.EndDate ?? startDate;

            if (endDate.Value.Day - startDate.Value.Day > 2)
            {
                PDF_Button.IsVisible = true;
                PDF_Label.IsVisible = true;
            }

            _startDate = startDate ?? DateTime.Now;
            _endDate = endDate ?? DateTime.Now;

            await AsyncParkingArangement(_startDate, _endDate);

        }

        private async Task AsyncParkingArangement(DateTime? startDate, DateTime? endDate)
        {
            Loading_Border.IsVisible = true;
            if (startDate == null || endDate == null)
            {
                await DisplayAlert("Error", "Please select a valid date range.", "OK");
                return;
            }
            else
            {
                if (startDate == endDate)
                {
                    SelectedDates_Label.Text = $"Selected Date: {startDate.Value.ToString("yyyy-MM-dd")}";
                }
                else
                {
                    SelectedDates_Label.Text = $"Selected Range: {startDate.Value.ToString("yyyy-MM-dd")} - {endDate.Value.ToString("yyyy-MM-dd")}";
                }

                if(endDate.Value.Day - startDate.Value.Day > 2)
                {
                    PDF_Button.IsVisible = true;
                    PDF_Label.IsVisible = true;
                }

                List<ImageButton> cars = new List<ImageButton>
            {
                car1, car2, car3, car4, car5, car6, car7, car8, car9, car10,
                car11, car12, car13, car14, car15, car16, car17, car18, car19, car20
            };

                bool[] carsHidden = new bool[cars.Count];
                var dateRange = Enumerable.Range(0, (endDate.Value - startDate.Value).Days + 1)
                    .Select(i => startDate.Value.AddDays(i))
                    .ToList();

                var tasks = dateRange.Select(date =>
                    _controller.GetParkingDashboardAsync(date.ToString("yyyy-MM-dd"))//to do: controlera ima err handling nesiobrazen s tuka
                ).ToArray();

                try
                {
                    //Vsicki API call-ove na edno - uj e po birzo
                    var results = await Task.WhenAll(tasks);

                    string shift = await ShiftPickerString(ShiftPicker.SelectedItem?.ToString());
                    _shift = shift;

                    for (int dateIndex = 0; dateIndex < results.Length; dateIndex++)
                    {
                        var reservedSpaces = results[dateIndex];
                        var currentDate = dateRange[dateIndex];

                        if (reservedSpaces?.Spaces?.Count == 20)
                        {
                            ProcessParkingSpaces(reservedSpaces, cars, carsHidden, ShiftPicker.SelectedItem?.ToString(), startDate.Value, currentDate);
                        }
                        else
                        {
                            await DisplayAlert("Error", $"Failed to load parking spaces for {currentDate:yyyy-MM-dd}.", "OK");

                            return;
                        }
                    }
                    Occupied_Label.Text = $"Occupied: {carsHidden.Where(ch => ch == false).Count()}";
                    Avaible_Label.Text = $"Available: {carsHidden.Where(ch => ch == true).Count()}";
                    Loading_Border.IsVisible = false;

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Failed to load parking data: {ex.Message}", "OK");
                    return;
                }
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

                    case "full day":
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

        private async void ReserveButton_Clicked(object sender, EventArgs e)
        {
            
            try
            {
                await Navigation.PushAsync(new LoadingPage());
                ParkingReservationRequest request = new ParkingReservationRequest()
                {
                    SpaceId = _selectedSpace,
                    StartDate = _startDate,
                    EndDate = _endDate,
                    ShiftType = _shift,
                };
                

                if(_endDate.Day - _startDate.Day > 2 
                    && _pdfFile == null 
                    && _pdfFileName == null)
                {
                    await DisplayAlert("Error", "You cannot reserve a parking space for more than two days without pdf file.", "OK");
                    return;
                }
                else
                {
                    request.ScheduleDocument = _pdfFile;
                    request.ScheduleDocumentFileName = _pdfFileName;
                    PDF_Label.IsVisible = false;
                    PDF_Button.IsVisible = true;
                    PDF_Button.BackgroundColor = Color.FromArgb("#98b189");
                }

                string token = await SecureStorage.GetAsync("token");
                if (string.IsNullOrEmpty(token))
                {
                    await DisplayAlert("Error", "You must be logged in to reserve a parking space.", "OK");
                    return;
                }
                ApiResponse response = await _controller.CreateParkingReservationAsync(request, await SecureStorage.GetAsync("token"));//todo
                if (response.IsSuccess)
                {
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                    await DisplayAlert("Success", "Parking space reserved successfully!", "OK");
                    await AsyncParkingArangement(_startDate, _endDate);
                }
                else
                {
                    await Navigation.PopAsync(); // Go back to the login page
                    await DisplayAlert("Error", $"Failed to reserve parking space", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to reserve parking space: {ex.Message}", "OK");
            }

        }

        private async void Car_Clicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button
                && _shift != null)
            {
                string clickedButtonName = button.ClassId ?? button.Source.ToString();
                _selectedSpace = clickedButtonName;
                SelectedShiftAndPosition_Label.Text = $"Selected Car: {_selectedSpace}, Shift: {_shift}";
            }
            else
            {
                await DisplayAlert("Error", "Invalid car selection.", "OK");
            }
        }

        private async void ShiftPicker_HandlerChanged(object sender, EventArgs e)
        {
            _shift = await ShiftPickerString(ShiftPicker.SelectedItem?.ToString());
            SelectedShiftAndPosition_Label.Text = $"Selected space: {_selectedSpace}, Shift: {_shift}";
        }

        private async Task<string> ShiftPickerString(string shift)
        {
            if (shift == "morning")
            {
                return "8:00-14:00";
            }
            else if (shift == "afternoon")
            {
                return "14:00-21:00";
            }
            else if (shift == "full day")
            {
                return "9:30-18:30";
            }
            else
            {
                await DisplayAlert("Error", "Invalid shift selected.", "OK");
                return "Unknown Shift";
            }
        }

       
        //TODO: minor, ne e tolkova vajno za sega
         private void ThemeChanging()
         {
            Preferences.Set("Color", "#222831");
            string color = Preferences.Get("Color", null);
            if (color == "#222831")
            {
                this.BackgroundColor = Color.FromHex(color);
            }
            else if (color == "#FFFCFB")
            {
                this.BackgroundColor = Color.FromHex(color);
            }
            else
            {
                //to do: bukvite i tekstovete da se promenat
            }
         }

        private async void PDFButton_Clicked(object sender, EventArgs e)
        {
            var file = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick a PDF file",
                FileTypes = FilePickerFileType.Pdf
            });

            if (file == null)
                return;

            using var stream = await file.OpenReadAsync();
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            _pdfFile = ms.ToArray();
            _pdfFileName = file.FileName;
            PDF_Label.IsVisible = false;
            PDF_Button.IsVisible = true;
            PDF_Button.Text = "Uploaded";

        }

    }
}
