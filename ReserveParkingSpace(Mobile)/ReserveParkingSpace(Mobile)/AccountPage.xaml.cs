using ReserveParkingSpace_Mobile_.Controllers;
using ReserveParkingSpace_Mobile_.Data.Models.UserCredintalsChange_Models;
using ReserveParkingSpace_Mobile_.Services;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_;

public partial class AccountPage : ContentPage
{
    private MainPageController _controller { get; set; }
    public AccountPage()
	{
		InitializeComponent();
        _controller = new MainPageController(new DataService());
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Handle button click logic here
        UserProfile updatedProfile = new UserProfile
        {
            Username = UserName_Entry.Text != null 
            ? UserName_Entry.Text : "no name",
            FirstName = FirstName_Entry.Text != null 
            ? FirstName_Entry.Text : "no name",
            Department = Departmnet_Picker.SelectedItem.ToString(),//TO DO
            Surname = Surname_Entry.Text != null
            ? Surname_Entry.Text : "no name",

        };
        string token = await SecureStorage.GetAsync("token");
        bool check = await _controller.ChangeUserCredidentialsAsync(updatedProfile, token);
        if(!check)
        {
            await DisplayAlert("Error", "Failed to save username. Please try again.", "OK");//navigacviq kum err page!!
            return;
        }

        await DisplayAlert("Saved", "Username saved successfully!", "OK");
    }
}