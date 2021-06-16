using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental_Director.DataAccess;
using CarRental_Director.ViewModel;
using System;

namespace UnitTestOrderRental
{
    [TestClass]
    public class AllOrdersViewModelTests
    {
        [TestMethod]
        public void AllOrdersCollectionCreated()
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            OrderRepository orderRepository = new OrderRepository();
            ClientRepository clientRepository = new ClientRepository();
            CarRepository carRepository = new CarRepository();
            AllOrdersViewModel allOrdersViewModel = new AllOrdersViewModel(orderRepository, clientRepository, carRepository, mainWindow);
            Assert.IsNotNull(allOrdersViewModel.AllOrders);
        }

        [TestMethod]
        public void NullOrderRepositoryAllOrdersViewModel()
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            OrderRepository orderRepository = null;
            ClientRepository clientRepository = new ClientRepository();
            CarRepository carRepository = new CarRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                AllOrdersViewModel allOrdersViewModel = new AllOrdersViewModel(orderRepository, clientRepository, carRepository, mainWindow);
            });
        }

        [TestMethod]
        public void NullMainWindowAllOrdersViewModel()
        {
            MainWindowViewModel mainWindow = null;
            OrderRepository orderRepository = new OrderRepository();
            ClientRepository clientRepository = new ClientRepository();
            CarRepository carRepository = new CarRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                AllOrdersViewModel allOrdersViewModel = new AllOrdersViewModel(orderRepository, clientRepository, carRepository, mainWindow);
            });
        }

        [TestMethod]
        public void NullClientRepositoryAllOrdersViewModel()
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            OrderRepository orderRepository = new OrderRepository();
            ClientRepository clientRepository = null;
            CarRepository carRepository = new CarRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                AllOrdersViewModel allOrdersViewModel = new AllOrdersViewModel(orderRepository, clientRepository, carRepository, mainWindow);
            });
        }

        [TestMethod]
        public void NullCarRepositoryAllOrdersViewModel()
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            OrderRepository orderRepository = new OrderRepository();
            ClientRepository clientRepository = new ClientRepository();
            CarRepository carRepository = null;
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                AllOrdersViewModel allOrdersViewModel = new AllOrdersViewModel(orderRepository, clientRepository, carRepository, mainWindow);
            });
        }

        [TestMethod]
        public void CollectionCorrectAllOrdersVM()
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            OrderRepository orderRepository = new OrderRepository();
            ClientRepository clientRepository = new ClientRepository();
            CarRepository carRepository = new CarRepository();
            AllOrdersViewModel allOrdersViewModel = new AllOrdersViewModel(orderRepository, clientRepository, carRepository, mainWindow);
            Assert.AreEqual(orderRepository.GetOrders().Count, allOrdersViewModel.AllOrders.Count);
        }
    }
}