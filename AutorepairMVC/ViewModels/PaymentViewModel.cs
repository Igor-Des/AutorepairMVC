using System;
using System.ComponentModel.DataAnnotations;
using AutorepairMVC.Models;

namespace AutorepairMVC.ViewModels
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }

        [Display(Name = "ВИН авто")]
        public string CarVIN { get; set; }

        [Display(Name = "Дата платежа")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Цена")]
        public int Cost { get; set; }

        [Display(Name = "Механик")]
        public string MechanicFIO { get; set; }

        [Display(Name = "Выполненная работа")]
        public string ProgressReport { get; set; }
    }
}
