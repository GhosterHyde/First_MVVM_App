using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental_Director.DataAccess;
using System.Collections.Generic;
using CarRental_Director.Model;
using System;

namespace UnitTestCarRental
{
    [TestClass]
    public class OrderRepositoryTests
    {
        [TestMethod]
        public void NewOrderCreation()
        {
            OrderRepository orderRepository = new OrderRepository();
            Assert.IsNotNull(orderRepository);
        }

        [TestMethod]
        public void LoadingOrders()
        {
            OrderRepository orderRepository = new OrderRepository();
            List<Order> orders = orderRepository.GetOrders();
            Assert.IsNotNull(orders);
        }

        [TestMethod]
        public void AddingOrderCorrectly()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order(new Client(), new Car(), DateTime.Now, DateTime.Now);
            List<Order> orders = orderRepository.GetOrders();
            int collectionCount = orders.Count;
            orderRepository.AddOrder(order);
            orders = orderRepository.GetOrders();
            Assert.AreEqual(collectionCount + 1, orders.Count);
        }

        [TestMethod]
        public void AddingEmptyOrderCorrectly()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order();
            List<Order> orders = orderRepository.GetOrders();
            int collectionCount = orders.Count;
            orderRepository.AddOrder(order);
            orders = orderRepository.GetOrders();
            Assert.AreEqual(collectionCount + 1, orders.Count);
        }

        [TestMethod]
        public void TwiceAddingOrder()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order(new Client(), new Car(), DateTime.Now, DateTime.Now);
            List<Order> orders = orderRepository.GetOrders();
            int collectionCount = orders.Count;
            orderRepository.AddOrder(order);
            orderRepository.AddOrder(order);
            orders = orderRepository.GetOrders();
            Assert.AreEqual(collectionCount + 1, orders.Count);
        }

        [TestMethod]
        public void TwiceAddingEmptyOrder()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order();
            List<Order> orders = orderRepository.GetOrders();
            int collectionCount = orders.Count;
            orderRepository.AddOrder(order);
            orderRepository.AddOrder(order);
            orders = orderRepository.GetOrders();
            Assert.AreEqual(collectionCount + 1, orders.Count);
        }

        [TestMethod]
        public void NullOrderAdding()
        {
            OrderRepository orderRepository = new OrderRepository();
            List<Order> orders = orderRepository.GetOrders();
            int collectionCount = orders.Count;
            Assert.ThrowsException<ArgumentNullException>(() => orderRepository.AddOrder(null));
        }

        [TestMethod]
        public void CorrectOrderDelition()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order(new Client(), new Car(), DateTime.Now, DateTime.Now);
            orderRepository.AddOrder(order);
            List<Order> orders = orderRepository.GetOrders();
            int collectionCount = orders.Count;
            orderRepository.DeleteOrder(order);
            orders = orderRepository.GetOrders();
            Assert.AreEqual(collectionCount - 1, orders.Count);
        }

        [TestMethod]
        public void CorrectOrderEmptyDelition()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order();
            orderRepository.AddOrder(order);
            List<Order> orders = orderRepository.GetOrders();
            int collectionCount = orders.Count;
            orderRepository.DeleteOrder(order);
            orders = orderRepository.GetOrders();
            Assert.AreEqual(collectionCount - 1, orders.Count);
        }

        [TestMethod]
        public void MissingOrderDelition()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order();
            List<Order> orders = orderRepository.GetOrders();
            int collectionCount = orders.Count;
            orderRepository.DeleteOrder(order);
            orders = orderRepository.GetOrders();
            Assert.AreEqual(collectionCount, orders.Count);
        }

        [TestMethod]
        public void NullOrderDelition()
        {
            OrderRepository orderRepository = new OrderRepository();
            Assert.ThrowsException<ArgumentNullException>(() => orderRepository.DeleteOrder(null));
        }

        [TestMethod]
        public void ContainsOrderCorrectly()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order(new Client(), new Car(), DateTime.Now, DateTime.Now);
            orderRepository.AddOrder(order);
            Assert.AreEqual(true, orderRepository.ContainsOrder(order));
        }

        [TestMethod]
        public void NotContainsOrder()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order(new Client(), new Car(), DateTime.Now, DateTime.Now);
            Assert.AreEqual(false, orderRepository.ContainsOrder(order));
        }

        [TestMethod]
        public void ContainsNullOrder()
        {
            OrderRepository orderRepository = new OrderRepository();
            Assert.ThrowsException<ArgumentNullException>(() => orderRepository.ContainsOrder(null));
        }

        [TestMethod]
        public void CorrectGettingListOfOrders()
        {
            OrderRepository orderRepository = new OrderRepository();
            Assert.AreEqual(true, orderRepository.GetOrders() is List<Order>);
        }
    }
}