using CarRental_Director.Core;
using CarRental_Director.DataAccess;
using CarRental_Director.Model;
using System;
using System.Threading.Tasks;

namespace CarRental_Director.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Fields

        ClientRepository _clientRepository;
        CarRepository _carRepository;
        OrderRepository _orderRepository;
        DataContext dataContext;
        AllClientsViewModel allClientsViewModel;
        AllCarsViewModel allCarsViewModel;
        AllOrdersViewModel allOrdersViewModel;

        public RelayCommand AddNewClientCommand { get; set; }
        public RelayCommand AddNewCarCommand { get; set; }
        public RelayCommand AddNewOrderCommand { get; set; }
        public RelayCommand AllClientsCommand { get; set; }
        public RelayCommand AllCarsCommand { get; set; }
        public RelayCommand AllOrdersCommand { get; set; }

        private object _currentView;

        #endregion

        #region Properties

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            try
            {
                dataContext = new DataContext();
                InitializeData();
            }
            catch (Exception)
            {
                InitializeData();
            }
        }

        void InitializeData()
        {
            CurrentView = new DataBaseIsLoadingViewModel();

            Task loadData = new Task(() => GetDataFromDB());
            loadData.Start();

            AddNewClientCommand = new RelayCommand(o =>
            {
                if (!(CurrentView is DataBaseIsLoadingViewModel))
                {
                    CurrentView = new ClientViewModel(new Client(), _clientRepository, this);
                }
            });

            AddNewCarCommand = new RelayCommand(o =>
            {
                if (!(CurrentView is DataBaseIsLoadingViewModel))
                {
                    CurrentView = new CarViewModel(new Car(), _carRepository, this);
                }
            });

            AddNewOrderCommand = new RelayCommand(o =>
            {
                if (!(CurrentView is DataBaseIsLoadingViewModel))
                {
                    CurrentView = new OrderViewModel(new Order(), _orderRepository, _clientRepository, _carRepository, this);
                }
            });

            AllClientsCommand = new RelayCommand(o =>
            {
                if (!(CurrentView is DataBaseIsLoadingViewModel))
                {
                    CurrentView = allClientsViewModel;
                }
            });

            AllCarsCommand = new RelayCommand(o =>
            {
                if (!(CurrentView is DataBaseIsLoadingViewModel))
                {
                    CurrentView = allCarsViewModel;
                }
            });

            AllOrdersCommand = new RelayCommand(o =>
            {
                if (!(CurrentView is DataBaseIsLoadingViewModel))
                {
                    CurrentView = allOrdersViewModel;
                }
            });
        }

        async void GetDataFromDB()
        {
            _clientRepository = new ClientRepository(dataContext);
            _carRepository = new CarRepository(dataContext);
            _orderRepository = new OrderRepository(dataContext);
            foreach (Order order in _orderRepository.GetOrders())
            {
                dataContext = new DataContext();
                order.Client = _clientRepository.GetConcreteClients(order.Client_id);
                order.Car = _carRepository.GetConcreteCar(order.Car_id);
            }
            await Task.Run(() =>
            {
                allClientsViewModel = new AllClientsViewModel(_clientRepository, this);
                allCarsViewModel = new AllCarsViewModel(_carRepository, this);
                allOrdersViewModel = new AllOrdersViewModel(_orderRepository, _clientRepository, _carRepository, this);
            });
            CurrentView = new EmptyWorkspaceViewModel();
        }

        #endregion
    }
}
