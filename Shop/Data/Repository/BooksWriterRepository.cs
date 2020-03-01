using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class BooksWriterRepository : IBooksWriter
    {
        private AppDbContent appDbContent;

        public BooksWriterRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<BooksWriter> AllBooksWriter => appDbContent.BooksWriter;

        public BooksWriter GetObjectWriter(int writerId) => appDbContent.BooksWriter.FirstOrDefault(c => c.id == writerId);


    }
}
