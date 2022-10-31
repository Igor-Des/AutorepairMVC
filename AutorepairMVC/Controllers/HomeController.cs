﻿using AutorepairMVC.Data;
using AutorepairMVC.Models;
using AutorepairMVC.ViewModels;
using AutorepairMVC.Infrastructure;
using AutorepairMVC.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AutorepairMVC.Controllers
{
    [ExceptionFilter]
    [TypeFilter(typeof(TimingLogAttribute))]
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
            return View(homeViewModel);
        }

    }
}