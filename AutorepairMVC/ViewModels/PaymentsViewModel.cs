﻿using AutorepairMVC.Models;

namespace AutorepairMVC.ViewModels
{
    public class PaymentsViewModel
    {
        public IEnumerable<Payment> Payments { get; set; }

        //Свойство для фильтрации
        public PaymentViewModel PaymentViewModel { get; set; }
    }
}
