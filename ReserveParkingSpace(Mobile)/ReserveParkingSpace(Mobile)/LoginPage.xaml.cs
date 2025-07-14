using ReserveParkingSpace_Mobile_.Controllers;
using ReserveParkingSpace_Mobile_.Data.Customazations;
using ReserveParkingSpace_Mobile_.Services;
using System.Windows.Input;

namespace ReserveParkingSpace_Mobile_;

public partial class LoginPage : ContentPage
{
    private MainPageController _controller { get; set; }
    private Translation _translation;
    public LoginPage()
	{
		InitializeComponent();
        _controller = new MainPageController(new DataService());
        LanguageApply();
    }


    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        await Navigation.PushAsync(new LoadingPage());
        if(CheckBox_Main.IsChecked)
        {
            Preferences.Set("RememberMe", "True");
        }
        else
        {
            Preferences.Set("RememberMe", "False");
        }
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

    private void LanguageApply()
    {
        string lang = Preferences.Get("Language", null);
        _translation = new Translation(lang);
        if (!string.IsNullOrEmpty(lang))
        {
            //MainText_Label.Text = _translation.LoginPageTitle;//opa
            //Email_Label.Text = _translation.LoginPageEmail;
            Login_Label.Text = _translation.LoginPageTitle;
            Password_Label.Text = _translation.LoginPagePassword;
            LoginBtn.Text = _translation.LoginPageTitle;
            DontHaveAcc_Span.Text = _translation.LoginPageNoAccount;
            Register_Span.Text = _translation.LoginPageRegister;
            this.Title = _translation.LoginPageTitle;
        }
    }

    
}
