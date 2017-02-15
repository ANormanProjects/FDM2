using E_Commerce_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Logic
{
    public class BasketLogic
    {
        ItemRepository itemRepo;
        BasketRepository basketRepo;

        public BasketLogic(ItemRepository _itemRepo, BasketRepository _basketRepo)
        {
            itemRepo = _itemRepo;
            basketRepo = _basketRepo;
        }

        public virtual void startNewBasket(Basket basket)
        {
            if (basketRepo.GetAllBaskets().Contains(basket))
            {
                throw new BasketAlreadyExistsException();
            }
            else
            {
                basketRepo.addNewBasket(basket);
                basketRepo.Save();
            }
        }
        
        public virtual List<Item> GetAllItemsInBasket(Basket basket)
        {
            List<Item> items = new List<Item>();
            if (basketRepo.GetAllBaskets().Contains(basket))
            {
                foreach(Item item in basket.itemsInBasket)
                {
                    items.Add(item);
                }
                basketRepo.Save();
            }
            return items;
        }

        public void addItemToBasket(Basket basket, Item item)
        {
            if(basketRepo.GetAllBaskets().Contains(basket))
            {
                if (itemRepo.GetAllItems().Contains(item))
                {
                    basket.itemsInBasket.Add(item);
                    basketRepo.Save();
                }
                else
                {
                    throw new ItemDoesNotExistException();
                }
            }
        }
    }
}
