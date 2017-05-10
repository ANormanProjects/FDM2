using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout
{
    public class Basket
    {
        public List<SKU> skuList { get; set; }

        public Basket()
        {
            skuList = new List<SKU>();
        }


        public void AddSku(SKU skuToAdd)
        {
            skuList.Add(skuToAdd);
        }
    }
}
