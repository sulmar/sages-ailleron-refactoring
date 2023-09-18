using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System.Runtime.ConstrainedExecution;

namespace SingletonPattern.UnitTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void Create_CallTwice_ShouldBeTheSameInstance()
        {
            // Arrange
            

            // Act
            MessageService messageService = new MessageService(Logger.Instance);
            PrintService printService = new PrintService(Logger.Instance);

            // Assert
            Assert.AreSame(messageService.logger, printService.logger, "Different instances");

        }
    }
}


namespace SingletonPattern.XUnitTests
{
}
