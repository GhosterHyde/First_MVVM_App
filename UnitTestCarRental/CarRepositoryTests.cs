using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental_Director.DataAccess;
using System.Collections.Generic;
using CarRental_Director.Model;
using System;

namespace UnitTestCarRental
{
    [TestClass]
    public class CarRepositoryTests
    {
        [TestMethod]
        public void NewCarCreation()
        {
            CarRepository carRepository = new CarRepository();
            List<Car> cars = carRepository.GetCars();
            Assert.IsNotNull(cars);
        }

        [TestMethod]
        public void NewEmptyCarAddedSuccessfully()
        {
            CarRepository carRepository = new CarRepository();
            List<Car> cars = carRepository.GetCars();
            int collectionSize = cars.Count;
            Car car = new Car();
            carRepository.AddCar(car);
            Assert.AreEqual(carRepository.GetCars().Count, collectionSize + 1);
        }

        [TestMethod]
        public void NewCarAddedSuccessfully()
        {
            CarRepository carRepository = new CarRepository();
            List<Car> cars = carRepository.GetCars();
            int collectionSize = cars.Count;
            Car car = new Car("Brand", "Price", "Type", "StateNumber", "Mileage", "ManufactureYear", "RentalPrice");
            carRepository.AddCar(car);
            Assert.AreEqual(carRepository.GetCars().Count, collectionSize + 1);
        }

        [TestMethod]
        public void TwiceAddingNewEmptyCar()
        {
            CarRepository carRepository = new CarRepository();
            List<Car> cars = carRepository.GetCars();
            int collectionSize = cars.Count;
            Car car = new Car();
            carRepository.AddCar(car);
            carRepository.AddCar(car);
            Assert.AreEqual(carRepository.GetCars().Count, collectionSize + 1);
        }

        [TestMethod]
        public void TwiceAddingNewCar()
        {
            CarRepository carRepository = new CarRepository();
            List<Car> cars = carRepository.GetCars();
            int collectionSize = cars.Count;
            Car car = new Car("Brand", "Price", "Type", "StateNumber", "Mileage", "ManufactureYear", "RentalPrice");
            carRepository.AddCar(car);
            carRepository.AddCar(car);
            Assert.AreEqual(carRepository.GetCars().Count, collectionSize + 1);
        }

        [TestMethod]
        public void NullCarException()
        {
            CarRepository carRepository = new CarRepository();
            Assert.ThrowsException<ArgumentNullException>(() => carRepository.AddCar(null));
        }

        [TestMethod]
        public void CorrectEmptyCarDelition()
        {
            CarRepository carRepository = new CarRepository();
            Car car = new Car();
            carRepository.AddCar(car);
            List<Car> cars = carRepository.GetCars();
            int collectionCount = cars.Count;
            carRepository.DeleteCar(car);
            cars = carRepository.GetCars();
            Assert.AreEqual(collectionCount - 1, cars.Count);
        }

        [TestMethod]
        public void CorrectCarDelition()
        {
            CarRepository carRepository = new CarRepository();
            Car car = new Car("Brand", "Price", "Type", "StateNumber", "Mileage", "ManufactureYear", "RentalPrice");
            carRepository.AddCar(car);
            List<Car> cars = carRepository.GetCars();
            int collectionCount = cars.Count;
            carRepository.DeleteCar(car);
            cars = carRepository.GetCars();
            Assert.AreEqual(collectionCount - 1, cars.Count);
        }

        [TestMethod]
        public void CorrectSameEmptyCarDelition()
        {
            CarRepository carRepository = new CarRepository();
            Car car = new Car();
            carRepository.AddCar(car);
            car = new Car();
            carRepository.AddCar(car);
            List<Car> cars = carRepository.GetCars();
            int collectionCount = cars.Count;
            carRepository.DeleteCar(car);
            cars = carRepository.GetCars();
            Assert.AreEqual(collectionCount - 1, cars.Count);
        }

        [TestMethod]
        public void CorrectSameCarDelition()
        {
            CarRepository carRepository = new CarRepository();
            Car car = new Car("Brand", "Price", "Type", "StateNumber", "Mileage", "ManufactureYear", "RentalPrice");
            carRepository.AddCar(car);
            car = new Car("Brand", "Price", "Type", "StateNumber", "Mileage", "ManufactureYear", "RentalPrice");
            carRepository.AddCar(car);
            List<Car> cars = carRepository.GetCars();
            int collectionCount = cars.Count;
            carRepository.DeleteCar(car);
            cars = carRepository.GetCars();
            Assert.AreEqual(collectionCount - 1, cars.Count);
        }

        [TestMethod]
        public void NullCarDelition()
        {
            CarRepository carRepository = new CarRepository();
            Assert.ThrowsException<ArgumentNullException>(() => carRepository.DeleteCar(null));
        }

        [TestMethod]
        public void MissingCarDelition()
        {
            CarRepository carRepository = new CarRepository();
            Car car = new Car("Brand", "Price", "Type", "StateNumber", "Mileage", "ManufactureYear", "RentalPrice");
            List<Car> cars = carRepository.GetCars();
            int collectionCount = cars.Count;
            carRepository.DeleteCar(car);
            cars = carRepository.GetCars();
            Assert.AreEqual(collectionCount, cars.Count);
        }

        [TestMethod]
        public void ContainsCarCorrectly()
        {
            CarRepository carRepository = new CarRepository();
            Car car = new Car("Brand", "Price", "Type", "StateNumber", "Mileage", "ManufactureYear", "RentalPrice");
            carRepository.AddCar(car);
            Assert.AreEqual(true, carRepository.ContainsCar(car));
        }

        [TestMethod]
        public void NotContainsCar()
        {
            CarRepository carRepository = new CarRepository();
            Car car = new Car("Brand", "Price", "Type", "StateNumber", "Mileage", "ManufactureYear", "RentalPrice");
            Assert.AreEqual(false, carRepository.ContainsCar(car));
        }

        [TestMethod]
        public void ContainsNullCar()
        {
            CarRepository carRepository = new CarRepository();
            Assert.ThrowsException<ArgumentNullException>(() => carRepository.ContainsCar(null));
        }

        [TestMethod]
        public void CorrectGettingListOfCars()
        {
            CarRepository carRepository = new CarRepository();
            Assert.AreEqual(true, carRepository.GetCars() is List<Car>);
        }
    }
}
