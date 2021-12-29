using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{

    public class PricePerQuantity
    {
        public int Number { get; set; }

        public int Price { get; set; }
    }

    public class FreeItem
    {
        public int Number { get; set; }

        public string SKU { get; set; }
    }

    public class StockItem
    {
        public string StockKeepingUnit { get; set; }

        public int Price { get; set; }

        public List<PricePerQuantity> PricePerQuantityList { get; set; } = new List<PricePerQuantity>();

        public List<FreeItem> FreeItemList { get; set; } = new List<FreeItem>();
    }
}




