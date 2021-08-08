using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class EditBookRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Book title field cannot be empty!")]
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string CoverImagePath { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
