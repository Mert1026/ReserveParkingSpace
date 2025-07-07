using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Services.IServices
{
    interface IDataService
    {
        public Task<ParkingDashboardResponse> GetParkingDashboardAsync(string date);
    }
}