using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{

    public static class CheckoutSolution
    {
        public const int IllegalInput = -1;

        private static readonly List<StockItem> _stockItemsList = new List<StockItem>
        {
            new StockItem { StockKeepingUnit = "A", Price = 50 },
            new StockItem { StockKeepingUnit = "B", Price = 30 },
            new StockItem { StockKeepingUnit = "C", Price = 20 },
            new StockItem { StockKeepingUnit = "D", Price = 15 },
        };

        public static int ComputePrice(string skus)
        {
            if (string.IsNullOrEmpty(skus))
            {
                return IllegalInput;
            }
            var stockItemGroupsBySku = skus.GroupBy(s => s);
            if (stockItemGroupsBySku == null)
            {
                return IllegalInput;
            }

            var total = 0;
            foreach (var skuList in stockItemGroupsBySku)
            {
                var stockItem = _stockItemsList.FirstOrDefault(sku => sku.StockKeepingUnit == skuList.Key.ToString());
                if (stockItem == null)
                {
                    return IllegalInput;
                }
                total = total + (skuList.Count() * stockItem.Price);
            }

            return total;
        }
    }
}




