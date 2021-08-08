using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class EditPublisherRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Missing publisher name!")]
        public string Name { get; set; }
    }
}
