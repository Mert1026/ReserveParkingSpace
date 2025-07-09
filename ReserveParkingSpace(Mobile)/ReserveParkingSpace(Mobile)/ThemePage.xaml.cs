namespace ReserveParkingSpace_Mobile_;

public partial class ThemePage : ContentPage
{
	public ThemePage()
	{
		InitializeComponent();
	}
    private void OnEnableCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value) // Enable checkbox checked
        {
            DisableCheckBox.CheckedChanged -= OnDisableCheckedChanged;
            DisableCheckBox.IsChecked = false;
            DisableCheckBox.CheckedChanged += OnDisableCheckedChanged;
        }
    }

    private void OnDisableCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value) // Disable checkbox checked
        {
            EnableCheckBox.CheckedChanged -= OnEnableCheckedChanged;
            EnableCheckBox.IsChecked = false;
            EnableCheckBox.CheckedChanged += OnEnableCheckedChanged;
        }
    }
    private void OnSaveClicked(object sender, EventArgs e)
    {
        // Handle button click logic here
        DisplayAlert("Saved", "Username saved successfully!", "OK");
    }
}
