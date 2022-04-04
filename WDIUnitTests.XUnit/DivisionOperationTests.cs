using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.Calculator;
using Xunit;

namespace WDIUnitTests.XUnit
{
    public class DivisionOperationTests
    {
        private DivisionOperator _divisionOperator;

        public DivisionOperationTests()
        {
            _divisionOperator = new DivisionOperator();
        }

        [Fact]
        public void TestThat_ExceptionIsThrownWhenDivideByZero()
        {
            // Arrange

            // ACt
            var exception = Assert.Throws<DivideByZeroException>(() => _divisionOperator.Calculate(10, 0));

            // Assert
            exception.Message.Should().Be("0");
        }
    }
}
