namespace ReserveParkingSpace_Mobile_;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}
    private async void OnAccountTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccountPage());
    }
}