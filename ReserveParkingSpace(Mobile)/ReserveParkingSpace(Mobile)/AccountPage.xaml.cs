using Microsoft.Extensions.Logging;
using ReserveParkingSpace_Mobile_.Controllers;
using ReserveParkingSpace_Mobile_.Data.Customazations;
using ReserveParkingSpace_Mobile_.Data.Models.Login_Models;
using ReserveParkingSpace_Mobile_.Data.Models.UserCredintalsChange_Models;
using ReserveParkingSpace_Mobile_.Services;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_;

public partial class AccountPage : ContentPage
{
    private Translation _translation;
    private MainPageController _controller { get; set; }
    public AccountPage()
	{
		InitializeComponent();
        _controller = new MainPageController(new DataService());
        EntriesFill();
        LanguageApply();
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
        string pass = await SecureStorage.GetAsync("password");
        string email = Preferences.Get("email", null);
        await _controller.LoginAsync(email, pass);//bavnicko e i nema error-handling
        await DisplayAlert("Saved", "User updated successfully!", "OK");
    }

    private async void EntriesFill()
    {
        UserName_Entry.Text =  Preferences.Get("Username", null);
        FirstName_Entry.Text = Preferences.Get("FirstName", null);
        Surname_Entry.Text = Preferences.Get("Surname", null);
        Departmnet_Picker.SelectedItem = Preferences.Get("Department", null);//TC TC TC mnogo greshno
        string dp = Preferences.Get("Department", null);
        if(dp == "frontend")
        {
            Departmnet_Picker.SelectedIndex = 0;
        }
        else if(dp == "backend")
        {
            Departmnet_Picker.SelectedIndex = 1;
        }
        else if(dp == "mobile")
        {
            Departmnet_Picker.SelectedIndex = 2;
        }
        else if (dp == "qa")
        {
            Departmnet_Picker.SelectedIndex = 3;
        }
        else
        {
            Departmnet_Picker.SelectedIndex = -1; // No selection
        }
    }

    private void LanguageApply()
    {
        string lang = Preferences.Get("Language", null);
        _translation = new Translation(lang);
        if (!string.IsNullOrEmpty(lang))
        {
            UserName_Label.Text = _translation.AccountPageUsername;
            FirstName_Label.Text = _translation.AccountPageFirstName;
            Surname_Label.Text = _translation.AccountPageSurname;
            Department_Label.Text = _translation.AccountPageDepartment;
            LastChangedTitle_Label.Text = _translation.AccountPageLastChanged;
            MemberSinceTitle_Label.Text = _translation.AccountPageMemberSince;
            //this.Title = _translation.AccountPageTitle; // Uncomment if you have a title 
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Preferences.Set("RememberMe", "False");
        Application.Current.MainPage = new IntroductionPage();
    }
}