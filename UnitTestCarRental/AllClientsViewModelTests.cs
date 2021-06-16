using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental_Director.DataAccess;
using CarRental_Director.ViewModel;
using System;

namespace UnitTestClientRental
{
    [TestClass]
    public class AllClientsViewModelTests
    {
        [TestMethod]
        public void AllClientsCollectionCreated()
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            ClientRepository clientRepository = new ClientRepository();
            AllClientsViewModel allClientsViewModel = new AllClientsViewModel(clientRepository, mainWindow);
            Assert.IsNotNull(allClientsViewModel.AllClients);
        }

        [TestMethod]
        public void NullClientRepositoryAllClientsViewModel()
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            ClientRepository clientRepository = null;
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                AllClientsViewModel allClientsViewModel = new AllClientsViewModel(clientRepository, mainWindow);
            });
        }

        [TestMethod]
        public void NullMainWindowAllClientsViewModel()
        {
            MainWindowViewModel mainWindow = null;
            ClientRepository clientRepository = new ClientRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                AllClientsViewModel allClientsViewModel = new AllClientsViewModel(clientRepository, mainWindow);
            });
        }

        [TestMethod]
        public void CollectionCorrectAllClientsVM()
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel();
            ClientRepository clientRepository = new ClientRepository();
            AllClientsViewModel allClientsViewModel = new AllClientsViewModel(clientRepository, mainWindow);
            Assert.AreEqual(clientRepository.GetClients().Count, allClientsViewModel.AllClients.Count);
        }
    }
}