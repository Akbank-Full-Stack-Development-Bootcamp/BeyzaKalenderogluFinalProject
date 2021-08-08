using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetBookListByAuthorId(int authorId);
        IList<Author> Search(string name);
    }
}
