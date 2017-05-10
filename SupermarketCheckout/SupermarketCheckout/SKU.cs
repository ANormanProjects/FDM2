using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout
{
    //Stock Keeping Unit SKU
    public class SKU
    {
        public virtual string name { get; set; }

        public virtual double price { get; set; }

        public virtual bool isThereAnOffer { get; set; }

        public virtual int numberRequiredForOffer { get; set; }

        public virtual double offerPrice { get; set; }

    }
}
