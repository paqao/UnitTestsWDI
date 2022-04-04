using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.Calculator;

namespace WDIUnitTests.NUnit
{
    public class DivisionOperationTests
    {
        private DivisionOperator _divisionOperator;

        [SetUp]
        public void TestInitialize()
        {
            _divisionOperator = new DivisionOperator();
        }

        [Test]
        public void TestThat_ExceptionIsThrownWhenDivideByZero()
        {
            // Arrange

            // ACt
            var exception = Assert.Throws<DivideByZeroException>(() => _divisionOperator.Calculate(10, 0));

            // Assert
            Assert.Multiple(() =>
            {
                exception.Message.Should().Be("0");
                Assert.IsTrue(exception.InnerException == null);
            });
        }
    }
}
