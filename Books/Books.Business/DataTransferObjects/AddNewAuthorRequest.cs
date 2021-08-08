using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class AddNewAuthorRequest
    {
        [Required(ErrorMessage = "Missing name! ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Missing lastname! ")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Missing about info! ")]
        public string About { get; set; }
        public string ImgPath { get; set; }

    }
}
