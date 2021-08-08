using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    // we can write any other works spesific to category
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetBookListByCategoryId(int categoryId);
    }
}
