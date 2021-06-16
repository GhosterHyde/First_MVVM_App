using CarRental_Director.DataAccess;
using CarRental_Director.Model;
using CarRental_Director.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCarRental
{
    [TestClass]
    public class OrderViewModelTests
    {
        [TestMethod]
        public void CorrectClientsCollection()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order();
            OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, carRepository, mainWindowViewModel);
            Assert.IsNotNull(orderViewModel.Clients);
        }

        [TestMethod]
        public void CorrectCarsCollection()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order();
            OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, carRepository, mainWindowViewModel);
            Assert.IsNotNull(orderViewModel.Cars);
        }

        [TestMethod]
        public void CorrectClientWhileOrderCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, carRepository, mainWindowViewModel);
            Assert.AreEqual(client, orderViewModel.Client);
        }

        [TestMethod]
        public void CorrectCarWhileOrderCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, carRepository, mainWindowViewModel);
            Assert.AreEqual(car, orderViewModel.Car);
        }

        [TestMethod]
        public void CorrectIssueDateWhileOrderCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, carRepository, mainWindowViewModel);
            Assert.AreEqual(issueDate, orderViewModel.IssueDate);
        }

        [TestMethod]
        public void CorrectReturnDateWhileOrderCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Client client = new Client();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, car, issueDate, returnDate);
            OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, carRepository, mainWindowViewModel);
            Assert.AreEqual(returnDate, orderViewModel.ReturnDate);
        }

        [TestMethod]
        public void NullCarWhileOrderCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Client client = new Client();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(client, null, issueDate, returnDate);
            OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, carRepository, mainWindowViewModel);
            Assert.AreEqual(null, orderViewModel.Car);
        }

        [TestMethod]
        public void NullClientWhileOrderCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(null, car, issueDate, returnDate);
            OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, carRepository, mainWindowViewModel);
            Assert.AreEqual(null, orderViewModel.Client);
        }

        [TestMethod]
        public void CorrectOrderViewModelCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(null, car, issueDate, returnDate);
            OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, carRepository, mainWindowViewModel);
            Assert.IsNotNull(orderViewModel);
        }

        [TestMethod]
        public void NullMainWindowViewModelWhileCreation()
        {
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(null, car, issueDate, returnDate);
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, carRepository, null);
            });
        }

        [TestMethod]
        public void NullCarRepositoryWhileCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(null, car, issueDate, returnDate);
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, null, mainWindowViewModel);
            });
        }

        [TestMethod]
        public void NullClientRepositoryWhileCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            OrderRepository orderRepository = new OrderRepository();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(null, car, issueDate, returnDate);
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, null, carRepository, mainWindowViewModel);
            });
        }

        [TestMethod]
        public void NullOrderRepositoryWhileCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(null, car, issueDate, returnDate);
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                OrderViewModel orderViewModel = new OrderViewModel(order, null, clientRepository, carRepository, mainWindowViewModel);
            });
        }

        [TestMethod]
        public void NullOrderWhileCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                OrderViewModel orderViewModel = new OrderViewModel(null, orderRepository, clientRepository, carRepository, mainWindowViewModel);
            });
        }

        [TestMethod]
        public void CorrectOrderViewModelUpdate()
        {
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(null, car, issueDate, returnDate);
            OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, carRepository);
            Assert.IsNotNull(orderViewModel);
        }

        [TestMethod]
        public void NullCarRepositoryWhileUpdate()
        {
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(null, car, issueDate, returnDate);
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, clientRepository, null);
            });
        }

        [TestMethod]
        public void NullClientRepositoryWhileUpdate()
        {
            CarRepository carRepository = new CarRepository();
            OrderRepository orderRepository = new OrderRepository();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(null, car, issueDate, returnDate);
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                OrderViewModel orderViewModel = new OrderViewModel(order, orderRepository, null, carRepository);
            });
        }

        [TestMethod]
        public void NullOrderRepositoryWhileUpdate()
        {
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            Car car = new Car();
            DateTime issueDate = DateTime.Now;
            DateTime returnDate = DateTime.Now;
            Order order = new Order(null, car, issueDate, returnDate);
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                OrderViewModel orderViewModel = new OrderViewModel(order, null, clientRepository, carRepository);
            });
        }

        [TestMethod]
        public void NullOrderWhileUpdate()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            ClientRepository clientRepository = new ClientRepository();
            OrderRepository orderRepository = new OrderRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                OrderViewModel orderViewModel = new OrderViewModel(null, orderRepository, clientRepository, carRepository);
            });
        }
    }
}
