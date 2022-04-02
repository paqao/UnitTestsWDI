using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDIUnitTests.Calculator
{
    public interface IMathematicOperation
    {
        double Calculate(double value1, double value2);
    }
}
