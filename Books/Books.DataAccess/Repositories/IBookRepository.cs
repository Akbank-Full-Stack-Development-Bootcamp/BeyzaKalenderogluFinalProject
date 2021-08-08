using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetBookDetail(int id);
        IList<Book> Search(string title);
    }
}