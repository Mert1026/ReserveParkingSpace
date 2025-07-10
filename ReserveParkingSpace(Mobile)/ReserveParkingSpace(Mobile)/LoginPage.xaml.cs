using ReserveParkingSpace_Mobile_.Controllers;
using ReserveParkingSpace_Mobile_.Services;
using System.Windows.Input;

namespace ReserveParkingSpace_Mobile_;

public partial class LoginPage : ContentPage
{
    private MainPageController _controller { get; set; }
    public LoginPage()
	{
		InitializeComponent();
        _controller = new MainPageController(new DataService());


    }


    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        //bool check = await _controller.LoginAsync(email, password);
        // Navigate to loading page first
        await Navigation.PushAsync(new LoadingPage());

        // Perform the async operation
        bool check = await _controller.LoginAsync(email, password);

        // Navigate back or to the appropriate page
        if (check)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        else
        {
            await Navigation.PopAsync(); // Go back to the login page
            await DisplayAlert("Login Failed", "Invalid credentials.", "OK");
            // Show error message
        }
    }
    //if (check)
    //{
    //    //await SecureStorage.SetAsync("token", )
    //    Application.Current.MainPage = new NavigationPage(new MainPage());

    //}
    //else
    //{
    //    await DisplayAlert("Login Failed", "Invalid credentials.", "OK");
    //}

    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        try
        {
            string url = "https://reserve-parking-space.vercel.app/login";
            await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Could not open browser", "OK");
        }
    }



}
