using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class AddNewCategoryRequest
    {
        [Required(ErrorMessage = "Missing category name! ")]
        public string Name { get; set; }
    }
}
