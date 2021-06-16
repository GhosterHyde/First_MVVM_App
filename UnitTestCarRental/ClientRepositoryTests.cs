using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental_Director.DataAccess;
using System.Collections.Generic;
using CarRental_Director.Model;
using System;

namespace UnitTestCarRental
{
    [TestClass]
    public class ClientRepositoryTests
    {
        [TestMethod]
        public void NewClientCreation()
        {
            ClientRepository clientRepository = new ClientRepository();
            List<Client> clients = clientRepository.GetClients();
            Assert.IsNotNull(clients);
        }

        [TestMethod]
        public void NewEmptyClientAddedSuccessfully()
        {
            ClientRepository clientRepository = new ClientRepository();
            List<Client> clients = clientRepository.GetClients();
            int collectionSize = clients.Count;
            Client client = new Client();
            clientRepository.AddClient(client);
            Assert.AreEqual(clientRepository.GetClients().Count, collectionSize + 1);
        }

        [TestMethod]
        public void NewClientAddedSuccessfully()
        {
            ClientRepository clientRepository = new ClientRepository();
            List<Client> clients = clientRepository.GetClients();
            int collectionSize = clients.Count;
            Client client = new Client("Surname", "FirstName", "SecondName", "DrivenLicense", "Address", "PhoneNUmber");
            clientRepository.AddClient(client);
            Assert.AreEqual(clientRepository.GetClients().Count, collectionSize + 1);
        }

        [TestMethod]
        public void TwiceAddingNewEmptyClient()
        {
            ClientRepository clientRepository = new ClientRepository();
            List<Client> clients = clientRepository.GetClients();
            int collectionSize = clients.Count;
            Client client = new Client();
            clientRepository.AddClient(client);
            clientRepository.AddClient(client);
            Assert.AreEqual(clientRepository.GetClients().Count, collectionSize + 1);
        }

        [TestMethod]
        public void TwiceAddingNewClient()
        {
            ClientRepository clientRepository = new ClientRepository();
            List<Client> clients = clientRepository.GetClients();
            int collectionSize = clients.Count;
            Client client = new Client("Surname", "FirstName", "SecondName", "DrivenLicense", "Address", "PhoneNUmber");
            clientRepository.AddClient(client);
            clientRepository.AddClient(client);
            Assert.AreEqual(clientRepository.GetClients().Count, collectionSize + 1);
        }

        [TestMethod]
        public void NullClientException()
        {
            ClientRepository clientRepository = new ClientRepository();
            Assert.ThrowsException<ArgumentNullException>(() => clientRepository.AddClient(null));
        }

        [TestMethod]
        public void CorrectEmptyClientDelition()
        {
            ClientRepository clientRepository = new ClientRepository();
            Client client = new Client();
            clientRepository.AddClient(client);
            List<Client> clients = clientRepository.GetClients();
            int collectionCount = clients.Count;
            clientRepository.DeleteClient(client);
            clients = clientRepository.GetClients();
            Assert.AreEqual(collectionCount - 1, clients.Count);
        }

        [TestMethod]
        public void CorrectClientDelition()
        {
            ClientRepository clientRepository = new ClientRepository();
            Client client = new Client("Surname", "FirstName", "SecondName", "DrivenLicense", "Address", "PhoneNUmber");
            clientRepository.AddClient(client);
            List<Client> clients = clientRepository.GetClients();
            int collectionCount = clients.Count;
            clientRepository.DeleteClient(client);
            clients = clientRepository.GetClients();
            Assert.AreEqual(collectionCount - 1, clients.Count);
        }

        [TestMethod]
        public void CorrectSameEmptyClientDelition()
        {
            ClientRepository clientRepository = new ClientRepository();
            Client client = new Client();
            clientRepository.AddClient(client);
            client = new Client();
            clientRepository.AddClient(client);
            List<Client> clients = clientRepository.GetClients();
            int collectionCount = clients.Count;
            clientRepository.DeleteClient(client);
            clients = clientRepository.GetClients();
            Assert.AreEqual(collectionCount - 1, clients.Count);
        }

        [TestMethod]
        public void CorrectSameClientDelition()
        {
            ClientRepository clientRepository = new ClientRepository();
            Client client = new Client("Surname", "FirstName", "SecondName", "DrivenLicense", "Address", "PhoneNUmber");
            clientRepository.AddClient(client);
            client = new Client("Surname", "FirstName", "SecondName", "DrivenLicense", "Address", "PhoneNUmber");
            clientRepository.AddClient(client);
            List<Client> clients = clientRepository.GetClients();
            int collectionCount = clients.Count;
            clientRepository.DeleteClient(client);
            clients = clientRepository.GetClients();
            Assert.AreEqual(collectionCount - 1, clients.Count);
        }

        [TestMethod]
        public void NullClientDelition()
        {
            ClientRepository clientRepository = new ClientRepository();
            Assert.ThrowsException<ArgumentNullException>(() => clientRepository.DeleteClient(null));
        }

        [TestMethod]
        public void MissingClientDelition()
        {
            ClientRepository clientRepository = new ClientRepository();
            Client client = new Client("Surname", "FirstName", "SecondName", "DrivenLicense", "Address", "PhoneNUmber");
            List<Client> clients = clientRepository.GetClients();
            int collectionCount = clients.Count;
            clientRepository.DeleteClient(client);
            clients = clientRepository.GetClients();
            Assert.AreEqual(collectionCount, clients.Count);
        }

        [TestMethod]
        public void ContainsClientCorrectly()
        {
            ClientRepository clientRepository = new ClientRepository();
            Client client = new Client("Surname", "FirstName", "SecondName", "DrivenLicense", "Address", "PhoneNUmber");
            clientRepository.AddClient(client);
            Assert.AreEqual(true, clientRepository.ContainsClient(client));
        }

        [TestMethod]
        public void NotContainsClient()
        {
            ClientRepository clientRepository = new ClientRepository();
            Client client = new Client("Surname", "FirstName", "SecondName", "DrivenLicense", "Address", "PhoneNUmber");
            Assert.AreEqual(false, clientRepository.ContainsClient(client));
        }

        [TestMethod]
        public void ContainsNullClient()
        {
            ClientRepository clientRepository = new ClientRepository();
            Assert.ThrowsException<ArgumentNullException>(() => clientRepository.ContainsClient(null));
        }

        [TestMethod]
        public void CorrectGettingListOfClients()
        {
            ClientRepository clientRepository = new ClientRepository();
            Assert.AreEqual(true, clientRepository.GetClients() is List<Client>);
        }
    }
}
