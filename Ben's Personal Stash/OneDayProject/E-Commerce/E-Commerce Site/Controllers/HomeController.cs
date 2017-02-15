using E_Commerce_DAL;
using E_Commerce_Logic;
using E_Commerce_Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce_Site.Controllers
{
    public class HomeController : Controller
    {
        E_CommerceDataModel ecommerceDataModel = new E_CommerceDataModel();
        ItemRepository itemRepo;
        BasketRepository basketRepo;
        ItemLogic itemLogic;
        BasketLogic basketLogic;

        public HomeController()
        {
            itemRepo = new ItemRepository(ecommerceDataModel);
            basketRepo = new BasketRepository(ecommerceDataModel);
            itemLogic = new ItemLogic(itemRepo);
            basketLogic = new BasketLogic(itemRepo, basketRepo);

        }

        //Tests
        public HomeController(ItemLogic _itemLogic)
        {
            itemLogic = _itemLogic;
        }



        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult ItemList()
        {

            return View("ItemList", itemLogic.GetAllItems());
        }

        [HttpGet]
        public ActionResult AddToBasket()
        {
            return View("AddToBasket");
        }

        [HttpPost]
        public ActionResult AddToBasket(Item item)
        {
            Basket targetBasket = null;
            Item itemChoice = null;
            int basketId = 4;
            foreach (Basket basket in basketRepo.GetAllBaskets())
            {
                if (basketId == basket.basketId)
                {
                    targetBasket = basket;
                }
            }

            foreach (Item items in itemRepo.GetAllItems())
            {
                if (item.name == items.name)
                {
                    itemChoice = items;
                }
            }


            basketLogic.addItemToBasket(targetBasket, itemChoice);

            return View("AddToBasket");
        }

        public ActionResult BasketList()
        {
            Basket basketList = null;
            //Basket customerBasket = new Basket();
            //customerBasket.basketId = 4;
            //customerBasket.basketName = "MyBasket";
            int basketId = 4;

            foreach (Basket basket in basketRepo.GetAllBaskets())
            {
                if(basketId == basket.basketId)
                {
                    basketList = basket;
                }
            }

            return View("Basket", basketList);
        }
    }
}