

using ReserveParkingSpace_Mobile_.Controllers;
using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_Models;
using ReserveParkingSpace_Mobile_.Services;
using ReserveParkingSpace_Mobile_.Services.IServices;
using System.Globalization;                                                                                                                                                                                                                                                                                                                                                        

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
            DateTime? endDate = this.CalendarLayout.SelectedDateRange.EndDate != null
                            ? this.CalendarLayout.SelectedDateRange.EndDate
                            : null;
            if(endDate == null)
            {
                endDate = startDate;
            }
            List<ImageButton> cars = new List<ImageButton>
                 {
                    car1, car2, car3, car4, car5, car6, car7, car8, car9, car10,
                    car11, car12, car13, car14, car15, car16, car17, car18, car19, car20
                 };

            bool[] carsHidden = new bool[cars.Count];
            for (DateTime d = startDate.Value; d <= endDate.Value; d = d.AddDays(1))
            {
                ParkingDashboardResponse reservedSpaces = await _controller.GetParkingDashboardAsync(d.ToString("yyyy-MM-dd"));
                string shift = "morning";//ShiftPicker.SelectedItem.ToString();
                

                if (reservedSpaces != null || reservedSpaces.Spaces.Count == 20)
                {

                    

                    for (int i = 0; i < cars.Count; i++)
                    {
                        //Morning shift
                        if (shift == "morning")
                        {
                            if (reservedSpaces.Spaces[i].IsAvailable.Morning == true
                                && startDate.Value == d)
                            {
                                cars[i].Source = ""; //todo brt
                                carsHidden[i] = true;
                            }
                            else if (carsHidden[i] == false)
                            {
                                cars[i].Source = $"car{i+1}.png";
                            }
                        }
                        else if (shift == "afternoon")
                        {
                            if (reservedSpaces.Spaces[i].IsAvailable.Afternoon == true)
                            {
                                cars[i].IsOpaque = false; //todo brt
                            }
                            else
                            {
                                cars[i].IsOpaque = true;
                            }
                        }
                        else if (shift == "fullday")
                        {
                            if (reservedSpaces.Spaces[i].IsAvailable.FullDay == true)
                            {
                                cars[i].IsOpaque = false; //todo brt
                            }
                            else
                            {
                                cars[i].IsOpaque = true;
                            }
                        }

                    }

                }


            }
        }
    }

}
