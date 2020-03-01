using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        
        private IOrders _orers;
        private ShopCart _shopCart;

        public OrderController(IOrders orers, ShopCart shopCart)
        {
            
            _orers = orers;
            _shopCart = shopCart;
        }

        public IActionResult Forma()
        {
            _shopCart.shopCartItems = _shopCart.GetShopItems();
            if (_shopCart.shopCartItems.Count == 0)
            {
                return RedirectToAction("ZeroCart");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Forma(Order order)
        {
            _shopCart.shopCartItems = _shopCart.GetShopItems();
            if(_shopCart.shopCartItems.Count==0)
            {
                return RedirectToAction("ZeroCart");
            }
            else
            if (ModelState.IsValid)
            {
                _orers.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult ZeroCart()
        {            
            ViewBag.Message = "В корзине нет товаров";
            return View();
        }
        public IActionResult Complete()
        {
            return View();
        }

    
    }
  
}

