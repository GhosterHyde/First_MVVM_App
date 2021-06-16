using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental_Director.Core;

namespace UnitTestCarRental
{
    [TestClass]
    public class RelayCommandTests
    {
        void DoSomething()
        {
        }

        [TestMethod]
        public void RelayCommandCreationWasCorrect()
        {
            RelayCommand command = new RelayCommand(o =>
            {
                DoSomething();
            });
            Assert.AreEqual(true, command.CanExecute(null));
        }

        [TestMethod]
        public void RelayCommandCreationWasCorrec()
        {
            RelayCommand command = new RelayCommand(o =>
            {
                DoSomething();
            });
            command.Execute(null);
            Assert.AreEqual(true, command.CanExecute(null));
        }
    }
}
