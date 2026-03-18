using ReserveParkingSpace_Mobile_.Data.Customazations;

namespace ReserveParkingSpace_Mobile_;

public partial class ErrorPage : ContentPage
{
    private Translation _translation;
    public ErrorPage()
	{
		InitializeComponent();
	}

    private void LanguageAplly()
    {
        string lang = Preferences.Get("Language", null);
        _translation = new Translation(lang);
        if (!string.IsNullOrEmpty(lang))
        {
            //MainText_Label.Text = _translation.ErrorPageMainText;
            //this.Title = _translation.ErrorPageTitle;
        }
    }
}