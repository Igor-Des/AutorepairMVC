using AutorepairMVC.Data;
using AutorepairMVC.Models;
using AutorepairMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AutorepairMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AutorepairContext _db;
        public HomeController(AutorepairContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            int numberRows = 10;
            List<CarViewModel> cars = _db.Cars
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

            List<Owner> owners = _db.Owners.Take(numberRows).ToList();
            List<MechanicViewModel> mechanics = _db.Mechanics.Take(numberRows)
                .Select(m => new MechanicViewModel
                {
                    MechanicId = m.MechanicId,
                    FirstName = m.FirstName,
                    MiddleName = m.MiddleName,
                    LastName = m.LastName,
                    QualificationName = m.Qualification.Name,
                    Experience = m.Experience
                })
                .Take(numberRows)
                .ToList();

            List<PaymentViewModel> payments = _db.Payments
                .OrderBy(d => d.PaymentId)
                .Select(p => new PaymentViewModel
                {
                    PaymentId = p.PaymentId,
                    CarVIN = p.Car.VIN,
                    Date = p.Date,
                    Cost = p.Cost,
                    MechanicFIO = p.Mechanic.FirstName + " " + p.Mechanic.MiddleName + " " + p.Mechanic.LastName,
                    ProgressReport = p.ProgressReport,
                })
                .Take(numberRows)
                .ToList();
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Cars = cars,
                Owners = owners,
                Mechanics = mechanics,
                Payments = payments
            };
            return View(homeViewModel);
        }

    }
}