using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.Calculator;

namespace WDIUnitTests.MSUnit
{
    [TestClass]
    public class DivisionOperationTests
    {
        private DivisionOperator _divisionOperator;

        [TestInitialize]
        public void TestInitialize()
        {
            _divisionOperator = new DivisionOperator();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestThat_ExceptionIsThrownWhenDivideByZero()
        {
            // Arrange

            // ACt
            _divisionOperator.Calculate(10, 0);

            // Assert
        }
    }
}
