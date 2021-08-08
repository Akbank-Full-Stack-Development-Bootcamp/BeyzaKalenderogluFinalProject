using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is missing")]
        public string Username { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is missing")]
        public string Password { get; set; }

        public string UserRole { get; set; }

    }
}
