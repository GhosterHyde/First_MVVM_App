using CarRental_Director.Core;
using CarRental_Director.DataAccess;
using CarRental_Director.Model;
using System;
using System.Collections.ObjectModel;

namespace CarRental_Director.ViewModel
{
    public class AllOrdersViewModel : ObservableObject
    {
        #region Fields

        OrderRepository _orderRepository;
        ClientRepository _clientRepository;
        CarRepository _carRepository;
        private MainWindowViewModel parent;
        private ObservableCollection<OrderViewModel> allOrders;

        #endregion

        #region Properties

        public ObservableCollection<OrderViewModel> AllOrders
        {
            get { return allOrders; }
            set
            {
                allOrders = value;
                base.OnPropertyChanged("AllOrders");
            }
        }

        #endregion

        #region Commands

        public RelayCommand UpdateOrder { get; set; }
        public RelayCommand DeleteOrder { get; set; }

        #endregion

        #region Constructor

        public AllOrdersViewModel(OrderRepository orderRepository, ClientRepository clientRepository, CarRepository carRepository, MainWindowViewModel mainWindowViewModel)
        {
            if(mainWindowViewModel == null)
            {
                throw new ArgumentNullException("mainWindowViewModel");
            }
            parent = mainWindowViewModel;

            AddRepositories(orderRepository, clientRepository, carRepository);
            
            AllOrders = new ObservableCollection<OrderViewModel>();
            CreateAllOrders();

            UpdateOrder = new RelayCommand(o =>
            {
                mainWindowViewModel.CurrentView = o;
            });
            DeleteOrder = new RelayCommand(o =>
            {
                OrderViewModel orderVM = (OrderViewModel)o;
                Order order = orderVM.Order;
                orderRepository.DeleteOrder(order);
                AllOrders.Remove(orderVM);
            });
        }

        private void AddRepositories(OrderRepository orderRepository, ClientRepository clientRepository, CarRepository carRepository)
        {
            AddOrderRepository(orderRepository);
            AddClientRepository(clientRepository);
            AddCarRepository(carRepository);
        }

        private void AddCarRepository(CarRepository carRepository)
        {
            if (carRepository == null)
            {
                throw new ArgumentNullException("carRepository");
            }
            _carRepository = carRepository;
        }

        private void AddClientRepository(ClientRepository clientRepository)
        {
            if (clientRepository == null)
            {
                throw new ArgumentNullException("clientRepository");
            }
            _clientRepository = clientRepository;
        }

        private void AddOrderRepository(OrderRepository orderRepository)
        {
            if (orderRepository == null)
            {
                throw new ArgumentNullException("orderRepository");
            }
            _orderRepository = orderRepository;
        }

        #endregion

        #region Order Display

        private void CreateAllOrders()
        {
            foreach (Order order in _orderRepository.GetOrders())
            {
                if (_clientRepository.ContainsClient(order.Client) && _carRepository.ContainsCar(order.Car))
                {
                    OrderViewModel orderVM = new OrderViewModel(order, _orderRepository, _clientRepository, _carRepository, parent);
                    orderVM.Parrent = parent;
                    AllOrders.Add(orderVM);
                }
                else
                {
                    _orderRepository.DeleteOrder(order);
                }
            }
        }

        #endregion
    }
}
