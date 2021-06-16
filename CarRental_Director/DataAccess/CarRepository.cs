using CarRental_Director.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarRental_Director.DataAccess
{
    public class CarRepository
    {
        #region Fields

        readonly List<Car> _cars;

        #endregion

        public DataContext DataContext { get; set; }

        #region Constructor

        public CarRepository()
        {
            _cars = LoadCars();
        }

        public CarRepository(DataContext dataContext)
        {
            DataContext = dataContext;
            _cars = LoadCars();
        }

        #endregion

        #region Loading Cars

        private List<Car> LoadCars()
        {
            try
            {
                DataContext.Cars.Load();
                return DataContext.Cars.ToList();
            }
            catch (Exception)
            {
                return new List<Car>();
            }
        }

        #endregion

        #region Add Car

        public void AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("car");
            }

            if (!_cars.Contains(car))
            {
                try
                {
                    DataContext.Cars.Add(car);
                    DataContext.SaveChangesAsync();
                    _cars.Add(car);
                }
                catch (Exception)
                {
                    _cars.Add(car);
                }
            }
        }

        #endregion

        #region Delete Car

        public void DeleteCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("car");
            }

            if (_cars.Contains(car))
            {
                try
                {
                    DataContext.Cars.Remove(car);
                    DataContext.SaveChangesAsync();
                    _cars.Remove(car);
                }
                catch (Exception)
                {
                    _cars.Remove(car);
                }
            }
        }

        #endregion

        #region Work With Collection

        public bool ContainsCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("car");
            }
            return _cars.Contains(car);
        }

        public List<Car> GetCars()
        {
            return new List<Car>(_cars);
        }

        public Car GetConcreteCar(int car_id)
        {
            foreach (Car car in _cars)
            {
                if (car.ID == car_id)
                {
                    return car;
                }
            }
            return null;
        }

        #endregion
    }
}
