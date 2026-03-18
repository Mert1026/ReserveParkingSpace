using ReserveParkingSpace_Mobile_.Data.Customazations;

namespace ReserveParkingSpace_Mobile_;

public partial class ThemePage : ContentPage
{
    private Translation _translation;
    public ThemePage()
    {
        InitializeComponent();
        LanguageApply();
        base.OnAppearing();
        ApplyCurrentTheme();
        string color = Preferences.Get("Color", null);
        if (color == "black")
        {
            EnableCheckBox.IsChecked = true;
            DisableCheckBox.IsChecked = false;
        }
        else if (color == "white")
        {
            EnableCheckBox.IsChecked = false;
            DisableCheckBox.IsChecked = true;
        }
        else
        {
            EnableCheckBox.IsChecked = false;
            DisableCheckBox.IsChecked = false;
        }
    }

    private void OnEnableCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value) // Enable checkbox checked
        {
            DisableCheckBox.CheckedChanged -= OnDisableCheckedChanged;
            DisableCheckBox.IsChecked = false;
            DisableCheckBox.CheckedChanged += OnDisableCheckedChanged;
            Preferences.Set("Color", "black");
            ApplyThemeGlobally("black");
        }
    }

    private void OnDisableCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value) // Disable checkbox checked
        {
            EnableCheckBox.CheckedChanged -= OnEnableCheckedChanged;
            EnableCheckBox.IsChecked = false;
            EnableCheckBox.CheckedChanged += OnEnableCheckedChanged;
            Preferences.Set("Color", "white");
            ApplyThemeGlobally("white");
        }
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        // Handle button click logic here
        DisplayAlert("Saved", "Success!", "OK");
    }

    private void LanguageApply()
    {
        string lang = Preferences.Get("Language", null);
        _translation = new Translation(lang);
        if (!string.IsNullOrEmpty(lang))
        {
            Off_Label.Text = _translation.ThemePageOff;
            On_Label.Text = _translation.ThemePageOn;
            this.Title = _translation.ThemePageTitle;
        }
    }

    private void ApplyCurrentTheme()
    {
        string color = Preferences.Get("Color", null);
        if (!string.IsNullOrEmpty(color))
        {
            ApplyThemeGlobally(color);
        }
    }

    private void ApplyThemeGlobally(string theme)
    {
        // Update Application Resources for global theme
        var app = Application.Current;
        if (app?.Resources != null)
        {
            if (theme == "black")
            {
                // Dark theme
                app.Resources["NavigationBarColor"] = Color.FromHex("#222831");
                app.Resources["PageBackgroundColor"] = Color.FromHex("#222831");
                app.Resources["TextColor"] = Color.FromHex("#FFFCFB");
                app.Resources["BorderColor"] = Color.FromHex("#FFFCFB");
                app.Resources["BorderBackgroundColor"] = Color.FromHex("#FFFCFB");
            }
            else if (theme == "white")
            {
                // Light theme
                app.Resources["NavigationBarColor"] = Color.FromHex("#FFFCFB");
                app.Resources["PageBackgroundColor"] = Color.FromHex("#FFFFFF"); // Fixed: should be white for light theme
                app.Resources["TextColor"] = Color.FromHex("#222831");
                app.Resources["BorderColor"] = Color.FromHex("#222831");
                app.Resources["BorderBackgroundColor"] = Color.FromHex("#222831");
            }
        }

        // Update current page immediately
        UpdateCurrentPageTheme(theme);

        // Update NavigationPage bar color
        UpdateNavigationBarColor(theme);
    }

    private void UpdateCurrentPageTheme(string theme)
    {
        if (theme == "black")
        {
            this.BackgroundColor = Color.FromHex("#222831");
            Off_Label.TextColor = Color.FromHex("#FFFFFF");
            On_Label.TextColor = Color.FromHex("#FFFFFF");
            On_Border.BackgroundColor = Color.FromHex("#222831");
            On_Border.Stroke = Color.FromHex("#FFFFFF");
            Off_Border.BackgroundColor = Color.FromHex("#222831");
            Off_Border.Stroke = Color.FromHex("#FFFFFF");
            DisableCheckBox.Color = Color.FromHex("#FFFFFF");
            EnableCheckBox.Color = Color.FromHex("#FFFFFF");
            if (this.Parent is NavigationPage navPage)
            {
                navPage.BarBackgroundColor = Color.FromHex("#294D91");
            }

        }
        else if (theme == "white")
        {
            this.BackgroundColor = Color.FromHex("#FFFFFF"); // Fixed: should be white
            Off_Label.TextColor = Color.FromHex("#000000");
            On_Label.TextColor = Color.FromHex("#000000");
            On_Border.BackgroundColor = Color.FromHex("#FFFFFF");
            On_Border.Stroke = Color.FromHex("#222831");
            Off_Border.BackgroundColor = Color.FromHex("#FFFFFF");
            Off_Border.Stroke = Color.FromHex("#222831");
            DisableCheckBox.Color = Color.FromHex("#000000");
            EnableCheckBox.Color = Color.FromHex("#000000");
            if (this.Parent is NavigationPage navPage)
            {
                navPage.BarBackgroundColor = Color.FromHex("#3a6bc8");
            }
        }
    }

    private void UpdateNavigationBarColor(string theme)
    {
        if (Application.Current.Resources.TryGetValue(typeof(NavigationPage).ToString(), out var resource)
            && resource is Style navigationPageStyle)
        {
            var barBackgroundSetter = navigationPageStyle.Setters
                .FirstOrDefault(s => s.Property == NavigationPage.BarBackgroundColorProperty);

            if (barBackgroundSetter != null)
            {
                if (theme == "black")
                {
                    barBackgroundSetter.Value = Color.FromHex("#222831");
                }
                else if (theme == "white")
                {
                    barBackgroundSetter.Value = Color.FromHex("#FFFCFB");
                }
            }
        }
    }
}