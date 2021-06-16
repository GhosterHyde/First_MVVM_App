using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CarRental_Director.Model
{
    public class Car : IDataErrorInfo
    {
        #region Constants

        int minSymbolsInStateNumber = 4;
        int maxSymbolsInStateNumber = 7;
        int manufactureYearOfFirstCarInTheWorld = 1886;
        int maxDigitsInMileAgePanel = 6;

        #endregion

        #region Fields

        string brand;

        string cost;
        
        string type;

        string stateNumer;

        string mileage;

        string manufactureYear;

        string rentalPrice;

        #endregion

        #region Properties
        
        public int ID { get; set; }

        public string Brand { get => brand; set => brand = value; }

        public string Cost { get => cost; set => cost = value; }
        
        public string Type { get => type; set => type = value; }

        public string StateNumber { get => stateNumer; set => stateNumer = value; }

        public string Mileage { get => mileage; set => mileage = value; }

        public string ManufactureYear { get => manufactureYear; set => manufactureYear = value; }

        public string RentalPrice { get => rentalPrice; set => rentalPrice = value; }

        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #endregion

        #region Constructors

        public Car()
        {
        }

        public Car(string brand, string cost, string type, string stateNumber, string mileage, string manufactureYear, string rentalPrice)
        {
            Brand = brand;
            Cost = cost;
            Type = type;
            StateNumber = stateNumber;
            Mileage = mileage;
            ManufactureYear = manufactureYear;
            RentalPrice = rentalPrice;
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
            "Brand",
            "Cost",
            "Type",
            "StateNumber",
            "Mileage",
            "ManufactureYear",
            "RentalPrice"
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
                case "Brand":
                    error = this.ValidateBrand();
                    break;

                case "Cost":
                    error = this.ValidateCost();
                    break;

                case "Type":
                    error = this.ValidateType();
                    break;

                case "StateNumber":
                    error = this.ValidateStateNumber();
                    break;

                case "Mileage":
                    error = this.ValidateMileage();
                    break;

                case "ManufactureYear":
                    error = this.ValidateManufactureYear();
                    break;

                case "RentalPrice":
                    error = this.ValidateRentalPrice();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on Car: " + propertyName);
                    break;
            }
            return error;
        }

        private string ValidateStateNumber()
        {
            if (IsStringMissing(this.StateNumber))
            {
                return "State Number cannot be empty";
            }
            else if (!IsValidStateNumber(this.StateNumber))
            {
                return "State Number is invalid";
            }
            return null;
        }

        private bool IsValidStateNumber(string stateNumber)
        {
            if((stateNumer.Length >= minSymbolsInStateNumber) && (stateNumber.Length <= maxSymbolsInStateNumber))
            {
                return true;
            }
            return false;
        }

        private string ValidateRentalPrice()
        {
            if (IsStringMissing(this.RentalPrice))
            {
                return "Rental Price cannot be empty";
            }
            else if (!IsValidCostOrPrice(this.RentalPrice))
            {
                return "Rental Price is invalid";
            }
            return null;
        }

        private string ValidateManufactureYear()
        {
            if (IsStringMissing(this.ManufactureYear))
            {
                return "Year of Manufacture cannot be empty";
            }
            else if (!IsValidManufactureYear(this.ManufactureYear))
            {
                return "Year of Manufacture is invalid";
            }
            return null;
        }

        private bool IsValidManufactureYear(string manufactureYear)
        {
            long number;
            if (Int64.TryParse(manufactureYear, out number))
            {
                if ((number >= manufactureYearOfFirstCarInTheWorld) && (number <= DateTime.Now.Year))
                {
                    return true;
                }
            }
            return false;
        }

        private string ValidateMileage()
        {
            if (IsStringMissing(this.Mileage))
            {
                return "Mileage cannot be empty";
            }
            else if (!IsValidMileage(this.Mileage))
            {
                return "Mileage is invalid";
            }
            return null;
        }

        private bool IsValidMileage(string mileage)
        {
            long number;
            if (Int64.TryParse(mileage, out number))
            {
                if ((number >= 0) && (number < Math.Pow(10, maxDigitsInMileAgePanel))) {
                    return true;
                }
            }
            return false;
        }

        private string ValidateType()
        {
            if (IsStringMissing(this.Type))
            {
                return "Type cannot be empty";
            }
            return null;
        }

        string ValidateBrand()
        {
            if (IsStringMissing(this.Brand))
            {
                return "Brand cannot be empty";
            }
            return null;
        }

        string ValidateCost()
        {
            if (IsStringMissing(this.Cost))
            {
                return "Cost cannot be empty";
            }
            else if (!IsValidCostOrPrice(this.Cost))
            {
                return "Cost is invalid";
            }
            return null;
        }

        bool IsValidCostOrPrice(string cost)
        {
            long number;
            if (Int64.TryParse(cost, out number))
            {
                if (number >= 0)
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
            return String.Format(Brand + " : " + StateNumber);
        }

        #endregion
    }
}
