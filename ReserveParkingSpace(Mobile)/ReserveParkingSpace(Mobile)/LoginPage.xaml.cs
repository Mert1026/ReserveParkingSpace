using ReserveParkingSpace_Mobile_.Controllers;
using ReserveParkingSpace_Mobile_.Services;

namespace ReserveParkingSpace_Mobile_;

public partial class LoginPage : ContentPage
{
    private MainPageController _controller { get; set; }
    public LoginPage()
	{
		InitializeComponent();
        _controller = new MainPageController(new DataService());
    }
    private void OnInfoClicked(object sender, EventArgs e)
    {
        InfoBox.IsVisible = !InfoBox.IsVisible;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        bool check = await _controller.LoginAsync(email, password);
        if(check)
        {
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid credentials.", "OK");
        }

    }
}