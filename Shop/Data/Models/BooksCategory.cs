using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class BooksCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public List<Book> books { get; set; }
    }
}
