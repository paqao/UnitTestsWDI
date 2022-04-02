using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDIUnitTests.Cryptographic
{
    public class PrimeNumberValidator : IPrimeNumbersValidator
    {
        public bool AreRelativePrimeNumbers(int number1, int number2)
        {
            return GetGCDByModulus(number1, number2) == 1;
        }

        private int GetGCDByModulus(int value1, int value2)
        {
            while (value1 != 0 && value2 != 0)
            {
                if (value1 > value2)
                    value1 %= value2;
                else
                    value2 %= value1;
            }
            return Math.Max(value1, value2);
        }

        public bool IsPrimeNumber(int number)
        {
            if(number % 2 == 0)
            {
                return false;
            }
            for(int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
