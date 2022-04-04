using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WDIUnitTests.Cryptographic;

namespace WDIUnitTests.MSUnit
{
    [TestClass]
    public class EncoderTests
    {
        private Encoder encoder;
        private Mock<IPrimeNumbersValidator> _primeNumbersValidator;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _primeNumbersValidator = new Mock<IPrimeNumbersValidator>();
            encoder = new Encoder(_primeNumbersValidator.Object);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void TestThat_ExceptionIsThrownForNotRelativePrimeNumbers()
        {
            // Arrange
            _primeNumbersValidator
                .Setup(s => s.AreRelativePrimeNumbers(5, It.Is<int>(x => x > 20)))
                .Returns(false);

            // Act
            encoder.TryToValidate(5, 25);

            // Assert
            _primeNumbersValidator
                .Verify(s => s.AreRelativePrimeNumbers(5, 25), Times.Once());
        }
    }
}
