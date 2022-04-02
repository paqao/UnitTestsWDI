using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDIUnitTests.Cryptographic
{
    public class Encoder
    {
        private int Number1 { get; set; }
        private int Number2 { get; set; }

        public Encoder(IPrimeNumbersValidator primeNumbersValidator)
        {
            if(!primeNumbersValidator.AreRelativePrimeNumbers(Number1, Number2))
            {
                throw new Exception("Numbers should be relive prime numbers");
            }
        }
    }
}
