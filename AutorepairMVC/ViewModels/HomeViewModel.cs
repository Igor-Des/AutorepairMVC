using AutorepairMVC.Models;
using System.Threading.Tasks;

namespace AutorepairMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<MechanicViewModel> Mechanics { get; set; }
        public IEnumerable<CarViewModel> Cars { get; set; }
        public IEnumerable<Owner> Owners { get; set; }
        public IEnumerable<PaymentViewModel> Payments { get; set; }
    }
}
