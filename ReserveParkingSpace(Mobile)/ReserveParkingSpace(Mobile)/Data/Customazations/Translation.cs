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

        public class IntroPage
        {
            public class English
            {
                public string MainText = "Tired of driving in circles, hoping to find a place to park? With the Reserve Parking Space app, you'll never have to worry again. This app is designed specifically for a single, dedicated parking location-your reliable, always-available solution for secure and stress-free parking.";
                public string GetStarted = "Get Started";
            } 
            public class Bulgarian
            {
                public string MainText = "Уморени ли сте да обикаляте в кръг в търсене на място за паркиране? С приложението Reserve Parking Space никога повече няма да се притеснявате. То е създадено специално за едно конкретно, резервирано място за паркиране – вашето надеждно и винаги достъпно решение за сигурно и безстресово паркиране.";
                public string GetStarted = "Започни";
            }
            
        }
        public class LoginPage
        {
            public class English
            {
                public string LoginTitle = "Login";
                public string Email = "Email";
                public string Password = "Password:";
                public string ForgotPassword = "Forgot password";
                public string LoginButton = "Login";
                public string NoAccount = "Don't have an account yet?";
                public string Register = "Register";
            }

            public class Bulgarian
            {
                public string LoginTitle = "Вход";
                public string Email = "Имейл";
                public string Password = "Парола:";
                public string ForgotPassword = "Забравена парола";
                public string LoginButton = "Вход";
                public string NoAccount = "Нямате акаунт?";
                public string Register = "Регистрирайте се";
            }
        }
        public class MainPage
        {
            public class English
            {
                public string Title = "Let's Find Your Spot";
                public string SelectShiftLabel = "Select a shift";
                public string ChooseShift = "Choose a shift:";
                public string FirstShift = "First Shift";
                public string ChooseDate = "Choose date:";
                public string UploadNotice = "You need to upload your schedule if it's more than two days";
                public string UploadButton = "Upload The PDF";
                public string OccupiedLabel = "Occupied:";
                public string AvailableLabel = "Available:";
                public string SelectedSpace = "Space(20) selected for (shift)";
                public string SelectedDate = "From (Date) To (Date)";
                public string ReserveButton = "Reserve";
            }

            public class Bulgarian
            {
                public string Title = "Нека намерим твоето място";
                public string SelectShiftLabel = "Избери смяна";
                public string ChooseShift = "Избери смяна:";
                public string FirstShift = "Първа смяна";
                public string ChooseDate = "Избери дата:";
                public string UploadNotice = "Трябва да качите графика си, ако е за повече от два дена";
                public string UploadButton = "Качи PDF файла";
                public string OccupiedLabel = "Заети:";
                public string AvailableLabel = "Свободни:";
                public string SelectedSpace = "Място(20) избрано за (смяна)";
                public string SelectedDate = "От (Дата) до (Дата)";
                public string ReserveButton = "Резервирай";
            }
        }
        public class SettingsPage
        {
            public class English
            {
                public string DarkMode = "Dark Mode";
                public string Account = "Account";
                public string Language = "Language";
                public string YourSpaces = "Your Spaces";
            }
            public class Bulgarian
            {
                public string DarkMode = "Тъмен режим";
                public string Account = "Акаунт";
                public string Language = "Език";
                public string YourSpaces = "Твоите места";
            }
        }
        public class ThemePage
        {
            public class English
            {
                public string On = "On";
                public string Off = "Off";
    
            }
            public class Bulgarian
            {
                public string On = "Вкл.";
                public string Off = "Изкл."; 

            }
        }
        public class AccountPage
        {
            public class English
            {
                public string Username = "Username";
                public string FirstName = "First Name";
                public string Surname = "Surname";
                public string Department = "Department";
                public string Frontend = "Frontend";
                public string Backend = "Backend";
                public string Mobile = "Mobile";
                public string QA = "QA";
                public string MemberSince = "Member since";
                public string LastChanged = "Last changed";
                public string LogOut = "Log Out";
            }

            public class Bulgarian
            {
                public string Username = "Потребителско име";
                public string FirstName = "Първо име";
                public string Surname = "Фамилия";
                public string Department = "Отдел";
                public string Frontend = "Фронтенд";
                public string Backend = "Бекенд";
                public string Mobile = "Мобилен";
                public string QA = "Гаранция за качество";
                public string MemberSince = "Член от";
                public string LastChanged = "Последна промяна";
                public string LogOut = "Изход";
            }
        }
        public class LanguagePage
        {

            public class English
            {
                public string EnglishLang = "English";
                public string BulgarianLang = "Bulgarian";
            }

            public class Bulgarian
            {
                public string EnglishLang = "Английски";
                public string BulgarianLang = "Български";
            }
        }
    }
}
