using Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria.Services
{
    public interface IBooksDataService
    {
        IEnumerable<Book> GetBooks();
        //Book GetBook();
        void InsertBook(string title, string author, string date, bool done);
    }
}
