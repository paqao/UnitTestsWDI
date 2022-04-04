using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.Cryptographic;

namespace WDIUnitTests.MSUnit
{
    [TestClass]
    public class PrimeNumberValidatorTests
    {
        private PrimeNumberValidator _primeNumberValidator;

        [TestInitialize]
        public void TestInitialize()
        {
            _primeNumberValidator = new PrimeNumberValidator();
        }

        [TestMethod]
        public void TestThat11IsPrimeNumber()
        {
            // Arrange

            // Act
            var result = _primeNumberValidator.IsPrimeNumber(11);

            // Assert
            Assert.IsTrue(result);
            result.Should().BeTrue();
        }

        [DataRow(13, true)]
        [DataRow(21, false)]
        [DataRow(997, true)]
        [DataRow(1001, false)]
        [TestMethod]
        public void TestIfNumberIsPrime(int value, bool expected)
        {
            // Arrange

            // act
            var result = _primeNumberValidator.IsPrimeNumber(value);

            // Assert
            result.Should().Be(expected);
        }

    }
}
