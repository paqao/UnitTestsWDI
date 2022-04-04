using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.Cryptographic;

namespace WDIUnitTests.NUnit
{
    public class PrimeNumberValidatorTests
    {
        private PrimeNumberValidator _primeNumberValidator;

        [SetUp]
        public void TestInitialize()
        {
            _primeNumberValidator = new PrimeNumberValidator();
        }

        [TestCase(13, true)]
        [TestCase(21, false)]
        [TestCase(997, true)]
        [TestCase(1001, false)]
        [Test]
        public void TestIfNumberIsPrime(int value, bool expected)
        {
            // Arrange

            // act
            var result = _primeNumberValidator.IsPrimeNumber(value);

            // Assert
            result.Should().Be(expected);
        }

        public void TestThat11IsPrimeNumber()
        {
            // Arrange

            // Act
            var result = _primeNumberValidator.IsPrimeNumber(11);

            // Assert
           // Assert.IsTrue(result);
//result.Should().BeTrue();
        }
    }
}
