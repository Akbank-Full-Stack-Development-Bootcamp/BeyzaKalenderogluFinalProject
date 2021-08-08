using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        private List<User> users = new List<User>
            {
                new User{Email="aaa@xxx.com", Password="123", UserRole="Admin", Username="Beyza"},
                new User{Email="bbb@xxx.com", Password="456", UserRole="User", Username="Deneme"}
            };

        public IList<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetWithCriteria(Func<User, bool> criteria)
        {
            return users.Where(criteria).ToList();
        }

        //public IList<User> GetWithCriteria(Expression<Func<User, bool>> criteria)
        //{
        //    throw new NotImplementedException();
        //}

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
