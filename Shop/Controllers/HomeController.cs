using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private IBooks _ibooks;

        public HomeController(IBooks ibooks)
        {
            _ibooks = ibooks;          
        }
        public ViewResult Index()
        {
            HomeViewsModels obj = new HomeViewsModels();
            obj.favBooks = _ibooks.GetFavBooks;
            return View(obj);
        }
        public ViewResult Contacts()
        {
            return View();
        }
    }
}
