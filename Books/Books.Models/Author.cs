using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string About { get; set; }

        public string ImgPath { get; set; }

        // All books belongs to one author
        public virtual IList<Book> Books { get; set; }

        public Author() : base()
        {
            this.Books = new List<Book>();
        }
    }
}
