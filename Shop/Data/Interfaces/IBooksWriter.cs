using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface IBooksWriter
    {
       IEnumerable<BooksWriter> AllBooksWriter { get; }

        BooksWriter GetObjectWriter(int writerId);
    }
}
