using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace CarRental_Director.Model
{
    public class Client : IDataErrorInfo
    {
        #region Constants

        int maxDigitsInDrivenLicense = 9;

        #endregion

        #region Fields

        string surname;
        string firstName;
        string secondName;

        string drivenLicense;

        string address;

        string phoneNumber;

        #endregion

        #region Properties
        
        public int ID { get; set; }

        public string Surname { get => surname; set => surname = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string SecondName { get => secondName; set => secondName = value; }

        public string DrivenLicense { get => drivenLicense; set => drivenLicense = value; }

        public string Address { get => address; set => address = value; }

        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #endregion

        #region Constructors

        public Client()
        {
        }

        public Client(string surname, string firstName, string secondName, string drivenLicense, string address, string phoneNumber)
        {
            Surname = surname;
            FirstName = firstName;
            SecondName = secondName;
            DrivenLicense = drivenLicense;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        #endregion

        #region Validation

        public bool IsValid()
        {
            foreach (string property in ValidatedProperties)
            {
                if (GetValidationError(property) != null)
                {
                    return false;
                }
            }
            return true;
        }

        static readonly string[] ValidatedProperties =
        {
            "Surname",
            "FirstName",
            "SecondName",
            "DrivenLicense",
            "PhoneNumber"
        };

        string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
            {
                return null;
            }

            string error = null;

            switch (propertyName)
            {
                case "Surname":
                    error = this.ValidateSurname();
                    break;

                case "FirstName":
                    error = this.ValidateFirstName();
                    break;

                case "SecondName":
                    error = this.ValidateSecondName();
                    break;

                case "DrivenLicense":
                    error = this.ValidateDrivenLicense();
                    break;

                case "PhoneNumber":
                    error = this.ValidatePhoneNumber();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on Client: " + propertyName);
                    break;
            }
            return error;
        }

        string ValidateSurname()
        {
            if (IsStringMissing(this.Surname))
            {
                return "Surname cannot be empty";
            }
            else if (!IsValidFIO(this.Surname))
            {
                return "Surname is invalid";
            }
            return null;
        }

        string ValidateFirstName()
        {
            if (IsStringMissing(this.FirstName))
            {
                return "First name cannot be empty";
            }
            else if (!IsValidFIO(this.FirstName))
            {
                return "First name is invalid";
            }
            return null;
        }

        string ValidateSecondName()
        {
            if (this.SecondName != null)
            {
                if (!IsValidFIO(this.SecondName))
                {
                    return "Second name is invalid";
                }
            }
            return null;
        }

        string ValidateDrivenLicense()
        {
            if (IsStringMissing(this.DrivenLicense))
            {
                return "Driven license cannot be empty";
            }
            else if (!IsValidDrivenLicense(this.DrivenLicense))
            {
                return "Driven license is invalid";
            }
            return null;
        }

        string ValidatePhoneNumber()
        {
            if (IsStringMissing(this.PhoneNumber))
            {
                return "Phone number cannot be empty";
            }
            else if (!IsValidPhoneNumber(this.PhoneNumber))
            {
                return "Phone number is invalid";
            }
            return null;
        }

        bool IsValidPhoneNumber(string phoneNumber)
        {
            if (PlusesIncorrect(phoneNumber))
            {
                return false;
            }
            else if (PhoneNumberContainsInvalidSymbols(phoneNumber))
            {
                return false;
            }
            return true;
        }

        private bool PhoneNumberContainsInvalidSymbols(string phoneNumber)
        {
            foreach (char symbol in phoneNumber)
            {
                if (SymbolIncorrect(symbol))
                {
                    return true;
                }
            }
            return false;
        }

        private bool SymbolIncorrect(char symbol)
        {
            return (!SymbolIsDigit(symbol) && (symbol != '-') && (symbol != '+') && (symbol != '*') && (symbol != '#') && (symbol != '(') && (symbol != ')'));
        }

        private bool SymbolIsDigit(char symbol)
        {
            int digit = symbol - '0';
            return (digit >= 0) && (digit <= 9);
        }

        bool PlusesIncorrect(string phoneNumber)
        {
            return phoneNumber.Contains('+') && ((phoneNumber.IndexOf('+') != phoneNumber.LastIndexOf('+')) || (phoneNumber.IndexOf('+') != 0));
        }

        bool IsValidFIO(string fio)
        {
            fio = fio.ToUpper();
            foreach (var symbol in fio)
            {
                if (((symbol < 'А') || (symbol > 'Я')) && ((symbol < 'A') || (symbol > 'Z')) && (symbol != ' ') && (symbol != '-'))
                {
                    return false;
                }
            }
            return true;
        }

        bool IsValidDrivenLicense(string license)
        {
            long number;
            if (Int64.TryParse(license, out number))
            {
                if ((number >= Math.Pow(10, maxDigitsInDrivenLicense)) && (number < Math.Pow(10, maxDigitsInDrivenLicense + 1)))
                {
                    return true;
                }
            }
            return false;
        }

        static bool IsStringMissing(string value)
        {
            return String.IsNullOrEmpty(value) || value.Trim() == String.Empty;
        }

        #endregion

        #region Overrided Methods

        public override string ToString()
        {
            return String.Format(Surname + ", " + FirstName + " : " + DrivenLicense);
        }

        #endregion
    }
}
