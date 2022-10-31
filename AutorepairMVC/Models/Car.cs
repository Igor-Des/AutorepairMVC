using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AutorepairMVC.Models
{
    public class Car
    {
        [Key]
        [Display(Name = "Код автомобиля")]
        public int CarId { get; set; }

        [Display(Name = "Марка автомобиля")]
        public string Brand { get; set; }

        [Display(Name = "Мощность")]
        public int Power { get; set; }

        [Display(Name = "Цвет")]
        public string Color { get; set; }

        [Display(Name = "Гос номер")]
        public string StateNumber { get; set; }

        [Display(Name = "Код владельца авто")]
        public int OwnerId { get; set; }

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

        // ctor for DbInitializer(for future)
        public Car()
        {
            Payments = new List<Payment>();
        }

        public override string ToString()
        {
            return "CarId: " + CarId + " | Brand: " + Brand + " | Power: " + Power + " | Color: " + Color +
               " | StateNumber: " + StateNumber + " | OwnerId: " + OwnerId + " | Year: " + Year + " | VIN: " + VIN +
               " | EngineNumber: " + EngineNumber + " | AdmissionDate: " + AdmissionDate.ToShortDateString();
        }
    }
}
