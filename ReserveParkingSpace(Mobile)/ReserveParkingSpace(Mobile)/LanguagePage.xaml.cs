using ReserveParkingSpace_Mobile_.Data.Customazations;

namespace ReserveParkingSpace_Mobile_;

public partial class LanguagePage : ContentPage
{
    private Translation _translation;
    
    public LanguagePage()
	{
		InitializeComponent();
        LanguageApply();
        ThemeChanging();
    }
    private void OnEnglishCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            BulgarianCheckBox.IsChecked = false;
            Preferences.Set("Language", "en");
        }
    }

    private void OnBulgarianCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            EnglishCheckBox.IsChecked = false;
            Preferences.Set("Language", "bg");
        }
    }
    private void OnSaveClicked(object sender, EventArgs e)
    {
        // Handle button click logic here
        DisplayAlert("Saved", "Username saved successfully!", "OK");
    }

    private void LanguageApply()
    {
        string lang = Preferences.Get("Language", null);
        _translation = new Translation(lang);
        
        if (!string.IsNullOrEmpty(lang))
        {
            English_Label.Text = _translation.LanguagePageEnglish;
            Bulgarian_Label.Text = _translation.LanguagePageBulgarian;
            this.Title = _translation.LanguagePageTitle;

            if (lang == "en")
            {
                EnglishCheckBox.IsChecked = true;
                BulgarianCheckBox.IsChecked = false;
            }
            else if (lang == "bg")
            {
                EnglishCheckBox.IsChecked = false;
                BulgarianCheckBox.IsChecked = true;
            }
            else
            {
                EnglishCheckBox.IsChecked = false;
                BulgarianCheckBox.IsChecked = false;
            }
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
                    Border_2.BackgroundColor = Color.FromHex("#FFFCFB");
                    Border_1.Stroke = Color.FromHex("#FFFCFB");
                    Border_2.Stroke = Color.FromHex("#FFFCFB");
                    Bulgarian_Label.TextColor = Color.FromHex("#FFFCFB");
                    English_Label.TextColor = Color.FromHex("#FFFCFB");

                }
                else if (color == "white")
                {
                    this.BackgroundColor = Color.FromHex("#222831");//tuk za byalo BC
                    barBackgroundSetter.Value = Color.FromHex("#FFFCFB");//tuk e za bara gore
                    Border_1.BackgroundColor = Color.FromHex("#FFFCFB");
                    Border_2.BackgroundColor = Color.FromHex("#FFFCFB");
                    Border_1.Stroke = Color.FromHex("#FFFCFB");
                    Border_2.Stroke = Color.FromHex("#FFFCFB");
                    Bulgarian_Label.TextColor = Color.FromHex("#FFFCFB");
                    English_Label.TextColor = Color.FromHex("#FFFCFB");
                }
            }

        }
    }
}