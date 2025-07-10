namespace ReserveParkingSpace_Mobile_;

public partial class IntroductionPage : ContentPage
{
	public IntroductionPage()
	{
		InitializeComponent();
     
	}
    private async void OnButtonClicked(object sender, EventArgs e)
    {

        Application.Current.MainPage = new NavigationPage(new LoginPage());

    }


}
