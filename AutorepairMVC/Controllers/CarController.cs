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

            List<Car> cars = _db.Cars.Take(numberRows).ToList();
            List<Owner> owners = _db.Owners.Take(numberRows).ToList();

            List<CarViewModel> carsView = _db.Cars
                .OrderByDescending(d => d.CarId)
                .Select(c => new CarViewModel
                {
                    CarId = c.CarId,
                    Brand = c.Brand,
                    Power = c.Power,
                    Color = c.Color,
                    StateNumber = c.StateNumber,
                    OwnerFIO = c.Owner.FirstName + " " + c.Owner.MiddleName + " " + c.Owner.LastName,
                    Year = c.Year,
                    VIN = c.VIN,
                    EngineNumber = c.EngineNumber,
                    AdmissionDate = c.AdmissionDate

                })
                .Take(numberRows)
                .ToList();


            CarOwnerViewModel carViewModel = new CarOwnerViewModel
            {
                Owners = owners,
                Cars = carsView
            };
            return View(carViewModel);
        }

    }
}