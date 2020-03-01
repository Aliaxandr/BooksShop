using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IBooks _ibooks;
        private readonly ShopCart _shopcart;
        private AppDbContent _appDbContent;

        public ShopCartController (IBooks book, ShopCart shopcart , AppDbContent appDbContent)
        {
            _ibooks = book;
            _shopcart = shopcart;
                _appDbContent = appDbContent;
        }

        public ViewResult Index()
        {
            var items = _shopcart.GetShopItems();
            _shopcart.shopCartItems = items;

            var obj = new ShopCartViewsModels();
            obj.shopCart = _shopcart;

            return View(obj);
        }

        public ActionResult AddToCart(int id, string returnUrl)
        {
            
            var item = _ibooks.AllBooks.FirstOrDefault(c => c.id == id);
            if (item != null)
            {
                _shopcart.AddToCart(item);
            }
            return Redirect(returnUrl);
        }

        public IActionResult Delete(int id)
        {
            CartItems obj = new CartItems();
            obj.id = id;
            _appDbContent.CartItems.Remove(obj);
            _appDbContent.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
