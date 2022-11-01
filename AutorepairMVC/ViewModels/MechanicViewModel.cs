using AutorepairMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AutorepairMVC.ViewModels
{
    public class MechanicViewModel
    {
        public int MechanicId { get; set; }

        [Display(Name = "Имя автомеханика")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия автомеханика")]
        public string MiddleName { get; set; }

        [Display(Name = "Отчество автомеханика")]
        public string LastName { get; set; }

        [Display(Name = "Должность")]
        public string QualificationName { get; set; }

        [Display(Name = "Стаж работы")]
        public int Experience { get; set; }

        public Qualification Qualification { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
