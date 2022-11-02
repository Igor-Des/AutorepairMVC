using AutorepairMVC.Data;
using AutorepairMVC.Models;
using AutorepairMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutorepairMVC.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly AutorepairContext _context;

        public PaymentsController(AutorepairContext context)
        {
            _context = context;
        }

        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 258)]
        public IActionResult Index(SortState sortOrder, string currentFilter, string searchCarVIN, string searchProgressReport)
        {
            int numberRows = 300;
            if (searchCarVIN == null && searchProgressReport == null)
            {
                searchCarVIN = currentFilter;
                searchProgressReport = currentFilter;
            }

            ViewBag.SearchCarVIN = searchCarVIN;
            ViewBag.SearchProgressReport = searchProgressReport;

            IQueryable<PaymentViewModel> payments = from p in _context.Payments
                                                    join c in _context.Cars
                                                    on p.CarId equals c.CarId
                                                    join m in _context.Mechanics
                                                    on p.MechanicId equals m.MechanicId
                                                    orderby p.PaymentId
                                                    where p.PaymentId < numberRows
                                                    select new PaymentViewModel
                                                    {
                                                        PaymentId = p.PaymentId,
                                                        CarVIN = c.VIN,
                                                        Date = p.Date,
                                                        Cost = p.Cost,
                                                        MechanicFIO = m.FirstName + " " + m.MiddleName + " " + m.LastName,
                                                        ProgressReport = p.ProgressReport,
                                                    };

            payments = Search(payments, sortOrder, searchCarVIN, searchProgressReport);

            PaymentsViewModel paymentViewModel = new PaymentsViewModel
            {
                Payments = payments
            };
            return View(paymentViewModel);
        }


        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 258)]
        private IQueryable<PaymentViewModel> Search(IQueryable<PaymentViewModel> payments, SortState sortOrder, string searchCarVIN, string searchProgressReport)
        {
            if (!String.IsNullOrEmpty(searchCarVIN) && !String.IsNullOrEmpty(searchProgressReport))
            {
                payments = payments.Where(p => p.CarVIN.Contains(searchCarVIN) & p.ProgressReport.Contains(searchProgressReport));
            }
            else if (!String.IsNullOrEmpty(searchCarVIN) && String.IsNullOrEmpty(searchProgressReport))
            {
                payments = payments.Where(p => p.CarVIN.Contains(searchCarVIN));
            }
            else if (String.IsNullOrEmpty(searchCarVIN) && !String.IsNullOrEmpty(searchProgressReport))
            {
                payments = payments.Where(p => p.ProgressReport.Contains(searchProgressReport));
            }
            else
            {
                payments = payments.OrderBy(p => p.PaymentId);
            }

            ViewData["PaymentId"] = sortOrder == SortState.PaymentIdAsc ? SortState.PaymentIdDesc : SortState.PaymentIdAsc;
            ViewData["MechanicFIO"] = sortOrder == SortState.MechanicTypeAsc ? SortState.MechanicTypeDesc : SortState.MechanicTypeAsc;
            ViewData["Cost"] = sortOrder == SortState.CostTypeAsc ? SortState.CostTypeDesc : SortState.CostTypeAsc;
            ViewData["ReportProgress"] = sortOrder == SortState.ReportProgressAsc ? SortState.ReportProgressDesc : SortState.ReportProgressAsc;
            payments = sortOrder switch
            {
                SortState.PaymentIdAsc => payments.OrderBy(p => p.PaymentId),
                SortState.PaymentIdDesc => payments.OrderByDescending(p => p.PaymentId),
                SortState.MechanicTypeAsc => payments.OrderBy(p => p.MechanicFIO),
                SortState.MechanicTypeDesc => payments.OrderByDescending(p => p.MechanicFIO),
                SortState.CostTypeAsc => payments.OrderBy(p => p.Cost),
                SortState.CostTypeDesc => payments.OrderByDescending(p => p.Cost),
                SortState.ReportProgressAsc => payments.OrderBy(p => p.ProgressReport),
                SortState.ReportProgressDesc => payments.OrderByDescending(p => p.ProgressReport),
                _ => payments.OrderBy(p => p.PaymentId),
            };
            return payments;
        }
    }
}
