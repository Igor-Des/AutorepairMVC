using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutorepairMVC.Data;
using AutorepairMVC.Models;
using AutorepairMVC.Infrastructure;
using AutorepairMVC.Infrastructure.Filters;
using AutorepairMVC.ViewModels;

namespace AutorepairMVC.Controllers
{
    [TypeFilter(typeof(TimingLogAttribute))] // Фильтр ресурсов
    [ExceptionFilter] // Фильтр исключений
    public class PaymentsController : Controller
    {
        private readonly AutorepairContext _context;

        private readonly int pageSize = 10;
        private PaymentViewModel _payment = new PaymentViewModel
        {
            MechanicFIO = "",
            Cost = 0
        };

        public PaymentsController(AutorepairContext context)
        {
            _context = context;
        }

        // GET: Payments
        [SetToSession("SortState")]
        public async Task<IActionResult> Index(SortState sortOrder, int page = 1)
        {
            // Считывание данных из сессии
            var sessionPayment = HttpContext.Session.Get("Payment");
            var sessionSortState = HttpContext.Session.Get("SortState");

            if (sessionPayment != null)
                _payment = Transformations.DictionaryToObject<PaymentViewModel>(sessionPayment);
            if ((sessionSortState != null))
                if ((sessionSortState.Count > 0) & (sortOrder == SortState.No)) sortOrder = (SortState)Enum.Parse(typeof(SortState), sessionSortState["sortOrder"]);

            // Сортировка и фильтрация данных
            IQueryable<Operation> fuelsContext = _context.Operations;
            fuelsContext = Sort_Search(fuelsContext, sortOrder, _operation.TankType ?? "", _operation.FuelType ?? "");

            // Разбиение на страницы
            var count = fuelsContext.Count();
            fuelsContext = fuelsContext.Skip((page - 1) * pageSize).Take(pageSize);

            // Формирование модели для передачи представлению
            _operation.SortViewModel = new SortViewModel(sortOrder);
            OperationsViewModel operations = new OperationsViewModel
            {
                Operations = fuelsContext,
                PageViewModel = new PageViewModel(count, page, pageSize),
                OperationViewModel = _operation
            };
            return View(operations);

            //var autorepairContext = _context.Payments.Include(p => p.Car).Include(p => p.Mechanic);
            //return View(await autorepairContext.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Payments == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Car)
                .Include(p => p.Mechanic)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId");
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "MechanicId", "MechanicId");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,CarId,Date,Cost,MechanicId,ProgressReport")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", payment.CarId);
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "MechanicId", "MechanicId", payment.MechanicId);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Payments == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", payment.CarId);
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "MechanicId", "MechanicId", payment.MechanicId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,CarId,Date,Cost,MechanicId,ProgressReport")] Payment payment)
        {
            if (id != payment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", payment.CarId);
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "MechanicId", "MechanicId", payment.MechanicId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Payments == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Car)
                .Include(p => p.Mechanic)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Payments == null)
            {
                return Problem("Entity set 'AutorepairContext.Payments'  is null.");
            }
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
          return _context.Payments.Any(e => e.PaymentId == id);
        }
    }
}
