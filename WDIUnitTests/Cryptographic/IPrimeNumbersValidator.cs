namespace WDIUnitTests.Cryptographic
{
    public interface IPrimeNumbersValidator
    {
        bool IsPrimeNumber(int number);

        bool AreRelativePrimeNumbers(int number1, int number2);
    }
}
