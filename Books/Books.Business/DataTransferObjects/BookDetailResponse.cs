using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class BookDetailResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string CoverImagePath { get; set; }
         public AuthorListResponse Author { get; set; }
    }
}
