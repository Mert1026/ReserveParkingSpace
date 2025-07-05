namespace ReserveParkingSpace_Mobile_;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private void OnInfoClicked(object sender, EventArgs e)
    {
        InfoBox.IsVisible = !InfoBox.IsVisible;
    }
}