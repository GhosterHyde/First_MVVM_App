using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CarRental_Director.Model
{
    public class Order : IDataErrorInfo
    {
        #region Constants

        #endregion

        #region Fields


        Car car;

        DateTime issueDate;

        DateTime returnDate;

        #endregion

        #region Properties

        public int ID { get; set; }

        public Client Client { get; set; }

        public int Client_id { get; set; }

        public Car Car { get => car; set => car = value; }

        public int Car_id { get; set; }

        public DateTime IssueDate { get => issueDate; set => issueDate = value; }

        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }

        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #endregion

        #region Constructors

        public Order()
        {
        }

        public Order(Client client, Car car, DateTime issueDate, DateTime returnDate)
        {
            Client = client;
            Car = car;
            IssueDate = issueDate;
            ReturnDate = returnDate;
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
            "Client",
            "Car",
            "IssueDate",
            "ReturnDate"
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
                case "Client":
                    error = this.ValidateClientOrCar(this.Client);
                    break;

                case "Car":
                    error = this.ValidateClientOrCar(this.Car);
                    break;

                case "IssueDate":
                    error = this.ValidateIssueDate();
                    break;

                case "ReturnDate":
                    error = this.ValidateReturnDate();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on Order: " + propertyName);
                    break;
            }
            return error;
        }

        private string ValidateClientOrCar(object entity)
        {
            if (IsMissing(entity))
            {
                return "Field cannot be empty";
            }
            return null;
        }

        string ValidateIssueDate()
        {
            if (IsNotSelectedDate(this.IssueDate))
            {
                return "Date wasn't selected";
            }
            return null;
        }

        string ValidateReturnDate()
        {
            if (IsNotSelectedDate(this.ReturnDate))
            {
                return "Date wasn't selected";
            }
            else if (DatesIncorrect())
            {
                return "Date wasn't selected";
            }
            return null;
        }

        private bool IsNotSelectedDate(DateTime date)
        {
            if (date.Year == 1)
            {
                return true;
            }
            return false;
        }

        private bool DatesIncorrect()
        {
            if (IssueDate > ReturnDate)
            {
                return true;
            }
            return false;
        }

        static bool IsMissing(object entity)
        {
            return entity == null;
        }

        #endregion
    }
}
