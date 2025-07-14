using Java.Lang;
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
        ThemeChanging();
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
    private void ThemeChanging()
    {
        string color = Preferences.Get("Color", null);
        if (Application.Current.Resources.TryGetValue(typeof(NavigationPage).ToString(), out var resource)
            && resource is Style navigationPageStyle
            && color != null)
        {
            var barBackgroundSetter = navigationPageStyle.Setters
                .FirstOrDefault(s => s.Property == NavigationPage.BarBackgroundColorProperty);

            if (barBackgroundSetter != null)
            {
                if (color == "black")
                {
                    this.BackgroundColor = Color.FromHex("#222831");
                    if (this.Parent is NavigationPage navPage)
                    {
                        navPage.BarBackgroundColor = Color.FromHex("#294D91");
                    }
                    Shell.SetBackgroundColor(this, Color.FromArgb("#192E57"));

                    // OPTIONAL: Dark mode customization
                    UserName_Label.TextColor = Color.FromHex("#FFFFFF");
                    FirstName_Label.TextColor = Color.FromHex("#FFFFFF");
                    Surname_Label.TextColor = Color.FromHex("#FFFFFF");
                    Department_Label.TextColor = Color.FromHex("#FFFFFF");
                    LastChangedTitle_Label.TextColor = Color.FromHex("#FFFFFF");
                    MemberSinceTitle_Label.TextColor = Color.FromHex("#FFFFFF");
                    UserName_Entry.TextColor = Color.FromHex("#FFFFFF");
                    FirstName_Entry.TextColor = Color.FromHex("#FFFFFF");
                    Surname_Entry.TextColor = Color.FromHex("#FFFFFF");
                    Departmnet_Picker.TextColor = Color.FromHex("#FFFFFF");
                    MemberSince_Label.TextColor = Color.FromHex("#FFFFFF");
                    LastChanged_Label.TextColor = Color.FromHex("#FFFFFF");
                    Border1.Stroke = Color.FromHex("#FFFFFF");
                    Border2.Stroke = Color.FromHex("#FFFFFF");
                    Border3.Stroke = Color.FromHex("#FFFFFF");
                    Border4.Stroke = Color.FromHex("#FFFFFF");
                    Border5.Stroke = Color.FromHex("#FFFFFF");
                    Border6.Stroke = Color.FromHex("#FFFFFF");


                    // If you have images:
                    // Profile_Icon.Source = "profile_dark.png";
                }
                else if (color == "white")
                {
                    this.BackgroundColor = Color.FromHex("#f5f9ff");
                    if (this.Parent is NavigationPage navPage)
                    {
                        navPage.BarBackgroundColor = Color.FromHex("#3a6bc8");
                    }

                    // OPTIONAL: Light mode customization
                    UserName_Label.TextColor = Color.FromHex("#000000");
                    FirstName_Label.TextColor = Color.FromHex("#000000");
                    Surname_Label.TextColor = Color.FromHex("#000000");
                    Department_Label.TextColor = Color.FromHex("#000000");
                    LastChangedTitle_Label.TextColor = Color.FromHex("#000000");
                    MemberSinceTitle_Label.TextColor = Color.FromHex("#000000");
             
                    // Profile_Icon.Source = "profile_light.png";
                }
            }
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