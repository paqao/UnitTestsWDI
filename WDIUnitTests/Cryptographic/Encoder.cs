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
        private readonly IPrimeNumbersValidator _primeNumbersValidator;

        public Encoder(IPrimeNumbersValidator primeNumbersValidator)
        {
           _primeNumbersValidator = primeNumbersValidator;
        }

        public void TryToValidate(int number1, int number2)
        {
            if (!_primeNumbersValidator.AreRelativePrimeNumbers(number1, number2))
            {
                throw new Exception("Numbers should be relive prime numbers");
            }
        }
    }
}
