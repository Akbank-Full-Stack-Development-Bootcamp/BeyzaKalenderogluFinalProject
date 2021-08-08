using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class AddNewBookRequest
    {
        [Required(ErrorMessage = "Missing titlt! ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Missing price! ")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Missing book cover image path! ")]
        public string CoverImagePath { get; set; }
        [Required(ErrorMessage = "Missing category id! ")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Missing author id! ")]
        public int AuthorId { get; set; }
    }
}
