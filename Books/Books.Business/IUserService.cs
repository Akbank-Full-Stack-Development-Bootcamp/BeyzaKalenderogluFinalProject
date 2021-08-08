using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public interface IUserService
    {
        User GetUser(string userName, string password);
        IList<User> GetAllUsers();
    }
}
