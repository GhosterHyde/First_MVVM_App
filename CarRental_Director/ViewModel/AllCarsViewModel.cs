using CarRental_Director.Core;
using CarRental_Director.DataAccess;
using CarRental_Director.Model;
using System;
using System.Collections.ObjectModel;

namespace CarRental_Director.ViewModel
{
    public class AllCarsViewModel : ObservableObject
    {
        #region Fields

        readonly CarRepository _carRepository;
        private MainWindowViewModel parent;
        private ObservableCollection<CarViewModel> allCars;

        #endregion

        #region Properties

        public ObservableCollection<CarViewModel> AllCars
        {
            get { return allCars; }
            set
            {
                allCars = value;
                base.OnPropertyChanged("AllCars");
            }
        }

        #endregion

        #region Commands

        public RelayCommand UpdateCar { get; set; }
        public RelayCommand DeleteCar { get; set; }

        #endregion

        #region Constructor

        public AllCarsViewModel(CarRepository carRepository, MainWindowViewModel mainWindowViewModel)
        {
            if ((carRepository == null) || (mainWindowViewModel == null))
            {
                throw new ArgumentNullException("carRepository");
            }
            parent = mainWindowViewModel;
            _carRepository = carRepository;
            AllCars = new ObservableCollection<CarViewModel>();
            CreateAllCars();

            UpdateCar = new RelayCommand(o =>
            {
                mainWindowViewModel.CurrentView = o;
            });
            DeleteCar = new RelayCommand(o =>
            {
                CarViewModel carVM = (CarViewModel)o;
                Car car = carVM.Car;
                carRepository.DeleteCar(car);
                AllCars.Remove(carVM);
            });
        }

        #endregion

        #region Car Display

        void CreateAllCars()
        {
            foreach (Car car in _carRepository.GetCars())
            {
                CarViewModel carVM = new CarViewModel(car, _carRepository);
                carVM.Parrent = parent;
                AllCars.Add(carVM);
            }
        }

        #endregion
    }
}
