using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDIUnitTests.Fibonacci
{
    public class IdGenerator
    {
        private IFibonacciGenerator FibonacciGenerator { get; init; }
        
        public IdGenerator(IFibonacciGenerator fibonacciGenerator)
        {
            FibonacciGenerator = fibonacciGenerator;
        }

        public string GenerateId()
        {
            return $"code-{FibonacciGenerator.GetNext()}";
        }
    }
}
