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
                    barBackgroundSetter.Value = Color.FromHex("#222831");//tuk e za bara gore
                    Border_1.BackgroundColor = Color.FromHex("#FFFCFB");
                    Border_1.BackgroundColor = Color.FromHex("#FFFCFB");
                    Border_1.BackgroundColor = Color.FromHex("#FFFCFB");
                    Border_1.BackgroundColor = Color.FromHex("#FFFCFB");
                    Border_1.Stroke = Color.FromHex("#FFFCFB");
                    Border_2.Stroke = Color.FromHex("#FFFCFB");
                    Border_3.Stroke = Color.FromHex("#FFFCFB");
                    Border_4.Stroke = Color.FromHex("#FFFCFB");
                    Arrow_Label1.TextColor = Color.FromHex("#FFFCFB");
                    Arrow_Label2.TextColor = Color.FromHex("#FFFCFB");
                    Arrow_Label3.TextColor = Color.FromHex("#FFFCFB");
                    Arrow_Label4.TextColor = Color.FromHex("#FFFCFB");
                    Account_Label.TextColor = Color.FromHex("#FFFCFB");
                    DarkMode_Label.TextColor = Color.FromHex("#FFFCFB");
                    Language_Label.TextColor = Color.FromHex("#FFFCFB");
                    YourSpaces_Label.TextColor = Color.FromHex("#FFFCFB");

                }
                else if (color == "white")
                {
                    this.BackgroundColor = Color.FromHex("#222831");//tuk za byalo BC
                    barBackgroundSetter.Value = Color.FromHex("#FFFCFB");//tuk e za bara gore
                    Border_1.BackgroundColor = Color.FromHex("#FFFCFB");
                    Border_1.BackgroundColor = Color.FromHex("#FFFCFB");
                    Border_1.BackgroundColor = Color.FromHex("#FFFCFB");
                    Border_1.BackgroundColor = Color.FromHex("#FFFCFB");
                    Border_1.Stroke = Color.FromHex("#FFFCFB");
                    Border_2.Stroke = Color.FromHex("#FFFCFB");
                    Border_3.Stroke = Color.FromHex("#FFFCFB");
                    Border_4.Stroke = Color.FromHex("#FFFCFB");
                    Arrow_Label1.TextColor = Color.FromHex("#FFFCFB");
                    Arrow_Label2.TextColor = Color.FromHex("#FFFCFB");
                    Arrow_Label3.TextColor = Color.FromHex("#FFFCFB");
                    Arrow_Label4.TextColor = Color.FromHex("#FFFCFB");
                    Account_Label.TextColor = Color.FromHex("#FFFCFB");
                    DarkMode_Label.TextColor = Color.FromHex("#FFFCFB");
                    Language_Label.TextColor = Color.FromHex("#FFFCFB");
                    YourSpaces_Label.TextColor = Color.FromHex("#FFFCFB");
                }
            }

        }
    }
}