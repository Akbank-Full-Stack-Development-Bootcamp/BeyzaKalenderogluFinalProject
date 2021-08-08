using Books.DataAccess.Data;
using Books.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private BooksDbContext db;
        public EFUserRepository(BooksDbContext booksDbContext)
        {
            db = booksDbContext;
        }
        public User Add(User entity)
        {
            db.Users.Add(entity);
            // without SaveChanges, it will not insert the db, just hold it in the RAM
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Users.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetById(int id)
        {
            return db.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public IList<User> GetWithCriteria(Expression<Func<User, bool>> criteria)
        {
            return db.Users.Where(criteria).ToList();
        }

        public IList<User> GetWithCriteria(Func<User, bool> criteria)
        {
            return db.Users.Where(criteria).ToList();
        }

        public User Update(User user)
        {
            db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return user;
        }
    }
}
