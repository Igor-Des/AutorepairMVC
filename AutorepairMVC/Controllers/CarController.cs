using AutorepairMVC.Data;
using AutorepairMVC.Models;
using AutorepairMVC.ViewModels;
using FuelStation.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AutorepairMVC.Controllers
{
    [ExceptionFilter]
    [TypeFilter(typeof(TimingLogAttribute))]
    public class CarController : Controller
    {
        private readonly AutorepairContext _db;
        public CarController(AutorepairContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            int numberRows = 15;

            List<Owner> owners = _db.Owners.Take(numberRows).ToList();
            List<Car> cars = _db.Cars.Take(numberRows).ToList();


            CarViewModel carViewModel = new CarViewModel
            {
                Owners = owners,
                Cars = cars
            };
            return View(carViewModel);
        }

    }
}