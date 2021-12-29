namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public const int IllegalInput = -1;

        public static int ComputePrice(string skus)
        {
            if (string.IsNullOrEmpty(skus))
            {
                return IllegalInput;
            }
            return 0;
        }
    }
}

