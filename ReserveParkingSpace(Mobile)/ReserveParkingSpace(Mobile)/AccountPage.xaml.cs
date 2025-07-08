namespace ReserveParkingSpace_Mobile_;

public partial class AccountPage : ContentPage
{
	public AccountPage()
	{
		InitializeComponent();
	}
    private void OnSaveClicked(object sender, EventArgs e)
    {
        // Handle button click logic here
        DisplayAlert("Saved", "Username saved successfully!", "OK");
    }
}