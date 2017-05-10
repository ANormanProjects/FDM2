using System.Collections.Generic;
using System.Linq;

namespace SupermarketCheckout
{
    public class Checkout
    {
        public Basket Basket { get; set; }

        public Checkout(Basket basket)
        {
            Basket = basket;
        }

        public double CalculatePrice()
        {
            double totalCost = 0.0;

            List<SKU> uniqueProducts = new List<SKU>();

            foreach (var item in Basket.skuList)
            {
                if (uniqueProducts.Contains(item) == false)
                {
                    uniqueProducts.Add(item);
                }
            }

            foreach (var item in uniqueProducts)
            {
                if (item.isThereAnOffer == true)
                {
                    totalCost = totalCost
                        + ((Basket.skuList.Where(c => c.name == item.name).Count() / item.numberRequiredForOffer) * item.offerPrice)
                        + ((Basket.skuList.Where(c => c.name == item.name).Count() % item.numberRequiredForOffer) * item.price);
                }
                else
                {
                    totalCost = totalCost
                        + ((Basket.skuList.Where(c => c.name == item.name).Count() * item.price));
                }
            }

            return totalCost;
        }
    }
}
