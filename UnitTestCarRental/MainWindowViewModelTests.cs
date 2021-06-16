using CarRental_Director.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarRental
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void CorrectMainWindowVMCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Assert.IsNotNull(mainWindowViewModel);
        }

        [TestMethod]
        public void CurrentViewCreatedSuccessfully()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Assert.IsNotNull(mainWindowViewModel.CurrentView);
        }

        [TestMethod]
        public void AllCarsCommandCreatedSuccessfully()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Assert.IsNotNull(mainWindowViewModel.AllCarsCommand);
        }

        [TestMethod]
        public void AllClientsCommandCreatedSuccessfully()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Assert.IsNotNull(mainWindowViewModel.AllClientsCommand);
        }

        [TestMethod]
        public void AllOrdersCommandCreatedSuccessfully()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Assert.IsNotNull(mainWindowViewModel.AllOrdersCommand);
        }

        [TestMethod]
        public void AddNewCarCommandCreatedSuccessfully()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Assert.IsNotNull(mainWindowViewModel.AddNewCarCommand);
        }

        [TestMethod]
        public void AddNewClientCommandCreatedSuccessfully()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Assert.IsNotNull(mainWindowViewModel.AddNewClientCommand);
        }

        [TestMethod]
        public void AddNewOrderCommandCreatedSuccessfully()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Assert.IsNotNull(mainWindowViewModel.AddNewOrderCommand);
        }
    }
}
