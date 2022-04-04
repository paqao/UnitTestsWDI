using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDIUnitTests.Calculator
{
    public class DivisionOperator : IMathematicOperation
    {
        public double Calculate(double value1, double value2)
        {
            if (Math.Abs(value2) < double.Epsilon)
            {
                throw new DivideByZeroException("0");
            }

            return value1 / value2;
        }
    }
}
