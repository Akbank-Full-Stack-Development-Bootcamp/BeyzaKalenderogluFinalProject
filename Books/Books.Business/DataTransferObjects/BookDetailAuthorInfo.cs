using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class BookDetailAuthorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public string About { get; set; }
    }
}
