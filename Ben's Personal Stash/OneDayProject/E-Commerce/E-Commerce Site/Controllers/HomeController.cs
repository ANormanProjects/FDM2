﻿using E_Commerce_DAL;
using E_Commerce_Logic;
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
        ItemLogic itemLogic;

        public HomeController()
        {
            itemRepo = new ItemRepository(ecommerceDataModel);
            itemLogic = new ItemLogic(itemRepo);

        }

        //Tests
        public HomeController(ItemLogic _itemLogic)
        {
            itemLogic = _itemLogic;
        }



        public ActionResult Index()
        {
            return View("Index", itemLogic.GetAllItems());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}