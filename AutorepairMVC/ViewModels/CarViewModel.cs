using AutorepairMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutorepairMVC.ViewModels
{
    public class CarViewModel {
        public int CarId { get; set; }

        [Display(Name = "Марка автомобиля")]
        public string Brand { get; set; }

        [Display(Name = "Мощность")]
        public int Power { get; set; }

        [Display(Name = "Цвет")]
        public string Color { get; set; }

        [Display(Name = "Гос номер")]
        public string StateNumber { get; set; }

        [Display(Name = "ФИО владельца")]
        public string OwnerFIO { get; set; }

        [Display(Name = "Год выпуска авто")]
        public int Year { get; set; }

        [Display(Name = "ВИН номер")]
        public string VIN { get; set; }

        [Display(Name = "Номер двигателя")]
        public string EngineNumber { get; set; }

        [Display(Name = "Дата поступления")]
        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; }

        public Owner Owner { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
