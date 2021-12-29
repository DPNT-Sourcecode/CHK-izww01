using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{

    public class Discount
    {
        public int? DiscountNumber { get; set; }

        public int? DiscountPrice { get; set; }
    }

    public class StockItem
    {
        public string StockKeepingUnit { get; set; }

        public int Price { get; set; }


        public List<Discount> Discounts { get; set; }
    }
}

