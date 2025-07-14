using ReserveParkingSpace_Mobile_.Data.Customazations;

namespace ReserveParkingSpace_Mobile_;

public partial class LoadingPage : ContentPage
{
    private Translation _translation;
    public LoadingPage()
	{
		InitializeComponent();
        LanguageApply();
        ThemeChanging();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ThemeChanging();
    }
    private void LanguageApply()
    {
        string lang = Preferences.Get("Language", null);
        _translation = new Translation(lang);
        if (!string.IsNullOrEmpty(lang))
        {
            //MainText_Label.Text = _translation.
            //TO DO
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
                    this.BackgroundColor = Color.FromHex("#000000");//tuk e za cherno BC
                    barBackgroundSetter.Value = Color.FromHex("#222831");//tuk e za bara gore
                    ActivityIndicator_Main.Color = Color.FromHex("#FFFFFF");//tuk e za zarajdaneto
                    MainText_Label.TextColor = Color.FromHex("#FFFFFF");//tuk e za texta
                }
                else if (color == "white")
                {
                    this.BackgroundColor = Color.FromHex("#ffffff");//tuk za byalo BC
                    barBackgroundSetter.Value = Color.FromHex("#FFFCFB");//tuk e za bara gore
                    ActivityIndicator_Main.Color = Color.FromHex("#000000");//tuk e za zarajdaneto
                    MainText_Label.TextColor = Color.FromHex("#000000");//tuk e za texta
                }
            }

        }
    }
}