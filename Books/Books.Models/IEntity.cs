using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    //Entities in database are implemented by IEntity  
    public interface IEntity
    {
        // Each entity has id.
        int Id { get; set; }
    }
}
