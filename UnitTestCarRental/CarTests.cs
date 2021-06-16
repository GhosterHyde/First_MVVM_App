using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental_Director.Model;
using System;

namespace UnitTestCarRental
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void EmptyCarsBrandNull()
        {
            Car car = new Car();
            Assert.AreEqual(null, car.Brand);
        }

        [TestMethod]
        public void EmptyCarsCostNull()
        {
            Car car = new Car();
            Assert.AreEqual(null, car.Cost);
        }

        [TestMethod]
        public void EmptyCarsTypeNull()
        {
            Car car = new Car();
            Assert.AreEqual(null, car.Type);
        }

        [TestMethod]
        public void EmptyCarsStateNumberNull()
        {
            Car car = new Car();
            Assert.AreEqual(null, car.StateNumber);
        }

        [TestMethod]
        public void EmptyCarsMileAgeNull()
        {
            Car car = new Car();
            Assert.AreEqual(null, car.Mileage);
        }

        [TestMethod]
        public void EmptyCarsManufactureYearNull()
        {
            Car car = new Car();
            Assert.AreEqual(null, car.ManufactureYear);
        }

        [TestMethod]
        public void EmptyCarsRentalPriceNull()
        {
            Car car = new Car();
            Assert.AreEqual(null, car.RentalPrice);
        }

        [TestMethod]
        public void CarsBrandCorrect()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.AreEqual(brand, car.Brand);
        }

        [TestMethod]
        public void CarsCostCorrect()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.AreEqual(cost, car.Cost);
        }

        [TestMethod]
        public void CarsTypeCorrect()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.AreEqual(type, car.Type);
        }

        [TestMethod]
        public void CarsStateNumberCorrect()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.AreEqual(stateNumber, car.StateNumber);
        }

        [TestMethod]
        public void CarsMileageCorrect()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.AreEqual(mileage, car.Mileage);
        }

        [TestMethod]
        public void CarsManufactureYearCorrect()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.AreEqual(manufactureYear, car.ManufactureYear);
        }

        [TestMethod]
        public void CarsRentalPriceCorrect()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.AreEqual(rentalPrice, car.RentalPrice);
        }

        [TestMethod]
        public void CorrectEmptyCarCreation()
        {
            Car car = new Car();
            Assert.IsNotNull(car);
        }

        [TestMethod]
        public void CorrectCarCreation()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "RentalPrice";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsNotNull(car);
        }

        [TestMethod]
        public void IsNotValidEmptyCar()
        {
            Car car = new Car();
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsValidCorrectCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsTrue(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrectBrandCar()
        {
            string brand = "";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidEmptyCostCar()
        {
            string brand = "Audi";
            string cost = "";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrectCostCar()
        {
            string brand = "Audi";
            string cost = "IncorrectCost";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidNegativeCostCar()
        {
            string brand = "Audi";
            string cost = "-1";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidEmptyTypeCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidEmptyStateNumberCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "";
            string mileage = "100000";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrectStateNumberCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "IncorrectStateNumber";
            string mileage = "100000";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidEmptyMileageCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrectMileageCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "IncorrectMileage";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidNegativeMileageCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "-1";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidTooMuchMileageCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "10000000";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidEmptyManufactureYearCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrectManufactureYearCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "IncorrectYear";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidTooLowManufactureYearCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "1885";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidTooMuchManufactureYearCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = (DateTime.Now.Year + 1).ToString();
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidEmptyRentalPriceCar()
        {
            string brand = "Brand";
            string cost = "Cost";
            string type = "Type";
            string stateNumber = "StateNumber";
            string mileage = "Mileage";
            string manufactureYear = "ManufactureYear";
            string rentalPrice = "";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrectRentalPriceCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "2020";
            string rentalPrice = "IncorrectRentalPrice";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void IsNotValidNegativeRentalPriceCar()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "2020";
            string rentalPrice = "-1";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            Assert.IsFalse(car.IsValid());
        }

        [TestMethod]
        public void CoorectToStringCarConvert()
        {
            string brand = "Audi";
            string cost = "100000";
            string type = "Auto";
            string stateNumber = "G100GG";
            string mileage = "100000";
            string manufactureYear = "2020";
            string rentalPrice = "5000";
            Car car = new Car(brand, cost, type, stateNumber, mileage, manufactureYear, rentalPrice);
            string expects = brand + " : "+stateNumber;
            Assert.AreEqual(expects, car.ToString());
        }

        [TestMethod]
        public void CarWithNullDataToStringConverter()
        {
            Car car = new Car();
            string actual = car.ToString();
            Assert.AreEqual(" : ", car.ToString());
        }
    }
}