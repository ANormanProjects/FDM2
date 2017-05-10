using System.Collections.Generic;

namespace SupermarketCheckout
{
    public class Store
    {
        public List<SKU> stockList;

        SKU a = new SKU { name = "A", price = 5.00, isThereAnOffer = true, numberRequiredForOffer = 3, offerPrice = 13.00 };
        SKU b = new SKU { name = "B", price = 3.00, isThereAnOffer = true, numberRequiredForOffer = 2, offerPrice = 4.50 };
        SKU c = new SKU { name = "C", price = 2.00, isThereAnOffer = false };
        SKU d = new SKU { name = "D", price = 1.50, isThereAnOffer = false };

        public Store()
        {
            stockList = new List<SKU> { a, b, c, d };
        }
    }
}
