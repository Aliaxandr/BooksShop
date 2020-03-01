using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewsModels
{
    public class HomeViewsModels : Controller
    {
        public IEnumerable<Book> favBooks { get; set; }
    }
}
