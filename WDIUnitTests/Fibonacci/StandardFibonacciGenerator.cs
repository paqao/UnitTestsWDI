namespace WDIUnitTests.Fibonacci
{
    internal class StandardFibonacciGenerator : IFibonacciGenerator
    {
        private int Last = 1;
        private int TwoTimes = 0;
        public int GetNext()
        {
            int result = Last + TwoTimes;
            TwoTimes = Last;
            Last = result;
            return result;
        }
    }
}
