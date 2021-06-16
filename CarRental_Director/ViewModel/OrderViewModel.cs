using CarRental_Director.Core;
using CarRental_Director.DataAccess;
using CarRental_Director.Model;
using CarRental_Director.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace CarRental_Director.ViewModel
{
    public class OrderViewModel : ObservableObject, IDataErrorInfo
    {
        #region Fields

        readonly Order _order;
        readonly OrderRepository _orderRepository;
        readonly ClientRepository _clientRepository;
        readonly CarRepository _carRepository;
        MainWindowViewModel parrent;
        RelayCommand _saveCommand;

        #endregion

        #region Properties
        public Order Order => _order;
        public MainWindowViewModel Parrent { get => parrent; set => parrent = value; }

        public List<Client> Clients => _clientRepository.GetClients();
        public List<Car> Cars => _carRepository.GetCars();

        #endregion

        #region Order Properties

        public Client Client
        {
            get { return Order.Client; }
            set
            {
                if (value == Order.Client)
                {
                    return;
                }

                Order.Client = value;

                base.OnPropertyChanged("Client");
            }
        }

        public Car Car
        {
            get { return Order.Car; }
            set
            {
                if (value == Order.Car)
                {
                    return;
                }

                Order.Car = value;
            }
        }

        public DateTime IssueDate
        {
            get { return Order.IssueDate; }
            set
            {
                if (value == Order.IssueDate)
                {
                    return;
                }

                Order.IssueDate = value;
            }
        }

        public DateTime ReturnDate
        {
            get { return Order.ReturnDate; }
            set
            {
                if (value == Order.ReturnDate)
                {
                    return;
                }

                Order.ReturnDate = value;
            }
        }

        #endregion

        #region Constructors

        public OrderViewModel(Order order, OrderRepository orderRepository, ClientRepository clientRepository, CarRepository carRepository, MainWindowViewModel mainWindowViewModel)
        {
            NullArgumentsChecking(order, orderRepository, clientRepository, carRepository, mainWindowViewModel);
            _order = order;
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _carRepository = carRepository;
            Parrent = mainWindowViewModel;
        }

        void NullArgumentsChecking(Order order, OrderRepository orderRepository, ClientRepository clientRepository, CarRepository carRepository, MainWindowViewModel mainWindowViewModel)
        {
            if ((order == null) || (orderRepository == null) || (clientRepository == null) || (carRepository == null) || (mainWindowViewModel == null))
            {
                throw new ArgumentNullException();
            }
        }

        public OrderViewModel(Order order, OrderRepository orderRepository, ClientRepository clientRepository, CarRepository carRepository)
        {
            NullArgumentsChecking(order, orderRepository, clientRepository, carRepository);
            _order = order;
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _carRepository = carRepository;
            Client = order.Client;
            Car = order.Car;
            IssueDate = order.IssueDate;
            ReturnDate = order.ReturnDate;
        }

        void NullArgumentsChecking(Order order, OrderRepository orderRepository, ClientRepository clientRepository, CarRepository carRepository)
        {
            if ((order == null) || (orderRepository == null) || (clientRepository == null) || (carRepository == null))
            {
                throw new ArgumentNullException();
            }
        }

        #endregion

        #region Commands

        public RelayCommand SaveOrder
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => this.Save(),
                        param => this.CanSave
                        );
                }
                return _saveCommand;
            }
        }

        #endregion

        #region Public Methods

        public void Save()
        {
            try
            {
                AddDataForOrder();
                if (!Order.IsValid())
                {
                    throw new InvalidOperationException("Error!&#10;Order cannot be saved! Correct order data!");
                }
                if (this.IsNewOrder)
                {
                    _orderRepository.AddOrder(Order);
                }
                _orderRepository.DataContext.SaveChangesAsync();

                Parrent.CurrentView = new OrderSuccessfullAdding();
            }
            catch (Exception ex)
            {
                parrent.CurrentView = new ErrorReportingViewModel(ex.Message);
            }
        }

        private void AddDataForOrder()
        {
            CheckData();
            Order.Client = this.Client;
            Order.Car = this.Car;
            Order.IssueDate = this.IssueDate;
            Order.ReturnDate = this.ReturnDate;
        }

        void CheckData()
        {
            if (Client == null)
            {
                throw new InvalidOperationException("Error!&#10;Client of order was not selected!");
            }
            if (Car == null)
            {
                throw new InvalidOperationException("Error!&#10;Car for the order was not selected!");
            }
            if (IssueDate.Year == 1)
            {
                IssueDate = DateTime.Today;
            }
            if (ReturnDate.Year == 1)
            {
                ReturnDate = DateTime.Today;
            }
            if (ReturnDate < IssueDate)
            {
                throw new InvalidOperationException("Error!&#10;Return date cannot be less then date of issue!");
            }
        }

        #endregion

        #region Private Helpers

        bool IsNewOrder
        {
            get { return !_orderRepository.ContainsOrder(Order); }
        }

        bool CanSave
        {
            get { return Order.IsValid(); }
        }

        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return (Order as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;
                error = (Order as IDataErrorInfo)[propertyName];
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }
        #endregion
    }
}
