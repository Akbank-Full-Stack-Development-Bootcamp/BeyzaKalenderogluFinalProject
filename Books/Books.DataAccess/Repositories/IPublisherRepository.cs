using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        IList<Book> GetBookListByPublisherId(int publisherId);
        IList<Publisher> Search(string name);
    }
}
