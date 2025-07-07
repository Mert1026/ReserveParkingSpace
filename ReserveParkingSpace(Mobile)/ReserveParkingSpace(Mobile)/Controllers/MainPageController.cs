
using ReserveParkingSpace_Mobile_.Controllers.IControllers;
using ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_models;
using ReserveParkingSpace_Mobile_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Controllers
{
    public class MainPageController : IMainPageController
    {
        public DataService DataService;
        public MainPageController(DataService _dataService)
        {
            DataService = new DataService();
        }

        public async Task<ParkingDashboardResponse> GetParkingDashboardAsync(string date)
        {
           
            
                return await DataService.GetParkingDashboardAsync(date);
            

        }
    }
}
