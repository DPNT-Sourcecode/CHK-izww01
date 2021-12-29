using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace BeFaster.App.Solutions.CHK
{

    public static class CheckoutSolution
    {
        public const int IllegalInput = -1;

        private static readonly List<StockItem> _stockItemsList = new List<StockItem>
        {
            new StockItem {
                StockKeepingUnit = "A",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 50 },
                    new PricePerQuantity { Number = 3, Price = 130 },
                    new PricePerQuantity { Number = 5, Price = 200 }
                },
            },
            new StockItem {
                StockKeepingUnit = "B",
                PricePerQuantityList = new List<PricePerQuantity>{ 
                    new PricePerQuantity { Number = 1, Price = 30 },
                    new PricePerQuantity { Number = 2, Price = 45 }
                }
            },
            new StockItem {
                StockKeepingUnit = "C",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 20 }
                }
            },
            new StockItem {
                StockKeepingUnit = "D",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 15 }
                }
            },
            new StockItem {
                StockKeepingUnit = "E",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 40 }
                },
                FreeItemNumber = 2,
                FreeItemSKU = "B"
            },
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

            var skusListWithFreeItemsRemoves = skus;
            foreach (var skuList in stockItemGroupsBySku)
            {
                var stockItem = _stockItemsList.FirstOrDefault(sku => sku.StockKeepingUnit == skuList.Key.ToString());
                if (stockItem?.FreeItemNumber != null)
                {
                    var freeStockItem = _stockItemsList.FirstOrDefault(sku => stockItem.FreeItemSKU == skuList.Key.ToString());
                    var numberOfFreeItems = GetNumberOfItemsToPrice(skuList.Count(), freeStockItem.FreeItemNumber.Value);
                    skusListWithFreeItemsRemoves = RemoveChars(skusListWithFreeItemsRemoves, freeStockItem.FreeItemSKU, numberOfFreeItems);
                }
            }

            return CalculateTotalPriceForSingleSku(skusListWithFreeItemsRemoves.GroupBy(s => s));
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
            var numberPriced = 0;
            var runningTotal = 0;
            foreach (var pricePerQuantity in stockItem.PricePerQuantityList.OrderByDescending(d => d.Price))
            {
                var numberToPrice = GetNumberOfItemsToPrice(skuList.Count() - numberPriced, pricePerQuantity.Number);
                var totalPrice = numberToPrice * pricePerQuantity.Price;
                runningTotal += totalPrice;
                numberPriced += (numberToPrice * pricePerQuantity.Number);
            }

            return runningTotal;
        }

        private static int GetNumberOfItemsToPrice(int skuListCount, int numberOfItems)
        {
            var discounted = Math.Floor(skuListCount / (double)numberOfItems);
            return (int)discounted;
        }

        private static string RemoveChars(string originalString, string charToRemove, int count)
        {
            var newString = originalString;
            foreach(var _ in Enumerable.Range(1, count))
            {
                newString = originalString.Replace(charToRemove, "");
            }
            return newString;
        }
    }
}



