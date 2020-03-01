using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockBooksWriter : IBooksWriter
    {
        public IEnumerable<BooksWriter> AllBooksWriter
        {
            get
            {
                return new List<BooksWriter>
                {
                    new BooksWriter {id=1, name="Анджей Сапковский"},
                    new BooksWriter {id=2, name="Сергей Лукьяненко"},
                    new BooksWriter {id=3, name="Агата Кристи"},
                    new BooksWriter {id=4, name="Николас Спаркс"}
                };
            }
        }

        public BooksWriter GetObjectWriter(int writerId)
        {
            throw new NotImplementedException();
        }
    }
}
