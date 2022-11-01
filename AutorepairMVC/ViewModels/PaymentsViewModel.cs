using AutorepairMVC.Models;

namespace AutorepairMVC.ViewModels
{
    public class PaymentsViewModel
    {
        public IEnumerable<PaymentViewModel> Payments { get; set; }
    }
}
