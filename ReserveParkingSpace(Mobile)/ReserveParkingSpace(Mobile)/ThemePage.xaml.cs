namespace ReserveParkingSpace_Mobile_;

public partial class ThemePage : ContentPage
{
	public ThemePage()
	{
		InitializeComponent();
	}
    private void OnEnglishCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            BulgarianCheckBox.IsChecked = false;
        }
    }

    private void OnBulgarianCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            EnglishCheckBox.IsChecked = false;
        }
    }
    private void OnSaveClicked(object sender, EventArgs e)
    {
        // Handle button click logic here
        DisplayAlert("Saved", "Username saved successfully!", "OK");
    }
}
