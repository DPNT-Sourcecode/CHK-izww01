using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{

    public static class CheckoutSolution
    {
        public const int IllegalInput = -1;

        private static readonly List<StockItem> _stockItemsList = new List<StockItem>
        {
            new StockItem { StockKeepingUnit = "A", Price = 50, DiscountAmount = 3, DiscountPrice = 130 },
            new StockItem { StockKeepingUnit = "B", Price = 30, DiscountAmount = 2, DiscountPrice = 45 },
            new StockItem { StockKeepingUnit = "C", Price = 20 },
            new StockItem { StockKeepingUnit = "D", Price = 15 },
        };

        public static int ComputePrice(string skus)
        {
            if (string.IsNullOrEmpty(skus))
            {
                return IllegalInput;
            }

            return CalculateTotalPrice(skus);
        }

        private static int CalculateTotalPrice(string skus)
        {
            var stockItemGroupsBySku = skus.GroupBy(s => s);
            if (stockItemGroupsBySku == null)
            {
                return IllegalInput;
            }

            return CalculateTotalPriceForSingleSku(stockItemGroupsBySku);
        }

        private static int CalculateTotalPriceForSingleSku(IEnumerable<IGrouping<char, char>> stockItemGroupsBySku)
        {         
            var total = 0;
            foreach (var skuList in stockItemGroupsBySku)
            {
                var stockItem = _stockItemsList.FirstOrDefault(sku => sku.StockKeepingUnit == skuList.Key.ToString());
                if (stockItem == null)
                {
                    return IllegalInput;
                }
                if (skuList.Count() > stockItem.DiscountAmount)
                {
                    var numberDiscounted = GetNumberOfDiscountedItems(skuList.Count(), stockItem.DiscountAmount);
                    var numberFullPrice = skuList.Count() - numberDiscounted;
                    var totalx = (numberDiscounted * stockItem.DiscountPrice) + (numberFullPrice * stockItem.Price);
                }
                else
                {
                    total = total + (skuList.Count() * stockItem.Price);
                }                
            }

            return total;
        }

        private static int GetNumberOfDiscountedItems(int skuListCount, int discountAmount)
        {
            var discounted = Math.Floor((double)skuListCount % discountAmount);
            return (int)discounted;
        }
    }
}
