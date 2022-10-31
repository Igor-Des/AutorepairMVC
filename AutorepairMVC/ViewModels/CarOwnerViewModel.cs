using AutorepairMVC.Models;

namespace AutorepairMVC.ViewModels
{
    public class CarOwnerViewModel
    {
        public IEnumerable<CarViewModel> Cars { get; set; }
        public IEnumerable<Owner> Owners { get; set; }
    }
}
