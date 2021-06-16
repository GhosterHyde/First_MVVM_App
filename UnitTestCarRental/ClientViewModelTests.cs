using CarRental_Director.DataAccess;
using CarRental_Director.Model;
using CarRental_Director.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestClientRental
{
    [TestClass]
    public class ClientViewModelTests
    {
        [TestMethod]
        public void ClientWasCreatedSuccessfully()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(client, clientViewModel.Client);
        }

        [TestMethod]
        public void ClientWasUpdatedSuccessfully()
        {
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository);
            Assert.AreEqual(client, clientViewModel.Client);
        }

        [TestMethod]
        public void ParrentWasCreatedSuccessfully()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(mainWindowViewModel, clientViewModel.Parrent);
        }

        [TestMethod]
        public void TestForSurnameForClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "DrivenLicense";
            string address = "Address";
            string phoneNumber = "PhoneNumber";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(surname, clientViewModel.Surname);
        }

        [TestMethod]
        public void TestForFirstNameForClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "DrivenLicense";
            string address = "Address";
            string phoneNumber = "PhoneNumber";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(firstName, clientViewModel.FirstName);
        }

        [TestMethod]
        public void TestForSecondNameForClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "DrivenLicense";
            string address = "Address";
            string phoneNumber = "PhoneNumber";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(secondName, clientViewModel.SecondName);
        }

        [TestMethod]
        public void TestForDrivenLicenseForClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "DrivenLicense";
            string address = "Address";
            string phoneNumber = "PhoneNumber";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(drivenLicense, clientViewModel.DrivenLicense);
        }

        [TestMethod]
        public void TestForAddressForClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "DrivenLicense";
            string address = "Address";
            string phoneNumber = "PhoneNumber";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(address, clientViewModel.Address);
        }

        [TestMethod]
        public void TestForPhoneNumberForClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "DrivenLicense";
            string address = "Address";
            string phoneNumber = "PhoneNumber";
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(phoneNumber, clientViewModel.PhoneNumber);
        }

        [TestMethod]
        public void TestForEmptySurnameClient()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(null, clientViewModel.Surname);
        }

        [TestMethod]
        public void TestForEmptyFirstNameClient()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(null, clientViewModel.FirstName);
        }

        [TestMethod]
        public void TestForEmptySecondNameClient()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(null, clientViewModel.SecondName);
        }

        [TestMethod]
        public void TestForEmptyDrivenLicenseClient()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(null, clientViewModel.DrivenLicense);
        }

        [TestMethod]
        public void TestForEmptyAddressClient()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(null, clientViewModel.Address);
        }

        [TestMethod]
        public void TestForEmptyPhoneNumberClient()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.AddClient(client);
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.AreEqual(null, clientViewModel.PhoneNumber);
        }

        [TestMethod]
        public void TestForClearNewMainWindowViewModelCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, mainWindowViewModel);
            Assert.IsNotNull(clientViewModel);
        }

        [TestMethod]
        public void TestForMWVMNullNewMainWindowViewModelCreation()
        {
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository, null);
            });
        }

        [TestMethod]
        public void TestForClientNullNewMainWindowViewModelCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            ClientRepository clientRepository = new ClientRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                ClientViewModel clientViewModel = new ClientViewModel(null, clientRepository, mainWindowViewModel);
            });
        }

        [TestMethod]
        public void TestForClientRepositoryNullNewMainWindowViewModelCreation()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Client client = new Client();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                ClientViewModel clientViewModel = new ClientViewModel(client, null, mainWindowViewModel);
            });
        }

        [TestMethod]
        public void TestForClearMainWindowViewModelCreation()
        {
            Client client = new Client();
            ClientRepository clientRepository = new ClientRepository();
            ClientViewModel clientViewModel = new ClientViewModel(client, clientRepository);
            Assert.AreEqual(client, clientViewModel.Client);
        }

        [TestMethod]
        public void TestForClientNullMainWindowViewModelCreation()
        {
            ClientRepository clientRepository = new ClientRepository();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                ClientViewModel clientViewModel = new ClientViewModel(null, clientRepository);
            });
        }

        [TestMethod]
        public void TestForClientRepositoryNewMainWindowViewModelCreation()
        {
            Client client = new Client();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                ClientViewModel clientViewModel = new ClientViewModel(client, null);
            });
        }
    }
}