using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental_Director.ViewModel;

namespace UnitTestCarRental
{
    [TestClass]
    public class ErrorReportingViewModelTests
    {
        [TestMethod]
        public void CorrectMessage()
        {
            string message = "CorrectMessage";
            ErrorReportingViewModel mainWindow = new ErrorReportingViewModel(message);
            Assert.AreEqual(message, mainWindow.Message);
        }

        [TestMethod]
        public void NullMessage()
        {
            ErrorReportingViewModel mainWindow = new ErrorReportingViewModel(null);
            Assert.AreEqual(null, mainWindow.Message);
        }
    }
}
