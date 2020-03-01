using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface IBooks
    {
        IEnumerable<Book> AllBooks { get;}
        IEnumerable<Book> GetFavBooks { get; }
        Book GetObjectBook(int bookId);
    }
}
