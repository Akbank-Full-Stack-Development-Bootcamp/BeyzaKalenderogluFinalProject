using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class CategoryListResponse
    {
        //DTO - do not want to get book list
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
