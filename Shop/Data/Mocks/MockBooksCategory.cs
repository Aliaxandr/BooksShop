using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockBooksCategory : IBooksCategory
    {
        public IEnumerable<BooksCategory> AllBooksCategory
        {
            get
            {
                return new List<BooksCategory>
                {
                    new BooksCategory {id=1, name="Фантастика", desc="Различные фантастические произведения"},
                    new BooksCategory {id=2, name="Роман", desc="Про любовь, дружбу, отношения"},
                    new BooksCategory {id=3, name="Детектив", desc="Загадочные преступления, невероятные расследования, головоломки"}
                };
            }
        }

        public BooksCategory GetObjectCategory(int catid)
        {
            throw new NotImplementedException();
        }
    }
}
