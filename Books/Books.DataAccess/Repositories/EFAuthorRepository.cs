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
    public class EFAuthorRepository : IAuthorRepository
    {
        private BooksDbContext db;
        public EFAuthorRepository(BooksDbContext booksDbContext)
        {
            db = booksDbContext;
        }
        public Author Add(Author entity)
        {
            db.Authors.Add(entity);
            // without SaveChanges, it will not insert the db, just hold it in the RAM
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Authors.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<Author> GetAll()
        {
            return db.Authors.ToList();
        }

        public Author GetBookListByAuthorId(int authorId)
        {
            return db.Authors.Include(author => author.Books).Where(author => author.Id == authorId).FirstOrDefault();
        }

        public Author GetById(int id)
        {
            return db.Authors.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IList<Author> GetWithCriteria(Expression<Func<Author, bool>> criteria)
        {
            return db.Authors.Where(criteria).ToList();
        }

        public IList<Author> GetWithCriteria(Func<Author, bool> criteria)
        {
            return db.Authors.Where(criteria).ToList();
        }

        public IList<Author> Search(string name)
        {
            IQueryable<Author> query = db.Authors;

            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(name))
            {
                query = query.Where(author => author.Name.Contains(name) || author.Lastname.Contains(name));
            }

            return query.ToList();
        }

        public Author Update(Author author)
        {
            db.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return author;
        }
    }
}
