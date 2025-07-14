using ReserveParkingSpace_Mobile_.Controllers;
using ReserveParkingSpace_Mobile_.Data.Customazations;
using ReserveParkingSpace_Mobile_.Services;

namespace ReserveParkingSpace_Mobile_;

public partial class IntroductionPage : ContentPage
{
    private Translation _translation;
    private MainPageController _controller { get; set; }
    private bool _check = false;
    public IntroductionPage()
	{
        _controller = new MainPageController(new DataService());
        CheckIfUserIsLogged();
        InitializeComponent();
        LanguageApply();
    }

    private async void CheckIfUserIsLogged()
    {
        
        string LoggedIn = Preferences.Get("RememberMe", null);
        if (LoggedIn != null)
        {
            if (LoggedIn == "True")
            {
                await Navigation.PushAsync(new LoadingPage());
                string? email = Preferences.Get("email", null);
                string? password = await SecureStorage.GetAsync("password");
                if (email != null && password != null)
                {
                    
                     bool check = await _controller.LoginAsync(email, password, true);//setvane na token
                    
                    _check = check;
                    if (_check)
                    {
                        Application.Current.MainPage = new NavigationPage(new MainPage());
                    }
                    else
                    {
                        Application.Current.MainPage = new NavigationPage(new LoginPage());
                    }

                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                }
            }
        }
    }


    private async void OnButtonClicked(object sender, EventArgs e)
    {

        Application.Current.MainPage = new NavigationPage(new LoginPage());

    }

    private void LanguageApply()
    {
        string lang = Preferences.Get("Language", null);
        _translation = new Translation(lang);
        if (!string.IsNullOrEmpty(lang))
        {
            MainText_Label.Text = _translation.IntroPageMainText;
            MainBtn_Text.Text = _translation.IntroPageGetStarted;
            //this.Title = _translation.IntroductionPageTitle;
        }
    }


}
