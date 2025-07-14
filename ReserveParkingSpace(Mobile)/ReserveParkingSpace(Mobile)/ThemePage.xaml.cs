using ReserveParkingSpace_Mobile_.Data.Customazations;

namespace ReserveParkingSpace_Mobile_;

public partial class ThemePage : ContentPage
{
    private Translation _translation;
    public ThemePage()
	{
		InitializeComponent();
        LanguageApply();
        ThemeChanging();
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
                    Off_Label.TextColor = Color.FromHex("#FFFCFB");
                    On_Label.TextColor = Color.FromHex("#FFFCFB");
                    On_Border.BackgroundColor = Color.FromHex("#FFFCFB");
                    On_Border.Stroke = Color.FromHex("#FFFCFB");
                    Off_Border.BackgroundColor = Color.FromHex("#FFFCFB");
                    Off_Border.Stroke = Color.FromHex("#FFFCFB");
                }
                else if (color == "white")
                {
                    this.BackgroundColor = Color.FromHex("#222831");//tuk za byalo BC
                    barBackgroundSetter.Value = Color.FromHex("#FFFCFB");
                    Off_Label.TextColor = Color.FromHex("#FFFCFB");
                    On_Label.TextColor = Color.FromHex("#FFFCFB");//tuk e za bara gore
                    On_Border.BackgroundColor = Color.FromHex("#FFFCFB");
                    On_Border.Stroke = Color.FromHex("#FFFCFB");
                    Off_Border.BackgroundColor = Color.FromHex("#FFFCFB");
                    Off_Border.Stroke = Color.FromHex("#FFFCFB");
                }
            }

        }
    }
}
