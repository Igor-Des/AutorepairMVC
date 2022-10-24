using System;
using System.ComponentModel.DataAnnotations;


namespace AutorepairMVC.ViewModels
{
    public class PaymentViewModel
    {

        public int PaymentId { get; set; }

        [Display(Name = "Код машины")]
        public int CarId { get; set; }

        [Display(Name = "Дата платежа")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Цена")]
        public int Cost { get; set; }

        [Display(Name = "Код механика")]
        public int MechanicId { get; set; }

        [Display(Name = "Выполненная работа")]
        public string ProgressReport { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
