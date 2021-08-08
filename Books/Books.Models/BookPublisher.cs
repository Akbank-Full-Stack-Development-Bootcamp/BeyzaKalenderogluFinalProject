using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class BookPublisher
    {
        public int BookId { get; set; }
        public int PublisherId { get; set; }

        public string Description { get; set; }


        //which Book published by which Publisher
        public virtual Book Book { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
