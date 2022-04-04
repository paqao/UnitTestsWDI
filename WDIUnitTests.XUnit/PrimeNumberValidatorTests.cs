using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.Cryptographic;
using Xunit;

namespace WDIUnitTests.NUnit
{
    public class PrimeNumberValidatorTests
    {
        private PrimeNumberValidator _primeNumberValidator;

        public PrimeNumberValidatorTests()
        {
            _primeNumberValidator = new PrimeNumberValidator();
        }

        [InlineData(13, true)]
        [InlineData(21, false)]
        [InlineData(997, true)]
        [InlineData(1001, false)]
        [Theory]
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
