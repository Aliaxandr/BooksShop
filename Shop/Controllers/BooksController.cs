using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewsModels;

namespace Shop.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooks _ibooks;
        private readonly IBooksCategory _ibooksCategory;
        private readonly IBooksWriter _ibooksWriter;
        
        
        public BooksController (IBooks ibooks, IBooksCategory ibooksCategory, IBooksWriter ibooksWriter)
        {
            _ibooks = ibooks;
            _ibooksCategory = ibooksCategory;
            _ibooksWriter = ibooksWriter;
            
        }

        public ViewResult Index()
        {
            BooksListViewsModels obj = new BooksListViewsModels();
            obj.allBooks = _ibooks.AllBooks;
            obj.bookCategory = "Книги";       
            
            return View(obj);
            
        }

        public ViewResult AllInfo(int id)
        {
            var DBmodel = _ibooks.GetObjectBook(id);
            OneBookViewsModels obj = new OneBookViewsModels();
            obj.id = DBmodel.id;
            obj.name = DBmodel.name;
            obj.img = DBmodel.img;
            obj.longDesc = DBmodel.longDesc;            
            obj.price = DBmodel.price;
            obj.WriterName = DBmodel.WriterName;
            
            return View(obj);
            
        }
    }
}
