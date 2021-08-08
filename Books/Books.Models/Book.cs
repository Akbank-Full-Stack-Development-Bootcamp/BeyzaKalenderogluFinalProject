 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Book title field cannot be empty!")]
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string CoverImagePath { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        //Navigation Property
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        public virtual IList<BookPublisher> Publishers { get; set; }

        public Book() : base()
        {
            this.Publishers = new List<BookPublisher>();
        }
    }
}
