using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    // Category is an entity and its proved by Id
    public class Category : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field cannot be null.")]
        public string Name { get; set; }

        // All books in one category
        public virtual IList<Book> Books { get; set; } = new List<Book>();

        public Category() : base()
        {
            this.Books = new List<Book>();
        }
    }
}
