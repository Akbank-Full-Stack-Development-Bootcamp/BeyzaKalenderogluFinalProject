using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class EditCategoryRequest
    {
        //DTO - do not want to get book list
        public int Id { get; set; }
        [Required(ErrorMessage = "Missing category name!")]
        public string Name { get; set; }
    }
}
