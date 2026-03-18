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
                    Border_1.BackgroundColor = Color.FromHex("#222831");
                    Border_2.BackgroundColor = Color.FromHex("#222831");
                    Border_1.Stroke = Color.FromHex("#FFFFFF");
                    Border_2.Stroke = Color.FromHex("#FFFFFF");
                    Bulgarian_Label.TextColor = Color.FromHex("#FFFFFF");
                    English_Label.TextColor = Color.FromHex("#FFFFFF");
                    EnglishCheckBox.Color = Color.FromHex("FFFFFF");
                    BulgarianCheckBox.Color = Color.FromHex("FFFFFF");

                }
                else if (color == "white")
                {
                    this.BackgroundColor = Color.FromHex("#f5f9ff");//tuk za byalo BC
                  
                    Border_1.BackgroundColor = Color.FromHex("#f5f9ff");
                    Border_2.BackgroundColor = Color.FromHex("#f5f9ff");
                    Border_1.Stroke = Color.FromHex("#000000");
                    Border_2.Stroke = Color.FromHex("#000000");
                    Bulgarian_Label.TextColor = Color.FromHex("#000000");
                    English_Label.TextColor = Color.FromHex("#000000");
                    EnglishCheckBox.Color = Color.FromHex("000000");
                    BulgarianCheckBox.Color = Color.FromHex("000000");

                }
            }

        }
    }
}