using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace Shop.Controllers
{
    public class EditController :Controller
    {
        private readonly IBooks _ibooks;
        private readonly IBooksCategory _ibooksCategory;
        private readonly IBooksWriter _ibooksWriter;
        private readonly IOrderDetails _od;
        private readonly IOrders _order;
        private AppDbContent _appDbContent;        
        
        

        public EditController(IBooks ibooks, IBooksCategory ibooksCategory, IBooksWriter ibooksWriter, IOrderDetails od, IOrders order, AppDbContent appDbContent)
        {
            _ibooks = ibooks;
            _ibooksCategory = ibooksCategory;
            _ibooksWriter = ibooksWriter;            
            _od = od;
            _order = order;
            _appDbContent = appDbContent;            
            

        }

        public ViewResult AllEdit()
        {
            return View();
        }
        public ActionResult EditBook()
        {
            BooksListViewsModels obj = new BooksListViewsModels();
            obj.allBooks = _ibooks.AllBooks;            

            return View(obj);
            
        }

        public ActionResult EditCategory()
        {
            BooksCategoryViewsModel obj = new BooksCategoryViewsModel();
            obj.allBooksCategory = _ibooksCategory.AllBooksCategory;

            return View(obj);
        }

        public ActionResult EditWriter()
        {
            BooksWriterViewsModels obj = new BooksWriterViewsModels();
            obj.allBooksWriter = _ibooksWriter.AllBooksWriter;

            return View(obj);
        }
        public IActionResult DeleteWriter(int id)
        {
            BooksWriter obj = new BooksWriter();
            obj.id = id;            
            _appDbContent.BooksWriter.Remove(obj);
            _appDbContent.SaveChanges();
               
            return RedirectToAction("EditWriter");
        }

        public IActionResult ChangeWriter(int id)
        {
            var DBwriter = _ibooksWriter.GetObjectWriter(id);
            BooksWriter obj = new BooksWriter();
            obj.id = DBwriter.id;
            obj.name = DBwriter.name;

            return View(obj);
        }
        
        public IActionResult Save(BooksWriter writer)
        {
            var obj = _ibooksWriter.GetObjectWriter(writer.id);
            obj.name = writer.name;
            
            _appDbContent.SaveChanges();
            return RedirectToAction("EditWriter");
        }

        public IActionResult NewWriter()
        {
            BooksWriter newobj = new BooksWriter();
            return View(newobj);
        }
        [HttpPost]
        public IActionResult NewWriter(BooksWriter writer)
        {
            _appDbContent.BooksWriter.Add(writer);
            _appDbContent.SaveChanges();
            return RedirectToAction("EditBook");
        }
        public IActionResult NewBook()
        {
            Book newobj = new Book();
            return View(newobj);
        }
        [HttpPost]
        public IActionResult NewBook(Book book)
        {
            _appDbContent.Book.Add(book);
            _appDbContent.SaveChanges();
            return RedirectToAction("EditBook");
        }
        public IActionResult DeleteBook(int id)
        {
            Book obj = new Book();
            obj.id = id;
            _appDbContent.Book.Remove(obj);
            _appDbContent.SaveChanges();

            return RedirectToAction("EditBook");
        }

        public IActionResult ChangeBook(int id)
        {
            var DBbook = _ibooks.GetObjectBook(id);
            Book obj = new Book();
            obj.id = DBbook.id;
            obj.name = DBbook.name;
            obj.longDesc = DBbook.longDesc;
            obj.shortDesc = DBbook.shortDesc;
            obj.price = DBbook.price;
            obj.available = DBbook.available;
            obj.isFavourite = DBbook.isFavourite;
            obj.img = DBbook.img;
            obj.writerId = DBbook.writerId;
            obj.categoryId = DBbook.categoryId;

            return View(obj);
        }

        public IActionResult SaveBook(Book DBbook)
        {
            var obj = _ibooks.GetObjectBook(DBbook.id);
            obj.id = DBbook.id;
            obj.name = DBbook.name;
            obj.longDesc = DBbook.longDesc;
            obj.shortDesc = DBbook.shortDesc;
            obj.price = DBbook.price;
            obj.available = DBbook.available;
            obj.isFavourite = DBbook.isFavourite;
            obj.img = DBbook.img;
            obj.writerId = DBbook.writerId;
            obj.categoryId = DBbook.categoryId;

            _appDbContent.SaveChanges();
            return RedirectToAction("EditBook");
        }
        public IActionResult NewCategory()
        {
            BooksCategory newobj = new BooksCategory();
            return View(newobj);
        }
        [HttpPost]
        public IActionResult NewCategory(BooksCategory category)
        {
            _appDbContent.BooksCategory.Add(category);
            _appDbContent.SaveChanges();
            return RedirectToAction("EditCategory");
        }
        public IActionResult DeleteCategory(int id)
        {
            BooksCategory obj = new BooksCategory();
            obj.id = id;
            _appDbContent.BooksCategory.Remove(obj);
            _appDbContent.SaveChanges();

            return RedirectToAction("EditCategory");
        }

        public IActionResult ChangeCategory(int id)
        {
            var DBcat = _ibooksCategory.GetObjectCategory(id);
            BooksCategory ob = new BooksCategory();
            ob.id = DBcat.id;
            ob.name = DBcat.name;
            ob.desc = DBcat.desc;
            ob.desc = DBcat.desc;
            return View(ob);
        }
        public IActionResult SaveCat(BooksCategory cat)
        {
            var obj = _ibooksCategory.GetObjectCategory(cat.id);
            obj.id = cat.id;
            obj.name = cat.name;
            obj.desc = cat.desc;

            _appDbContent.SaveChanges();
            return RedirectToAction("EditCategory");
        }
        public ActionResult OrderDetails()
        {
            OrderDetailsViewModels obj = new OrderDetailsViewModels();
            obj.allOrderDetails = _od.AllOrderDetails;
            obj.getNewOrder = _od.GetNewOrder;

            return View(obj);

        }
        public IActionResult DeleteOrder(OrderDetails orderDetails)
        {
            
            OrderDetails obj = new OrderDetails();
            obj.id = orderDetails.id;
            obj.orderId = orderDetails.orderId;
            //foreach(var el in _appDbContent.Order)
            // {
            //     if (el.id == obj.orderId)
            //     {

            //         _appDbContent.Order.Remove(el);

            //     }

            // }
            _appDbContent.OrderDetails.Remove(obj);
            _appDbContent.SaveChanges();
            return RedirectToAction("OrderDetails");
        }

        public IActionResult OrderOk(OrderDetails orderdet)
        {
            
            OrderDetails obj = new OrderDetails();
            obj.id = orderdet.id;
            obj.orderId = orderdet.orderId;
            obj.price = orderdet.price;
            obj.status = true;
            _appDbContent.OrderDetails.Remove(orderdet);
            _appDbContent.OrderDetails.Add(obj);
            _appDbContent.SaveChanges();
            return RedirectToAction("OrderDetails");
        }
    }
}
