using System;

namespace SupermarketCheckout
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();

            Basket basket = new Basket();

            Console.WriteLine("Welcome to the Supermarket");
            Console.WriteLine("These are the list of items available: ");

            foreach (var item in store.stockList)
            {
                Console.WriteLine(item.name + " = £" + item.price);
            }

            Console.WriteLine();
            Console.WriteLine("This weeks special offer: ");
             
            foreach (var item in store.stockList)
            {
                if (item.isThereAnOffer)
                {
                    Console.WriteLine(item.name + " x " + item.numberRequiredForOffer + " = £" + item.offerPrice);
                }
            }

            Console.WriteLine();

            foreach (var item in store.stockList)
            {
                Console.WriteLine("How many of item " + item.name + " would you like to order?");

                int numberWanted = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < numberWanted; i++)
                {
                    basket.AddSku(item);
                }
                
            }

            Checkout checkout = new Checkout(basket);

            Console.WriteLine("Basket Total Cost = £" + checkout.CalculatePrice());

            Console.ReadLine();


        }
    }
}
