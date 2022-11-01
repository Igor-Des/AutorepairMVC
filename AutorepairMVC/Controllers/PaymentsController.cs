using Microsoft.AspNetCore.Mvc;

namespace AutorepairMVC.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
