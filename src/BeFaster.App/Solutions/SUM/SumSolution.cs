using BeFaster.Runner.Exceptions;
using System;

namespace BeFaster.App.Solutions.SUM
{
    public static class SumSolution
    {
        public static int Sum(int x, int y)
        {
            if (x < 0 || x > 100)
            {
                throw new ArgumentException($"{nameof(x)} must be between 0 - 100", nameof(x));
            }


            if (y < 0 || y > 100)
            {
                throw new ArgumentException($"{nameof(y)} must be between 0 - 100", nameof(y));
            }

            return x + y;
        }
    }
}
