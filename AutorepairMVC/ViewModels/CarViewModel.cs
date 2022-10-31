using AutorepairMVC.Models;
using System.Threading.Tasks;

namespace AutorepairMVC.ViewModels
{
    public class CarViewModel {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Owner> Owners { get; set; }
    }
}
