

using System.Globalization;

namespace ReserveParkingSpace_Mobile_
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
     

        public MainPage()
        {
            InitializeComponent();
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
    }

}
