using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class CategoryBookListResponse
    {
        public IList<BookListResponse> Books { get; set; }
    }
}
