using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            Item milk = new Item(1, "Cow Milk", 1.00);
            Item eggPack = new Item(2, "6 eggs", 3.00);
            Item sandwich = new Item(1, "Salmon egg", 3.50);
            items.Add(milk);
            items.Add(eggPack);
            items.Add(sandwich);
            
            Customer Ben = new Customer("EPIC"); //Links to constructor in customer.cs
            Store Tesco = new Store(items);
            Basket basket = new Basket(Ben, Tesco);

            basket.addSelectedItem(milk);
            basket.addSelectedItem(eggPack);
            basket.addSelectedItem(sandwich);

            Checkout checkout = new Checkout(basket);

            double totalPrice = checkout.checkoutPrice();

            Console.WriteLine("Total price for basket is- " + totalPrice);
            Console.ReadLine();

        } 
    }
}
