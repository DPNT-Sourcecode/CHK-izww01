using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public class StockItem
    {
        public string StockKeepingUnit { get; set; }
        public int Price { get; set; }
    }

    public static class CheckoutSolution
    {
        public const int IllegalInput = -1;

        private static readonly List<StockItem> _stockItemsList = new List<StockItem>
        {
            new StockItem { StockKeepingUnit= "A", Price = 50 },
            new StockItem { StockKeepingUnit= "B", Price = 30 },
            new StockItem { StockKeepingUnit= "C", Price = 20 },
            new StockItem { StockKeepingUnit= "D", Price = 15 },
        };

        public static int ComputePrice(string skus)
        {
            if (string.IsNullOrEmpty(skus))
            {
                return IllegalInput;
            }
            var stockItem = _stockItemsList.First(s => s.StockKeepingUnit == skus);
            if (stockItem == null)
            {
                return IllegalInput;
            }

            return stockItem.Price;
        }
    }
}
