using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview1
{
    public class Checkout
    {
        public Basket Items { get; set; }

        public Checkout(Basket itemsinbasket) //CONSTRUCTOR
        {
            Items = itemsinbasket; 
        }

        public double checkoutPrice() //CALCULATOR

        {
            double totalPrice = 0;
            for (int i = 0; i < Items.getAllSelectedItems().Count; i++)
            {
                totalPrice = totalPrice + Items.getAllSelectedItems()[i].cost;
            }
            return totalPrice;
            

        }

    }
}
