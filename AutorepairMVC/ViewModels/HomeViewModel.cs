using AutorepairMVC.Models;
using System.Threading.Tasks;

namespace AutorepairMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Mechanic> Mechanics { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Car> Owners { get; set; }
        public IEnumerable<PaymentViewModel> Payments { get; set; }
    }
}
