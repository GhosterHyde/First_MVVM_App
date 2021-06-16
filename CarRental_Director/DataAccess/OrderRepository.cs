using CarRental_Director.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarRental_Director.DataAccess
{
    public class OrderRepository
    {
        #region Fields

        readonly List<Order> _orders;

        #endregion

        public DataContext DataContext { get; set; }

        #region Constructor
        public OrderRepository()
        {
            _orders = LoadOrders();
        }

        public OrderRepository(DataContext dataContext)
        {
            DataContext = dataContext;
            _orders = LoadOrders();
        }

        #endregion

        #region Loading Orders

        private List<Order> LoadOrders()
        {
            try
            {
                DataContext.Orders.Load();
                return DataContext.Orders.ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }

        #endregion

        #region Add Order

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }

            if (!_orders.Contains(order))
            {
                try
                {
                    DataContext.Orders.Add(order);
                    DataContext.SaveChangesAsync();
                    _orders.Add(order);
                }
                catch (Exception)
                {
                    _orders.Add(order);
                }
            }
        }

        #endregion

        #region Delete Order

        public void DeleteOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }

            if (_orders.Contains(order))
            {
                try
                {
                    DataContext.Orders.Remove(order);
                    DataContext.SaveChangesAsync();
                    _orders.Remove(order);
                }
                catch (Exception)
                {
                    _orders.Remove(order);
                }
            }
        }

        #endregion

        #region Work With Collection

        public bool ContainsOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }
            return _orders.Contains(order);
        }

        public List<Order> GetOrders()
        {
            return new List<Order>(_orders);
        }

        #endregion
    }
}
