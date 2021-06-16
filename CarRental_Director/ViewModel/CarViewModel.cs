using CarRental_Director.Core;
using CarRental_Director.DataAccess;
using CarRental_Director.Model;
using CarRental_Director.View;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace CarRental_Director.ViewModel
{
    public class CarViewModel : ObservableObject, IDataErrorInfo
    {
        #region Fields

        readonly Car _car;
        readonly CarRepository _carRepository;
        MainWindowViewModel parrent;
        RelayCommand _saveCommand;

        #endregion

        #region Properties

        public Car Car => _car;
        public MainWindowViewModel Parrent { get => parrent; set => parrent = value; }

        #endregion

        #region Car Properties

        public string Brand
        {
            get { return Car.Brand; }
            set
            {
                if (value == Car.Brand)
                {
                    return;
                }

                Car.Brand = value;

                base.OnPropertyChanged("Brand");
            }
        }

        public string Cost
        {
            get { return Car.Cost; }
            set
            {
                if (value == Car.Cost)
                {
                    return;
                }

                Car.Cost = value;

                base.OnPropertyChanged("Cost");
            }
        }

        public string Type
        {
            get { return Car.Type; }
            set
            {
                if (value == Car.Type)
                {
                    return;
                }

                Car.Type = value;

                base.OnPropertyChanged("Type");
            }
        }

        public string StateNumber
        {
            get { return Car.StateNumber; }
            set
            {
                if (value == Car.StateNumber)
                {
                    return;
                }

                Car.StateNumber = value;

                base.OnPropertyChanged("StateNumber");
            }
        }

        public string Mileage
        {
            get { return Car.Mileage; }
            set
            {
                if (value == Car.Mileage)
                {
                    return;
                }

                Car.Mileage = value;

                base.OnPropertyChanged("Mileage");
            }
        }

        public string ManufactureYear
        {
            get { return Car.ManufactureYear; }
            set
            {
                if (value == Car.ManufactureYear)
                {
                    return;
                }

                Car.ManufactureYear = value;

                base.OnPropertyChanged("ManufactureYear");
            }
        }

        public string RentalPrice
        {
            get { return Car.RentalPrice; }
            set
            {
                if (value == Car.RentalPrice)
                {
                    return;
                }

                Car.RentalPrice = value;

                base.OnPropertyChanged("RentalPrice");
            }
        }

        #endregion

        #region Constructors

        public CarViewModel(Car car, CarRepository carRepository, MainWindowViewModel mainWindowViewModel)
        {
            NullExceptionChecking(car, carRepository, mainWindowViewModel);
            _car = car;
            _carRepository = carRepository;
            Parrent = mainWindowViewModel;
        }

        private void NullExceptionChecking(Car car, CarRepository carRepository, MainWindowViewModel mainWindowViewModel)
        {
            if((car == null) || (carRepository == null) || (mainWindowViewModel == null))
            {
                throw new ArgumentNullException();
            }
        }

        public CarViewModel(Car car, CarRepository carRepository)
        {
            NullExceptionChecking(car, carRepository);
            _car = car;
            _carRepository = carRepository;
            Brand = _car.Brand;
            Cost = _car.Cost;
            Type = _car.Type;
            StateNumber = _car.StateNumber;
            Mileage = _car.Mileage;
            ManufactureYear = _car.ManufactureYear;
            RentalPrice = _car.RentalPrice;
        }

        private void NullExceptionChecking(Car car, CarRepository carRepository)
        {
            if ((car == null) || (carRepository == null))
            {
                throw new ArgumentNullException();
            }
        }

        #endregion

        #region Commands

        public RelayCommand SaveCar
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
                AddDataForCar();
                if (!Car.IsValid())
                {
                    throw new InvalidOperationException("Car cannot be saved! Correct car data!");
                }
                if (this.IsNewCar)
                {
                    _carRepository.AddCar(Car);
                }
                _carRepository.DataContext.SaveChangesAsync();

                Parrent.CurrentView = new CarSuccessfullAdding();
            }
            catch (Exception ex)
            {
                parrent.CurrentView = new ErrorReportingViewModel(ex.Message);
            }
        }

        private void AddDataForCar()
        {
            Car.Brand = this.Brand;
            Car.Cost = this.Cost;
            Car.Type = this.Type;
            Car.StateNumber = this.StateNumber;
            Car.Mileage = this.Mileage;
            Car.ManufactureYear = this.ManufactureYear;
            Car.RentalPrice = this.RentalPrice;
        }

        #endregion

        #region Private Helpers

        bool IsNewCar
        {
            get { return !_carRepository.ContainsCar(Car); }
        }

        bool CanSave
        {
            get { return Car.IsValid(); }
        }

        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return (Car as IDataErrorInfo).Error; }
        }


        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;
                error = (Car as IDataErrorInfo)[propertyName];
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }
        #endregion
    }
}
