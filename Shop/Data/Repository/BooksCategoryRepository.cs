using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class BooksCategoryRepository : IBooksCategory
    {
        private AppDbContent appDbContent;

        public BooksCategoryRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<BooksCategory> AllBooksCategory => appDbContent.BooksCategory;

        public BooksCategory GetObjectCategory(int catid) => appDbContent.BooksCategory.FirstOrDefault(c => c.id == catid);

       
    }
}
