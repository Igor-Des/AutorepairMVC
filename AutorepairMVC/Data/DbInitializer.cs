using AutorepairMVC.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AutorepairMVC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AutorepairContext db)
        {
            db.Database.EnsureCreated();

            // Проверка занесены ли виды топлива
            if (db.Owners.Any())
            {
                return;   // База данных инициализирована
            }

            int mechanicNumber = 500;
            int ownerNumber = 1000;
            int carNumber = 5000;
            int paymentNumber = 6000;
            int qualificationNumber = 6;
            Random randObj = new Random(1);
                        
            string[] qualificationNames = { "1 рарзяд", "2 рарзяд", "3 рарзяд", "4 рарзяд", "5 рарзяд", "6 рарзяд" };
            string[] middleNames = { "Панов","Зайцев","Гордеев","Орехов","Назаров","Тихомиров","Вдовин","Давыдов","Кондратьев",
                "Губанов","Ларионов","Беляев","Леонтьев","Михайлов","Ковалев","Марков","Тихонов","Прохоров","Соловьев","Кузнецов",
                "Винокуров","Власов","Наумов","Матвеев","Афанасьев","Курочкин","Максимов","Романов","Павлов","Осипов","Сазонов",
                "Кузьмин","Колпаков","Тихонов","Данилов","Быков","Константинов","Кошелев","Наумов","Калачев","Касаткин","Семенов",
                "Смирнов","Иванов","Кузнецов","Поляков","Борисов","Орлов","Васильев","Родионов" };
            string[] firstNames = { "Александр", "Борис", "Филипп", "Тимур", "Владислав", "Роман", "Арсений", "Александр", "Георгий",
                "Ярослав", "Юрий", "Александр", "Максим", "Дмитрий", "Давид", "Егор", "Даниил", "Николай", "Арсений", "Юрий", "Егор",
                "Владимир", "Никита", "Леон", "Николай", "Константин", "Михаил", "Дмитрий", "Мирон", "Игорь", "Даниил", "Матвей", "Артём",
                "Денис", "Савва", "Артемий", "Владимир", "Марк", "Адам", "Тимофей", "Виктор", "Артём", "Даниил", "Ярослав", "Александр",
                "Константин", "Николай", "Павел", "Сергей" };
            string[] lastNames = { "Миронович", "Сергеевич", "Юрьевич", "Тимофеевич", "Владимирович", "Никитич", "Владимирович", "Давидович",
                "Михайлович", "Андреевич", "Максимович", "Александрович", "Дмитриевич", "Артёмович", "Тимофеевич", "Матвеевич", "Алексеевич",
                "Александрович", "Тимофеевич", "Николаевич", "Александрович", "Артёмович", "Дмитриевич", "Богданович", "Арсентьевич", "Макарович",
                "Германович", "Степанович", "Константинович", "Максимович", "Александрович", "Егорович", "Андреевич", "Даниилович", "Ярославович",
                "Дмитриевич", "Станиславович", "Иванович", "Сергеевич", "Тимофеевич", "Александрович", "Сергеевич", "Фёдорович", "Михайлович",
                "Фёдорович", "Алексеевич", "Михайлович", "Тимурович", "Тимофеевич", "Глебович" };
            string[] address = { "New Igloo, Maryland St. ", "Ocean Roar, Illinois St. ", "Glen, Toadtown, Maryland St. ", "Autoroute, Duckabush, California St. ",
                "Hamma Hamma, Mississippi St. ", "Burnt Water, Washington St. ", "of Columbia St. ", "Hill, California St. ", "Hog Jaw, Georgia St. ",
                "New Brunswick St. ", "Drive, Chittyville, Hawaii St. ", "Port, Tuggleville, Minnesota St. ", "Knoll, Naytahwaush, Hawaii St. ",
                "Lookout, Compromise, Kansas St. ", "Free Run, Illinois St. ", "Little Yazoo, Pennsylvania St. ", "February, North Carolina St. ",
                "Fudgearound, South Carolina St. ", "Lick Skillet, Michigan St. ", "Static, Rhode Island St. ", "Pumpkin, New Brunswick St. ", "Green, Bissell, California St. ",
                "Cocked Hat, California St. ", "Parkway, Okawahathako, Hawaii St. ", "Pirate Harbor, Pennsylvania St. ", "Britsh Columbia St. ",
                "Square, Jimps, Georgia St. ", "Court, Pocataligo, Georgia St. ", "Bald Head, California St. " };
            string[] carBrands = { "Acura", "AlfaRomeo", "AstonMartin", "Audi", "Bentley", "BMW", "Cadillac",
                "Chery", "Chevrolet", "Chrysler", "Citroen", "Dacia", "Daewoo", "Datsun", "Dodge", "FAW", "Ferrarri",
                "Fiat", "Ford", "GAC", "Geely", "Genesis", "GMC", "Haval", "Honda", "Hummer", "Hyundai", "Infiniti",
                "Jaguar", "Jeep", "Kia", "Lada", "LandRover", "Lexus", "Lifan", "Lincoln", "Maserati", "Mazda", "MercedsBenz",
                "Mitsubishi", "Nissan", "Opel", "Peugeot", "Porsche", "Renault", "Rover", "SEAT", "Skoda", "Smart", "Subaru",
                "Suzuki", "Tesla", "Toyota", "Volkswagen", "Volvo" };
            string[] colors = { "Черный", "Белый", "Синий", "Зеленый", "Красный", "Желтый", "Фиолетовый" };
            string[] carProgress = { "Ремонтподвески","АвтоЭлектрика","Кузовной ремонт","Ремонт двигателя","Развал схождение","Ремонт КПП",
                "Ремонт топливной","Рулевое управление","Замена ГРМ","Тормозная система","Диагностика автомобилей","Замена автостекла","Замена масла",
                "Компьютерная диагностика","Шиномонтаж","Автомойка","Полировка","Тюнинг","Ремонт АКПП","Ремонт турбин","Ремонт рулевой рейки","Ремонт глушителей",
                "Ремонт суппортов","замена сцепления","Ремонт задней балки","Антикоррозийная обработка","Ремонт карданных валов","Регулировка света фар",
                "Беспокрасочное удаление вмятин","Ремонт радиаторов","Ремонт гидроусилителей","Аудио, сигнализации","Газовое оборудование","Шины продажа",
                "Масло продажа","Ремонт печек","замена глушителя","Ремонт дворников","Ремонт полуприцепов","установка ксенона, парктроника","Ремонт фар",
                "Установка фаркопа","Замена сажевого фильтра" };
            string[] charStateNumber = { "A", "B", "E", "I", "K", "M", "H", "O", "P", "C", "T", "X" };
            string randCharForVIN = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";


            int count_charStateNumber = charStateNumber.GetLength(0);
            int count_qualificationName = qualificationNames.GetLength(0);
            int count_middleNames = middleNames.GetLength(0);
            int count_firstNames = firstNames.GetLength(0);
            int count_lastNames = lastNames.GetLength(0);
            int count_address = address.GetLength(0);
            int count_carBrands = carBrands.GetLength(0);
            int count_colors = colors.GetLength(0);
            int count_carProgress = carProgress.GetLength(0);

            string qualificationName;
            // заполняем таблицу квалификация(должностей) для механиков
            for (int qualificationsId = 1; qualificationsId <= qualificationNumber; qualificationsId++)
            {
                qualificationName = qualificationNames[qualificationsId];
                db.Qualifications.Add(new Qualification { QualificationId = qualificationsId, Name = qualificationName } );
            }

            db.SaveChanges();

            string firstName;
            string middleName;
            string lastName;
            int qualificationId;
            int experience;
            // заполняем таблицу механики
            for (int mechanicId = 1; mechanicId <= mechanicNumber; mechanicId++)
            {
                firstName = firstNames[randObj.Next(count_firstNames)];
                middleName = middleNames[randObj.Next(count_middleNames)];
                lastName = lastNames[randObj.Next(count_lastNames)];
                qualificationId = randObj.Next(1, qualificationNames.GetLength(0));
                experience = randObj.Next(1, 20);
                db.Mechanics.Add(new Mechanic
                {
                    MechanicId = mechanicId,
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    QualificationId = qualificationId,
                    Experience = experience
                });
            }

            db.SaveChanges();
            string addressOwner;
            int driveLic;
            int phone;
            // заполняем таблицу владельцы автомобилей
            for (int ownerId = 1; ownerId <= ownerNumber; ownerId++)
            {
                firstName = firstNames[randObj.Next(count_firstNames)];
                middleName = middleNames[randObj.Next(count_middleNames)];
                lastName = lastNames[randObj.Next(count_lastNames)];
                addressOwner = address[randObj.Next(count_address)];
                driveLic = randObj.Next(1000, 9999);
                phone = randObj.Next(1111111, 9999999); // 111-11-11 to 999-99-99

                db.Owners.Add(new Owner
                {
                    OwnerId = ownerId,
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    DriverLicenseNumber = driveLic,
                    Address = addressOwner,
                    Phone = phone
                });
            }

            db.SaveChanges();


            string brand;
            int power;
            string color;
            string stateNumber;
            int ownerIdRand;
            int year;
            string VIN = "";
            string engineNumber = "";
            string admissionDate;
            // заполняем таблицу автомобилей
            for (int carId = 1; carId <= carNumber; carId++)
            {
                brand = carBrands[randObj.Next(count_carBrands)];
                power = randObj.Next(150, 600);
                color = colors[randObj.Next(count_colors)];
                stateNumber = randObj.Next(1990, 2022).ToString() + " " +
                    charStateNumber[randObj.Next(count_charStateNumber)] + charStateNumber[randObj.Next(count_charStateNumber)] +
                    "-" + randObj.Next(1, 7).ToString(); // for example: 3425 AE-7 or 4568 MH-9
                ownerIdRand = randObj.Next(1, ownerNumber);
                year = randObj.Next(1990, 2022);
                for (int i = 0; i < randCharForVIN.Length; i++)
                {
                    VIN += randCharForVIN[randObj.Next(randCharForVIN.Length)];
                    engineNumber += randCharForVIN[randObj.Next(randCharForVIN.Length)];
                }
                admissionDate = randObj.Next(1, 28).ToString() + "." + randObj.Next(1, 12).ToString() + "." + randObj.Next(2018, 2022).ToString(); // dd.mm.yy
                phone = randObj.Next(1111111, 9999999); // 111-11-11 to 999-99-99

                db.Cars.Add(new Car
                {
                    CarId = carId,
                    Brand = brand,
                    Power = power,
                    Color = color,
                    StateNumber = stateNumber,
                    OwnerId = ownerIdRand,
                    Year = year,
                    VIN = VIN,
                    EngineNumber = engineNumber,
                    AdmissionDate = DateTime.Parse(admissionDate)
                });
            }

            db.SaveChanges();


            int carIdRand;
            string date;
            int cost;
            int mechanicIdRand;
            string progressRep;
            // заполняем таблицу платежей
            for (int paymentId = 1; paymentId <= paymentNumber; paymentId++)
            {
                carIdRand = randObj.Next(1, carNumber);
                date = randObj.Next(1, 28).ToString() + "." + randObj.Next(1, 12).ToString() + "." + randObj.Next(2020, 2022).ToString(); // dd.mm.yy
                cost = randObj.Next(100, 400);
                mechanicIdRand = randObj.Next(1, mechanicNumber);
                progressRep = carProgress[randObj.Next(count_carProgress)];
                db.Payments.Add(new Payment
                {
                    PaymentId = paymentId,
                    CarId = carIdRand,
                    Date = DateTime.Parse(date),
                    Cost = cost,
                    MechanicId = mechanicIdRand,
                    ProgressReport = progressRep
                });
            }

            db.SaveChanges();
        }
    }
}
