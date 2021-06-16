using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental_Director.DataAccess;
using CarRental_Director.ViewModel;
using System;

namespace UnitTestCarRental
{
    [TestClass]
    public class AllCarsViewModelTests
    {
        [TestMethod]
        public void AllCarsCollectionCreated()
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            AllCarsViewModel allCarsViewModel = new AllCarsViewModel(carRepository, mainWindow);
            Assert.IsNotNull(allCarsViewModel.AllCars);
        }

        [TestMethod]
        public void NullCarRepositoryAllCarsViewModel()
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            CarRepository carRepository = null;
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                AllCarsViewModel allCarsViewModel = new AllCarsViewModel(carRepository, mainWindow);
            });
        }

        [TestMethod]
        public void NullMainWindowAllCarsViewModel()
        {
            MainWindowViewModel mainWindow = null;
            CarRepository carRepository = new CarRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                AllCarsViewModel allCarsViewModel = new AllCarsViewModel(carRepository, mainWindow);
            });
        }

        [TestMethod]
        public void CollectionCorrectAllCarsVM()
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            CarRepository carRepository = new CarRepository();
            AllCarsViewModel allCarsViewModel = new AllCarsViewModel(carRepository, mainWindow);
            Assert.AreEqual(carRepository.GetCars().Count, allCarsViewModel.AllCars.Count);
        }
    }
}
