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
    public class EFBookRepository : IBookRepository
    {
        private BooksDbContext db;
        public EFBookRepository(BooksDbContext booksDbContext)
        {
            db = booksDbContext;
        }
        public Book Add(Book entity)
        {
            db.Books.Add(entity);
            // without SaveChanges, it will not insert the db, just hold it in the RAM
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Books.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<Book> GetAll()
        {
            //return db.Books.ToList();
            return db.Books.Include(book => book.Author).ToList();
        }

        public Book GetBookDetail(int id)
        {
            return db.Books.Include(book => book.Author).Where(book => book.Id == id).FirstOrDefault();
        }

        public Book GetById(int id)
        {
            return db.Books.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public IList<Book> GetWithCriteria(Expression<Func<Book, bool>> criteria)
        {
            return db.Books.Where(criteria).ToList();
        }

        public IList<Book> GetWithCriteria(Func<Book, bool> criteria)
        {
            return db.Books.Where(criteria).ToList();
        }

        public IList<Book> Search(string title)
        {
            IQueryable<Book> query = db.Books;

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(book => book.Title.Contains(title));
            }
            else
            {
                query = null;
            }

            return query.ToList();
        }

        public Book Update(Book book)
        {
            db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return book;
        }
    }
}
