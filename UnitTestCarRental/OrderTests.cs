using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental_Director.Model;
using System;

namespace UnitTestCarRental
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void EmptyOrderClientNull()
        {
            Order order = new Order();
            Assert.AreEqual(null, order.Client);
        }

        [TestMethod]
        public void EmptyOrderCarNull()
        {
            Order order = new Order();
            Assert.AreEqual(null, order.Car);
        }

        [TestMethod]
        public void EmptyOrderIssueDateNull()
        {
            Order order = new Order();
            DateTime dateTime = new DateTime();
            Assert.AreEqual(dateTime, order.IssueDate);
        }

        [TestMethod]
        public void EmptyOrderReturnDateNull()
        {
            Order order = new Order();
            DateTime dateTime = new DateTime();
            Assert.AreEqual(dateTime, order.ReturnDate);
        }

        [TestMethod]
        public void CorrectOrderEmptyClient()
        {
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.AreEqual(client, order.Client);
        }

        [TestMethod]
        public void CorrectOrderClient()
        {
            Client client = new Client("Surname", "Name", "SecondName", "DrivenLicense", "Address", "PhoneNumber");
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.AreEqual(client, order.Client);
        }

        [TestMethod]
        public void CorrectOrderEmptyCar()
        {
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.AreEqual(car, order.Car);
        }

        [TestMethod]
        public void CorrectOrderCar()
        {
            Client client = new Client();
            Car car = new Car("Brand", "Cost", "Type", "StateNumber", "Mileage", "ManufactureYear", "RentalPrice");
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.AreEqual(client, order.Client);
        }

        [TestMethod]
        public void CorrectOrderIssueDate()
        {
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.AreEqual(issueDate, order.IssueDate);
        }

        [TestMethod]
        public void CorrectOrderReturnDate()
        {
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.AreEqual(returnDate, order.ReturnDate);
        }

        [TestMethod]
        public void CorrectEmptyOrderCreation()
        {
            Order order = new Order();
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void CorrectOrderCreation()
        {
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void CorrectOrderValidation()
        {
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.IsTrue(order.IsValid());
        }

        [TestMethod]
        public void OrderClientIsNull()
        {
            Client client = null;
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        public void OrderCarIsNull()
        {
            Client client = new Client();
            Car car = null;
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        public void OrderIssueDateIsDefault()
        {
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = new DateTime();
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        public void OrderReturnDateIsDefault()
        {
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = new DateTime();
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        public void OrderIssueDateIsLaterThanReturnDate()
        {
            Client client = new Client();
            Car car = new Car();
            DateTime returnDate = DateTime.Now;
            DateTime issueDate = returnDate.AddDays(1);
            Order order = new Order(client, car, issueDate, returnDate);
            Assert.IsFalse(order.IsValid());
        }
    }
}