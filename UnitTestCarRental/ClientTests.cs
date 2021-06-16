using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental_Director.Model;

namespace UnitTestCarRental
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void EmptyClientsSurnameNull()
        {
            Client client = new Client();
            Assert.AreEqual(null, client.Surname);
        }

        [TestMethod]
        public void EmptyClientsFirstNameNull()
        {
            Client client = new Client();
            Assert.AreEqual(null, client.FirstName);
        }

        [TestMethod]
        public void EmptyClientsSecindNameNull()
        {
            Client client = new Client();
            Assert.AreEqual(null, client.SecondName);
        }

        [TestMethod]
        public void EmptyClientsDrivenLicenseNull()
        {
            Client client = new Client();
            Assert.AreEqual(null, client.DrivenLicense);
        }

        [TestMethod]
        public void EmptyClientsAddressNull()
        {
            Client client = new Client();
            Assert.AreEqual(null, client.Address);
        }

        [TestMethod]
        public void EmptyClientsPhoneNumberNull()
        {
            Client client = new Client();
            Assert.AreEqual(null, client.PhoneNumber);
        }

        [TestMethod]
        public void ClientsSurnameCorrect()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.AreEqual(surname, client.Surname);
        }

        [TestMethod]
        public void ClientsFirstNameCorrect()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.AreEqual(firstName, client.FirstName);
        }

        [TestMethod]
        public void ClientsSecondNameCorrect()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.AreEqual(secondName, client.SecondName);
        }

        [TestMethod]
        public void ClientsDrivenLicenseCorrect()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.AreEqual(drivenLicense, client.DrivenLicense);
        }

        [TestMethod]
        public void ClientsAddressCorrect()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.AreEqual(address, client.Address);
        }

        [TestMethod]
        public void ClientsPhoneNumberCorrect()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.AreEqual(phoneNumber, client.PhoneNumber);
        }

        [TestMethod]
        public void CorrectEmptyClientCreation()
        {
            Client client = new Client();
            Assert.IsNotNull(client);
        }

        [TestMethod]
        public void CorrectClientCreation()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsNotNull(client);
        }

        [TestMethod]
        public void IsNotValidEmptyCar()
        {
            Client client = new Client();
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsValidCorrectClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsTrue(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidEmptySurnameClient()
        {
            string surname = "";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrectSurnameClient()
        {
            string surname = "IncorrectSurname1";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidEmptyFirstNameClient()
        {
            string surname = "Surname";
            string firstName = "";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrectFirstNameClient()
        {
            string surname = "Surname";
            string firstName = "IncorrectFirstName1";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrectSecondNameClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName1";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidEmptyDrivenLicenseClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrectDrivenLicenseClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "IncorrectDrivenLicense";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidToLowDigitsInDrivenLicenseClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "123456789";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidToMuchDigitsInDrivenLicenseClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "12345678901";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidEmptyPhoneNumberClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidToMuchPlusesInPhoneNumberClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "++79502650887";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrectPlusPlaceInPhoneNumberClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "7+9502650887";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void IsNotValidIncorrecrSymbolInPhoneNumberClient()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "IncorrectPhoneNumber";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            Assert.IsFalse(client.IsValid());
        }

        [TestMethod]
        public void CorrectClientToStringConverter()
        {
            string surname = "Surname";
            string firstName = "FirstName";
            string secondName = "SecondName";
            string drivenLicense = "1234567890";
            string address = "Address";
            string phoneNumber = "89515714250";
            Client client = new Client(surname, firstName, secondName, drivenLicense, address, phoneNumber);
            string actual = client.ToString();
            Assert.AreEqual(client.Surname+", "+client.FirstName+" : "+client.DrivenLicense, actual);
        }

        [TestMethod]
        public void ClientWithNullDataToStringConverter()
        {
            Client client = new Client();
            string actual = client.ToString();
            Assert.AreEqual(",  : ", actual);
        }
    }
}