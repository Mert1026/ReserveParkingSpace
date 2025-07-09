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
    private async void OnThemeTapped(object sender, EventArgs e)
    {
       
        await Navigation.PushAsync(new ThemePage());
    }
    private async void OnLanguageTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LanguagePage());
    }
    private async void OnSpacesTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SpacesPage());
    }


}