using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class PublisherBookListResponse
    {
        public IList<BookPublisher> Books { get; set; }
    }
}
