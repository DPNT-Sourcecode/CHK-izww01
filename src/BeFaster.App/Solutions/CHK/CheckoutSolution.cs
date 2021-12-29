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
            new StockItem { StockKeepingUnit = "A", Price = 50, DiscountNumber = 3, DiscountPrice = 130 },
            new StockItem { StockKeepingUnit = "B", Price = 30, DiscountNumber = 2, DiscountPrice = 45 },
            new StockItem { StockKeepingUnit = "C", Price = 20 },
            new StockItem { StockKeepingUnit = "D", Price = 15 },
        };

        public static int ComputePrice(string skus)
        {
            if (skus == null)
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
                total = CalculateSkuTotalWithDiscount(skuList, stockItem) + total;
            }

            return total;
        }

        private static int CalculateSkuTotalWithDiscount(IGrouping<char, char> skuList, StockItem stockItem)
        {
            var discountedNumber = stockItem.DiscountNumber ?? 0;
            var discountPrice = stockItem.DiscountPrice ?? 0;
            var numberDiscounted = GetNumberOfDiscountedItems(skuList.Count(), discountedNumber);
            var numberFullPrice = skuList.Count() - (numberDiscounted * discountedNumber);
            return (numberDiscounted * discountPrice) + (numberFullPrice * stockItem.Price);            
        }

        private static int GetNumberOfDiscountedItems(int skuListCount, int discountNumber)
        {
            var discounted = Math.Floor(skuListCount / (double)discountNumber);
            return (int)discounted;
        }
    }
}








