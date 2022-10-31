using AutorepairMVC.ViewModels;

namespace AutorepairMVC.Services
{
    public interface IPaymentServices
    {
        HomeViewModel GetHomeViewModel(int numberRows = 10);
    }
}
