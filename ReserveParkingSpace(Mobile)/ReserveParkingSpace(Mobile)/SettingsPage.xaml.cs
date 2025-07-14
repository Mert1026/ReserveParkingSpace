
using ReserveParkingSpace_Mobile_.Data.Customazations;

namespace ReserveParkingSpace_Mobile_;

public partial class SettingsPage : ContentPage
{
    private Translation _translation;
    public SettingsPage()
	{
		InitializeComponent();
        LanguageApply();
        ThemeChanging();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LanguageApply();
        ThemeChanging();
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

    private void LanguageApply()
    {
        string lang = Preferences.Get("Language", null);
        _translation = new Translation(lang);
        if (!string.IsNullOrEmpty(lang))
        {
            DarkMode_Label.Text = _translation.SettingsPageDarkMode;
            Account_Label.Text = _translation.SettingsPageAccount;
            Language_Label.Text = _translation.SettingsPageLanguage;
            YourSpaces_Label.Text = _translation.SettingsPageYourSpaces;
            this.Title = _translation.SettingsPageTitle;
        }
    }

    private void ThemeChanging()
    {
        string color = Preferences.Get("Color", null);
        if (Application.Current.Resources.TryGetValue(typeof(NavigationPage).ToString(), out var resource)
            && resource is Style navigationPageStyle
            && color != null)
        {
            // Find the BarBackgroundColor setter
            var barBackgroundSetter = navigationPageStyle.Setters
                .FirstOrDefault(s => s.Property == NavigationPage.BarBackgroundColorProperty);

            if (barBackgroundSetter != null)
            {
                if (color == "black")
                {
                    this.BackgroundColor = Color.FromHex("#222831");//tuk e za cherno BC
                    if (this.Parent is NavigationPage navPage)
                    {
                        navPage.BarBackgroundColor = Color.FromHex("#294D91");
                    }
                    
                    Arrow_Label1.TextColor = Color.FromHex("#FFFFFF");
                    Arrow_Label2.TextColor = Color.FromHex("#FFFFFF");
                    Arrow_Label3.TextColor = Color.FromHex("#FFFFFF");
                    Arrow_Label4.TextColor = Color.FromHex("#FFFFFF");
                    Account_Label.TextColor = Color.FromHex("#FFFFFF");
                    DarkMode_Label.TextColor = Color.FromHex("#FFFFFF");
                    Language_Label.TextColor = Color.FromHex("#FFFFFF");
                    YourSpaces_Label.TextColor = Color.FromHex("#FFFFFF");
                    Shell.SetBackgroundColor(this, Color.FromArgb("#192E57"));
                    Image1.Source = "dark_mode_dark.png";
                    Image2.Source = "account_dark.png";
                    Image3.Source = "language_dark.png";
                    Image4.Source = "car_dark.png";
                    Border_1.BackgroundColor = Color.FromHex("#222831");
                    Border_2.BackgroundColor = Color.FromHex("#222831");
                    Border_3.BackgroundColor = Color.FromHex("#222831");
                    Border_4.BackgroundColor = Color.FromHex("#222831");
                    Border_1.Stroke = Color.FromHex("#222831");
                    Border_2.Stroke = Color.FromHex("#222831");
                    Border_3.Stroke = Color.FromHex("#222831");
                    Border_4.Stroke = Color.FromHex("#222831");


                }
                else if (color == "white")
                {
                    this.BackgroundColor = Color.FromHex("#f5f9ff");//tuk za byalo BC
                    if (this.Parent is NavigationPage navPage)
                    {
                        navPage.BarBackgroundColor = Color.FromHex("#3a6bc8");
                    }
                    Border_1.BackgroundColor = Color.FromHex("#f5f9ff");
                    Border_2.BackgroundColor = Color.FromHex("#f5f9ff");
                    Border_3.BackgroundColor = Color.FromHex("#f5f9ff");
                    Border_4.BackgroundColor = Color.FromHex("#f5f9ff");
                    Border_1.Stroke = Color.FromHex("#f5f9ff");
                    Border_2.Stroke = Color.FromHex("#f5f9ff");
                    Border_3.Stroke = Color.FromHex("#f5f9ff");
                    Border_4.Stroke = Color.FromHex("#f5f9ff");
                    Arrow_Label1.TextColor = Color.FromHex("#000000");
                    Arrow_Label2.TextColor = Color.FromHex("#000000");
                    Arrow_Label3.TextColor = Color.FromHex("#000000");
                    Arrow_Label4.TextColor = Color.FromHex("#000000");
                    Account_Label.TextColor = Color.FromHex("#000000");
                    DarkMode_Label.TextColor = Color.FromHex("#000000");
                    Language_Label.TextColor = Color.FromHex("#000000");
                    YourSpaces_Label.TextColor = Color.FromHex("#000000");
                    Image1.Source = "dark_mode.png";
                    Image2.Source = "account.png";
                    Image3.Source = "language.png";
                    Image4.Source = "car_logo.png";
                }
            }

        }
    }
}