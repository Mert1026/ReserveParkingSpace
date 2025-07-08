using ReserveParkingSpace_Mobile_.Data.Models;
using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_Models;
using ReserveParkingSpace_Mobile_.Data.Models.Login_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Controllers.IControllers
{
    interface IMainPageController
    {
        public Task<ParkingDashboardResponse> GetParkingDashboardAsync(string date);
        public Task<bool> LoginAsync(string email, string password);
    }
}
