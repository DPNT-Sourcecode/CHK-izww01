using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{

    public static class CheckoutSolution
    {
        public const int IllegalInput = -1;

        private static readonly List<StockItem> _stockItemsList = new List<StockItem>
        {
            new StockItem {
                SKU = "A",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 50 },
                    new PricePerQuantity { Number = 3, Price = 130 },
                    new PricePerQuantity { Number = 5, Price = 200 }
                },
            },
            new StockItem {
                SKU = "B",
                PricePerQuantityList = new List<PricePerQuantity>{ 
                    new PricePerQuantity { Number = 1, Price = 30 },
                    new PricePerQuantity { Number = 2, Price = 45 }
                }
            },
            new StockItem {
                SKU = "C",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 20 }
                }
            },
            new StockItem {
                SKU = "D",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 15 }
                }
            },
            new StockItem {
                SKU = "E",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 40 }
                },
                FreeItemNumber = 2,
                FreeItemSKU = "B"
            },
            new StockItem {
                SKU = "F",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 10 }
                },
                FreeItemNumber = 3,
                FreeItemSKU = "F"
            },
            new StockItem {
                SKU = "G",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 20 }
                },
            },
            new StockItem {
                SKU = "H",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 10 },
                    new PricePerQuantity { Number = 5, Price = 45 },
                    new PricePerQuantity { Number = 10, Price = 80 }
                }
            },
            new StockItem {
                SKU = "I",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 35 }
                },
            },
            new StockItem {
                SKU = "J",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 60 }
                },
            },
            new StockItem {
                SKU = "K",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 80 },
                    new PricePerQuantity { Number = 2, Price = 150 },
                },
            },
            new StockItem {
                SKU = "L",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 90 }
                },
            },
            new StockItem {
                SKU = "M",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 15 }
                },
            },
            new StockItem {
                SKU = "N",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 40 }
                },
                FreeItemNumber = 3,
                FreeItemSKU = "M"
            },
            new StockItem {
                SKU = "O",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 10 }
                },
            },
            new StockItem {
                SKU = "P",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 50 },
                    new PricePerQuantity { Number = 5, Price = 200 }
                },
            },
            new StockItem {
                SKU = "Q",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 30 },
                    new PricePerQuantity { Number = 3, Price = 80 }
                },
            },
            new StockItem {
                SKU = "R",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 50 }
                },
                FreeItemNumber = 3,
                FreeItemSKU = "Q"
            },
            new StockItem {
                SKU = "S",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 30 }
                },
            },
            new StockItem {
                SKU = "T",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 20 }
                },
            },
            new StockItem {
                SKU = "U",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 40 }
                },
                FreeItemNumber = 4,
                FreeItemSKU = "U"
            },
            new StockItem {
                SKU = "V",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 50 },
                    new PricePerQuantity { Number = 2, Price = 90 },
                    new PricePerQuantity { Number = 3, Price = 130 }
                },
            },
            new StockItem {
                SKU = "W",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 20 }
                },
            },
            new StockItem {
                SKU = "X",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 90 }
                },
            },
            new StockItem {
                SKU = "Y",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 10 }
                },
            },
            new StockItem {
                SKU = "Z",
                PricePerQuantityList = new List<PricePerQuantity>{
                    new PricePerQuantity { Number = 1, Price = 50 }
                },
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
                var stockItem = _stockItemsList.FirstOrDefault(si => si.SKU == skuList.Key.ToString());
                if (stockItem?.FreeItemNumber != null)
                {
                    var freeStockItem = _stockItemsList.FirstOrDefault(si => stockItem.FreeItemSKU == si.SKU);
                    var numberOfFreeItems = GetNumberOfItemsToPrice(skuList.Count(), stockItem.FreeItemNumber.Value);
                    skusListWithFreeItemsRemoves = RemoveChars(skusListWithFreeItemsRemoves, stockItem.FreeItemSKU, numberOfFreeItems);
                }
            }

            return CalculateTotalPriceForSingleSku(skusListWithFreeItemsRemoves.GroupBy(s => s));
        }

        private static int CalculateTotalPriceForSingleSku(IEnumerable<IGrouping<char, char>> stockItemGroupsBySku)
        {         
            var total = 0;

            foreach (var skuList in stockItemGroupsBySku)
            {
                var stockItem = _stockItemsList.FirstOrDefault(sku => sku.SKU == skuList.Key.ToString());
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
            var regEx = new Regex(charToRemove);
            return regEx.Replace(originalString, "", count);
        }
    }
}


