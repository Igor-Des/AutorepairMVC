using AutorepairMVC.Data;
using AutorepairMVC.Models;
using AutorepairMVC.ViewModels;

namespace AutorepairMVC.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly AutorepairContext _db;
        public PaymentServices(AutorepairContext context)
        {
            _db = context;
        }
        public HomeViewModel GetHomeViewModel(int numberRows = 10)
        {
            List<Car> cars = _db.Cars.Take(numberRows).ToList();
            List<Owner> owners = _db.Owners.Take(numberRows).ToList();
            List<Mechanic> mechanics = _db.Mechanics.Take(numberRows).ToList();

            List<PaymentViewModel> payments = _db.Payments
                .OrderByDescending(d => d.PaymentId)
                .Select(p => new PaymentViewModel
                {
                    PaymentId = p.PaymentId,
                    CarVIN = p.Car.VIN,
                    Date = p.Date,
                    Cost = p.Cost,
                    MechanicFIO = p.Mechanic.FirstName + " " + p.Mechanic.MiddleName,
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
            return homeViewModel;
        }
    }
}
