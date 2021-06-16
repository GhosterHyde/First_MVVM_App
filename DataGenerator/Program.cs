using DataGenerator.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataGenerator
{
    class Program
    {
        #region Constants

        const string phoneNumberStartRUS = "89";
        const int drivenLicenseDigitsCount = 9;
        const int phoneNumberLength = 11;
        const int englishAlphabetLength = 26;
        const int manufactureYearOfFirstCarInTheWorld = 1886;
        const int maxDaysForRent = 30;

        #endregion

        #region Files Inners

        static List<string> surnames = new List<string>();
        static List<string> firstNames = new List<string>();
        static List<string> secondNames = new List<string>();
        static List<string> carBrands = new List<string>();

        #endregion

        #region Collections Of Unique Fields

        static List<string> drivenLicenses = new List<string>();
        static List<string> stateNumbers = new List<string>();

        #endregion

        static Random random = new Random();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Удаление старых записей...");
                DeleteAllData();
                ReadData();
                GenerateAllData();
            }
            catch (Exception)
            {
                Console.WriteLine("Возникла непредвиденная ошибка!");
            }
        }

        #region Data Delition

        static void DeleteAllData()
        {
            DeleteOrders();
            DeleteClients();
            DeleteCars();
        }

        static void DeleteClients()
        {
            using (DataContext dataContext = new DataContext())
            {
                var allClients = dataContext.Clients;
                foreach (var client in allClients)
                {
                    dataContext.Clients.Remove(client);
                }
                dataContext.SaveChanges();
            }
        }

        static void DeleteCars()
        {
            using (DataContext dataContext = new DataContext())
            {
                var allCars = dataContext.Cars;
                foreach (var car in allCars)
                {
                    dataContext.Cars.Remove(car);
                }
                dataContext.SaveChanges();
            }
        }

        static void DeleteOrders()
        {
            using (DataContext dataContext = new DataContext())
            {
                var allOrders = dataContext.Orders;
                foreach (var order in allOrders)
                {
                    dataContext.Orders.Remove(order);
                }
                dataContext.SaveChanges();
            }
        }

        #endregion

        #region Data Generation

        static void GenerateAllData()
        {
            Console.WriteLine("Генерация клиентов...");
            GenerateClients();
            Console.WriteLine("Генерация автомобилей...");
            GenerateCars();
            Console.WriteLine("Генерация заказов...");
            GenerateOrders();
        }

        #region Clients Generation

        static void GenerateClients()
        {
            using (DataContext dataContext = new DataContext())
            {
                for (int i = 0; i < 1000; i++)
                {
                    Client client = GetClient();
                    dataContext.Clients.Add(client);
                }
                dataContext.SaveChanges();
            }
        }

        static Client GetClient()
        {
            Client client = new Client();
            client.Surname = surnames[random.Next(surnames.Count)];
            client.FirstName = firstNames[random.Next(firstNames.Count)];
            client.SecondName = secondNames[random.Next(secondNames.Count)];
            int minValue = (int)Math.Round(Math.Pow(10, drivenLicenseDigitsCount));
            string drivenLicense = random.Next(minValue, minValue * 10).ToString();
            while (drivenLicenses.Contains(drivenLicense))
            {
                drivenLicense = random.Next(minValue, minValue * 10).ToString();
            }
            drivenLicenses.Add(drivenLicense);
            client.DrivenLicense = drivenLicense;
            client.Address = "Some address";
            minValue = (int)Math.Round(Math.Pow(10, phoneNumberLength - phoneNumberStartRUS.Length));
            client.PhoneNumber = phoneNumberStartRUS + random.Next(minValue, minValue * 10).ToString();
            return client;
        }

        #endregion

        #region Cars Generation

        static void GenerateCars()
        {
            using (DataContext dataContext = new DataContext())
            {
                for (int i = 0; i < 1000; i++)
                {
                    Car car = GetCar();
                    dataContext.Cars.Add(car);
                }
                dataContext.SaveChanges();
            }
        }

        static Car GetCar()
        {
            Car car = new Car();
            car.Brand = carBrands[random.Next(carBrands.Count)] + " " + (char)('A' + random.Next(englishAlphabetLength)) + random.Next(100);
            car.Cost = random.Next((int)Math.Pow(10, 5), (int)Math.Pow(10, 7)).ToString();
            car.Type = "Automobile";
            string stateNumber = GenerateStateNumber();
            while (stateNumbers.Contains(stateNumber))
            {
                stateNumber = GenerateStateNumber();
            }
            stateNumbers.Add(stateNumber);
            car.StateNumber = stateNumber;
            car.Mileage = random.Next((int)Math.Pow(10, 6)).ToString();
            car.ManufactureYear = (manufactureYearOfFirstCarInTheWorld + random.Next(DateTime.Now.Year - manufactureYearOfFirstCarInTheWorld)).ToString();
            car.RentalPrice = random.Next((int)Math.Pow(10, 4), (int)Math.Pow(10, 5)).ToString();
            return car;
        }

        static string GenerateStateNumber()
        {
            string numberForStateNumber = random.Next(1000).ToString();
            while (numberForStateNumber.Length < 3)
            {
                numberForStateNumber = numberForStateNumber.Insert(0, "0");
            }
            return (char)('A' + random.Next(englishAlphabetLength)) + numberForStateNumber + (char)('A' + random.Next(englishAlphabetLength)) + (char)('A' + random.Next(englishAlphabetLength));
        }

        #endregion

        #region Order Generation

        static void GenerateOrders()
        {
            using (DataContext dataContext = new DataContext())
            {
                List<Client> clients = dataContext.Clients.ToList();
                List<Car> cars = dataContext.Cars.ToList();
                for (int i = 0; i < 1000; i++)
                {
                    Order order = GetOrder(clients, cars);
                    dataContext.Orders.Add(order);
                }
                dataContext.SaveChanges();
            }
        }

        static Order GetOrder(List<Client> clients, List<Car> cars)
        {
            Order order = new Order();
            Client client = clients[random.Next(clients.Count)];
            Car car = cars[random.Next(cars.Count)];
            order.Client_id = client.ID;
            order.Car_id = car.ID;
            int manufactureYear = Convert.ToInt32(car.ManufactureYear);
            DateTime issueDate = new DateTime();
            if (manufactureYear < 2010)
            {
                issueDate = new DateTime(2010, 1, 1);
                issueDate = issueDate.AddDays(random.Next((DateTime.Today - issueDate).Days));
            }
            else
            {
                issueDate = new DateTime(manufactureYear, 1, 1);
                issueDate = issueDate.AddDays(random.Next((DateTime.Today - issueDate).Days));
            }
            order.IssueDate = issueDate;
            order.ReturnDate = issueDate.AddDays(random.Next(maxDaysForRent));
            return order;
        }

        #endregion

        #endregion

        #region Private Helpers

        static void ReadData()
        {
            ReadFile(surnames, "Surnames.txt");
            ReadFile(firstNames, "FirstNames.txt");
            ReadFile(secondNames, "SecondNames.txt");
            ReadFile(carBrands, "CarBrands.txt");
        }

        static void ReadFile(List<string> collection, string fileName)
        {
            fileName = "..\\..\\..\\Data\\" + fileName;
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    collection.Add(line);
                }
            }
        }

        #endregion
    }
}