using CarRental_Director.DataAccess;
using CarRental_Director.Model;
using CarRental_Director.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCarRental
{
    [TestClass]
    public class CarViewModelTests
    {
        [TestMethod]
        public void CarWasCreatedSuccessfully()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(car, carViewModel.Car);
        }

        [TestMethod]
        public void CarWasUpdatedSuccessfully()
        {
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            CarViewModel carViewModel = new CarViewModel(car, carRepository);
            Assert.AreEqual(car, carViewModel.Car);
        }

        [TestMethod]
        public void ParrentWasCreatedSuccessfully()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(mainWindowViewModel, carViewModel.Parrent);
        }

        [TestMethod]
        public void TestForBrandForCar()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(brand, carViewModel.Brand);
        }

        [TestMethod]
        public void TestForCostForCar()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(cost, carViewModel.Cost);
        }

        [TestMethod]
        public void TestForTypeForCar()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(type, carViewModel.Type);
        }

        [TestMethod]
        public void TestForStateNumberForCar()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(stateNumber, carViewModel.StateNumber);
        }

        [TestMethod]
        public void TestForMileageForCar()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(mileage, carViewModel.Mileage);
        }

        [TestMethod]
        public void TestForManufactureYearForCar()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(manufactureYear, carViewModel.ManufactureYear);
        }

        [TestMethod]
        public void TestForRentalPriceForCar()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(rentalPrice, carViewModel.RentalPrice);
        }

        [TestMethod]
        public void TestForEmptyBrandCar()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(null, carViewModel.Brand);
        }

        [TestMethod]
        public void TestForEmptyCostCar()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(null, carViewModel.Cost);
        }

        [TestMethod]
        public void TestForEmptyTypeCar()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(null, carViewModel.Type);
        }

        [TestMethod]
        public void TestForEmptyStateNumberCar()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(null, carViewModel.StateNumber);
        }

        [TestMethod]
        public void TestForEmptyMileageCar()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(null, carViewModel.Mileage);
        }

        [TestMethod]
        public void TestForEmptyManufactureYearCar()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(null, carViewModel.ManufactureYear);
        }

        [TestMethod]
        public void TestForEmptyRentalPriceCar()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            carRepository.AddCar(car);
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.AreEqual(null, carViewModel.RentalPrice);
        }

        [TestMethod]
        public void TestForClearNewMainWindowViewModelCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            CarViewModel carViewModel = new CarViewModel(car, carRepository, mainWindowViewModel);
            Assert.IsNotNull(carViewModel);
        }

        [TestMethod]
        public void TestForMWVMNullNewMainWindowViewModelCreation()
        {
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                CarViewModel carViewModel = new CarViewModel(car, carRepository, null);
            });
        }

        [TestMethod]
        public void TestForCarNullNewMainWindowViewModelCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                CarViewModel carViewModel = new CarViewModel(null, carRepository, mainWindowViewModel);
            });
        }

        [TestMethod]
        public void TestForCarRepositoryNullNewMainWindowViewModelCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Car car = new Car();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                CarViewModel carViewModel = new CarViewModel(car, null, mainWindowViewModel);
            });
        }

        [TestMethod]
        public void TestForClearMainWindowViewModelCreation()
        {
            Car car = new Car();
            CarRepository carRepository = new CarRepository();
            CarViewModel carViewModel = new CarViewModel(car, carRepository);
            Assert.AreEqual(car, carViewModel.Car);
        }

        [TestMethod]
        public void TestForCarNullMainWindowViewModelCreation()
        {
            CarRepository carRepository = new CarRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                CarViewModel carViewModel = new CarViewModel(null, carRepository);
            });
        }

        [TestMethod]
        public void TestForCarRepositoryNewMainWindowViewModelCreation()
        {
            Car car = new Car();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                CarViewModel carViewModel = new CarViewModel(car, null);
            });
        }
    }
}
