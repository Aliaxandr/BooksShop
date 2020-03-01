using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewsModels
{
    public class BooksListViewsModels
    {
        public IEnumerable<Book> allBooks { get; set; }
        public Book oneBook { get; set; }
        public string bookCategory { get; set; }

    }
}
