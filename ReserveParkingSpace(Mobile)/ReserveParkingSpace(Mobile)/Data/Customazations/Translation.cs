using Syncfusion.Maui.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Data.Customazations
{

    public class Translation
    {
        // IntroPage
        public string IntroPageMainText { get; set; }
        public string IntroPageGetStarted { get; set; }

        // LoginPage
        public string LoginPageTitle { get; set; }
        public string LoginPageEmail { get; set; }
        public string LoginPagePassword { get; set; }
        public string LoginPageForgotPassword { get; set; }
        public string LoginPageLoginButton { get; set; }
        public string LoginPageNoAccount { get; set; }
        public string LoginPageRegister { get; set; }

        // MainPage
        public string MainPageTitle { get; set; }
        public string MainPageSelectShiftLabel { get; set; }
        public string MainPageChooseShift { get; set; }
        public string MainPageFirstShift { get; set; }
        public string MainPageChooseDate { get; set; }
        public string MainPageUploadNotice { get; set; }
        public string MainPageUploadButton { get; set; }
        public string MainPageOccupiedLabel { get; set; }
        public string MainPageAvailableLabel { get; set; }
        public string MainPageSelectedSpace { get; set; }
        public string MainPageSelectedDate { get; set; }
        public string MainPageReserveButton { get; set; }
        public string MainPageMorningShift { get; set; }
        public string MainPageAfternoonShift { get; set; }
        public string MainPageAllDayShift { get; set; }

        // SettingsPage
        public string SettingsPageTitle { get; set; }
        public string SettingsPageDarkMode { get; set; }
        public string SettingsPageAccount { get; set; }
        public string SettingsPageLanguage { get; set; }
        public string SettingsPageYourSpaces { get; set; }

        // ThemePage
        public string ThemePageTitle { get; set; }
        public string ThemePageOn { get; set; }
        public string ThemePageOff { get; set; }

        // AccountPage
        public string AccountPageTitle { get; set; }
        public string AccountPageUsername { get; set; }
        public string AccountPageFirstName { get; set; }
        public string AccountPageSurname { get; set; }
        public string AccountPageDepartment { get; set; }
        public string AccountPageFrontend { get; set; }
        public string AccountPageBackend { get; set; }
        public string AccountPageMobile { get; set; }
        public string AccountPageQA { get; set; }
        public string AccountPageMemberSince { get; set; }
        public string AccountPageLastChanged { get; set; }
        public string AccountPageLogOut { get; set; }

        // LanguagePage
        public string LanguagePageTitle { get; set; }
        public string LanguagePageEnglish { get; set; }
        public string LanguagePageBulgarian { get; set; }

        public Translation(string language)
        {
            // Default English values
            IntroPageMainText = "Tired of driving in circles, hoping to find a place to park? With the Reserve Parking Space app, you'll never have to worry again. This app is designed specifically for a single, dedicated parking location-your reliable, always-available solution for secure and stress-free parking.";
            IntroPageGetStarted = "Get Started";

            LoginPageTitle = "Login";
            LoginPageEmail = "Email";
            LoginPagePassword = "Password:";
            LoginPageForgotPassword = "Forgot password";
            LoginPageLoginButton = "Login";
            LoginPageNoAccount = "Don't have an account yet?";
            LoginPageRegister = "Register";

            MainPageTitle = "Let's Find Your Spot";
            MainPageSelectShiftLabel = "Select a shift";
            MainPageChooseShift = "Choose a shift:";
            MainPageFirstShift = "First Shift";
            MainPageChooseDate = "Choose date:";
            MainPageUploadNotice = "You need to upload your schedule if it's more than two days";
            MainPageUploadButton = "Upload The PDF";
            MainPageOccupiedLabel = "Occupied:";
            MainPageAvailableLabel = "Available:";
            MainPageSelectedSpace = "Space(20) selected for (shift)";
            MainPageSelectedDate = "From (Date) To (Date)";
            MainPageReserveButton = "Reserve";
            MainPageMorningShift = "Morning";
            MainPageAfternoonShift = "Afternoon";
            MainPageAllDayShift = "Full Day";

            SettingsPageTitle = "Settings";
            SettingsPageDarkMode = "Dark Mode";
            SettingsPageAccount = "Account";
            SettingsPageLanguage = "Language";
            SettingsPageYourSpaces = "Your Spaces";

            ThemePageTitle = "Theme";
            ThemePageOn = "On";
            ThemePageOff = "Off";

            AccountPageTitle = "Account";
            AccountPageUsername = "Username";
            AccountPageFirstName = "First Name";
            AccountPageSurname = "Surname";
            AccountPageDepartment = "Department";
            AccountPageFrontend = "Frontend";
            AccountPageBackend = "Backend";
            AccountPageMobile = "Mobile";
            AccountPageQA = "QA";
            AccountPageMemberSince = "Member since";
            AccountPageLastChanged = "Last changed";
            AccountPageLogOut = "Log Out";

            LanguagePageTitle = "Language";
            LanguagePageEnglish = "English";
            LanguagePageBulgarian = "Bulgarian";

            if (language == "bg")
            {
                IntroPageMainText = "Уморени ли сте да обикаляте в кръг в търсене на място за паркиране? С приложението Reserve Parking Space никога повече няма да се притеснявате. То е създадено специално за едно конкретно, резервирано място за паркиране – вашето надеждно и винаги достъпно решение за сигурно и безстресово паркиране.";
                IntroPageGetStarted = "Започни";

                LoginPageTitle = "Вход";
                LoginPageEmail = "Имейл";
                LoginPagePassword = "Парола:";
                LoginPageForgotPassword = "Забравена парола";
                LoginPageLoginButton = "Вход";
                LoginPageNoAccount = "Нямате акаунт?";
                LoginPageRegister = "Регистрирайте се";


                MainPageTitle = "Нека намерим твоето място";
                MainPageSelectShiftLabel = "Избери смяна";//ne
                MainPageChooseShift = "Избери смяна:";
                MainPageFirstShift = "Първа смяна";
                MainPageChooseDate = "Избери дата:";
                MainPageUploadNotice = "Трябва да качите графика си, ако е за повече от два дена";
                MainPageUploadButton = "Качи PDF файла";
                MainPageOccupiedLabel = "Заети:";
                MainPageAvailableLabel = "Свободни:";
                MainPageSelectedSpace = "Място(20) избрано за (смяна)";
                MainPageSelectedDate = "От (Дата) до (Дата)";
                MainPageReserveButton = "Резервирай";
                MainPageMorningShift = "Сутрин";
                MainPageAfternoonShift = "Обед";
                MainPageAllDayShift = "Цял ден";


                SettingsPageTitle = "Настройки";
                SettingsPageDarkMode = "Тъмен режим";
                SettingsPageAccount = "Акаунт";
                SettingsPageLanguage = "Език";
                SettingsPageYourSpaces = "Твоите места";

                ThemePageTitle = "Тема";
                ThemePageOn = "Вкл.";
                ThemePageOff = "Изкл.";

                AccountPageTitle = "Акаунт";
                AccountPageUsername = "Потребителско име";
                AccountPageFirstName = "Първо име";
                AccountPageSurname = "Фамилия";
                AccountPageDepartment = "Отдел";
                AccountPageFrontend = "Фронтенд";
                AccountPageBackend = "Бекенд";
                AccountPageMobile = "Мобилен";
                AccountPageQA = "Гаранция за качество";
                AccountPageMemberSince = "Член от";
                AccountPageLastChanged = "Последна промяна";
                AccountPageLogOut = "Изход";

                LanguagePageTitle = "Език";
                LanguagePageEnglish = "Английски";
                LanguagePageBulgarian = "Български";
            }
        }
    }


    //public class Translation
    //{

    //    public class IntroPage
    //    {
    //        public class English
    //        {
    //            public string MainText = "Tired of driving in circles, hoping to find a place to park? With the Reserve Parking Space app, you'll never have to worry again. This app is designed specifically for a single, dedicated parking location-your reliable, always-available solution for secure and stress-free parking.";
    //            public string GetStarted = "Get Started";
    //        } 
    //        public class Bulgarian
    //        {
    //            public string MainText = "Уморени ли сте да обикаляте в кръг в търсене на място за паркиране? С приложението Reserve Parking Space никога повече няма да се притеснявате. То е създадено специално за едно конкретно, резервирано място за паркиране – вашето надеждно и винаги достъпно решение за сигурно и безстресово паркиране.";
    //            public string GetStarted = "Започни";
    //        }

    //    }
    //    public class LoginPage
    //    {
    //        public class English
    //        {
    //            public string LoginTitle = "Login";
    //            public string Email = "Email";
    //            public string Password = "Password:";
    //            public string ForgotPassword = "Forgot password";
    //            public string LoginButton = "Login";
    //            public string NoAccount = "Don't have an account yet?";
    //            public string Register = "Register";
    //        }

    //        public class Bulgarian
    //        {
    //            public string LoginTitle = "Вход";
    //            public string Email = "Имейл";
    //            public string Password = "Парола:";
    //            public string ForgotPassword = "Забравена парола";
    //            public string LoginButton = "Вход";
    //            public string NoAccount = "Нямате акаунт?";
    //            public string Register = "Регистрирайте се";
    //        }
    //    }
    //    public class MainPage
    //    {
    //        public class English
    //        {
    //            public string Title = "Let's Find Your Spot";
    //            public string SelectShiftLabel = "Select a shift";
    //            public string ChooseShift = "Choose a shift:";
    //            public string FirstShift = "First Shift";
    //            public string ChooseDate = "Choose date:";
    //            public string UploadNotice = "You need to upload your schedule if it's more than two days";
    //            public string UploadButton = "Upload The PDF";
    //            public string OccupiedLabel = "Occupied:";
    //            public string AvailableLabel = "Available:";
    //            public string SelectedSpace = "Space(20) selected for (shift)";
    //            public string SelectedDate = "From (Date) To (Date)";
    //            public string ReserveButton = "Reserve";
    //        }

    //        public class Bulgarian
    //        {
    //            public string Title = "Нека намерим твоето място";
    //            public string SelectShiftLabel = "Избери смяна";
    //            public string ChooseShift = "Избери смяна:";
    //            public string FirstShift = "Първа смяна";
    //            public string ChooseDate = "Избери дата:";
    //            public string UploadNotice = "Трябва да качите графика си, ако е за повече от два дена";
    //            public string UploadButton = "Качи PDF файла";
    //            public string OccupiedLabel = "Заети:";
    //            public string AvailableLabel = "Свободни:";
    //            public string SelectedSpace = "Място(20) избрано за (смяна)";
    //            public string SelectedDate = "От (Дата) до (Дата)";
    //            public string ReserveButton = "Резервирай";
    //        }
    //    }
    //    public class SettingsPage
    //    {
    //        public class English
    //        {
    //            public string DarkMode = "Dark Mode";
    //            public string Account = "Account";
    //            public string Language = "Language";
    //            public string YourSpaces = "Your Spaces";
    //        }
    //        public class Bulgarian
    //        {
    //            public string DarkMode = "Тъмен режим";
    //            public string Account = "Акаунт";
    //            public string Language = "Език";
    //            public string YourSpaces = "Твоите места";
    //        }
    //    }
    //    public class ThemePage
    //    {
    //        public class English
    //        {
    //            public string On = "On";
    //            public string Off = "Off";

    //        }
    //        public class Bulgarian
    //        {
    //            public string On = "Вкл.";
    //            public string Off = "Изкл."; 

    //        }
    //    }
    //    public class AccountPage
    //    {
    //        public class English
    //        {
    //            public string Username = "Username";
    //            public string FirstName = "First Name";
    //            public string Surname = "Surname";
    //            public string Department = "Department";
    //            public string Frontend = "Frontend";
    //            public string Backend = "Backend";
    //            public string Mobile = "Mobile";
    //            public string QA = "QA";
    //            public string MemberSince = "Member since";
    //            public string LastChanged = "Last changed";
    //            public string LogOut = "Log Out";
    //        }

    //        public class Bulgarian
    //        {
    //            public string Username = "Потребителско име";
    //            public string FirstName = "Първо име";
    //            public string Surname = "Фамилия";
    //            public string Department = "Отдел";
    //            public string Frontend = "Фронтенд";
    //            public string Backend = "Бекенд";
    //            public string Mobile = "Мобилен";
    //            public string QA = "Гаранция за качество";
    //            public string MemberSince = "Член от";
    //            public string LastChanged = "Последна промяна";
    //            public string LogOut = "Изход";
    //        }
    //    }
    //    public class LanguagePage
    //    {

    //        public class English
    //        {
    //            public string EnglishLang = "English";
    //            public string BulgarianLang = "Bulgarian";
    //        }

    //        public class Bulgarian
    //        {
    //            public string EnglishLang = "Английски";
    //            public string BulgarianLang = "Български";
    //        }
    //    }
    //}
}
