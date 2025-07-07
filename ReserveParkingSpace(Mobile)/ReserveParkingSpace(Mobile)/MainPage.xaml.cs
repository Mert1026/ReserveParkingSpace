

using ReserveParkingSpace_Mobile_.Controllers;
using ReserveParkingSpace_Mobile_.Services;
using Syncfusion.Maui.Calendar;
using System.Globalization;

namespace ReserveParkingSpace_Mobile_
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private MainPageController _controller;
        private DataService _dataService;


        public MainPage()
        {
            _controller = new MainPageController(new DataService());
            _dataService = new DataService();
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
           
        }
        private void OnInfoClicked(object sender, EventArgs e)
        {
            InfoBox.IsVisible = !InfoBox.IsVisible;
        }
        private void ShowCalendar(object sender, EventArgs e)
        {
            CalendarLayout.IsVisible = !CalendarLayout.IsVisible;
        }

        ////private void OnGetRangeClicked(object sender, EventArgs e)
        ////{
        ////    var selectedDates = CalendarLayout.SelectedDates;

        ////    if (selectedDates != null && selectedDates.Count > 0)
        ////    {
        ////        DateTime startDate = selectedDates[0];
        ////        DateTime endDate = selectedDates[selectedDates.Count - 1];

        ////        Console.WriteLine($"Start Date: {startDate:yyyy-MM-dd}");
        ////        Console.WriteLine($"End Date: {endDate:yyyy-MM-dd}");

        ////        var a = _controller.GetParkingDashboardAsync(startDate);

        ////        ProcessDateRange(startDate, endDate);
        ////    }
        ////    else
        ////    {
        ////        Console.WriteLine("No dates selected");
        ////    }
        ////}


        ////private void ProcessDateRange(DateTime start, DateTime end)
        ////{
        ////    // Your logic here
        ////    TimeSpan duration = end - start;
        ////    int dayCount = duration.Days + 1;

        ////    Console.WriteLine($"Selected range spans {dayCount} days");
        //}

        private async void CalendarLayout_SelectionChanged(object sender, Syncfusion.Maui.Calendar.CalendarSelectionChangedEventArgs e)
        {
            var a = await _dataService.GetParkingDashboardAsync(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var a = await _dataService.GetParkingDashboardAsync(DateTime.Now.ToString("yyyy-MM-dd"));
        } 
    }

}
