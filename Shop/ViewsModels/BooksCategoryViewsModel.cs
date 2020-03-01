using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewsModels
{
    public class BooksCategoryViewsModel
    {
        public IEnumerable<BooksCategory> allBooksCategory { get; set; }
    }
}
