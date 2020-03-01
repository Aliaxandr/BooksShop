using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class BookRepository : IBooks
    {
        private AppDbContent appDbContent;

        public BookRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Book> AllBooks => appDbContent.Book.Include(c => c.Category).Include(c => c.Writer);

        public IEnumerable<Book> GetFavBooks => appDbContent.Book.Where(p => p.isFavourite==true).Include(c => c.Category);

        public Book GetObjectBook(int bookId) => appDbContent.Book.FirstOrDefault(c => c.id == bookId);
       
    }
}
