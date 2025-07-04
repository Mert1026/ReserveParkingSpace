

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
        private void OnInfoClicked(object sender, EventArgs e)
        {
            InfoBox.IsVisible = !InfoBox.IsVisible;
        }
    }

}
