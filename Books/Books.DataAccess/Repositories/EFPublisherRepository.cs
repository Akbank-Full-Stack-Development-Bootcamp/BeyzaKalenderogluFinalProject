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
    public class EFPublisherRepository : IPublisherRepository
    {
        private BooksDbContext db;
        public EFPublisherRepository(BooksDbContext booksDbContext)
        {
            db = booksDbContext;
        }
        public Publisher Add(Publisher entity)
        {
            db.Publishers.Add(entity);
            // without SaveChanges, it will not insert the db, just hold it in the RAM
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Publishers.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<Publisher> GetAll()
        {
            return db.Publishers.ToList();
        }

        public IList<Book> GetBookListByPublisherId(int publisherId)
        {
            var books = db.Publishers.Join(db.BookPublisher, publisher => publisher.Id, bookPublisher => bookPublisher.PublisherId,
                                       (p, bp) => new
                                       {
                                           publisher = p,
                                           bookPublisher = bp
                                       }).Join(db.Books, t => t.bookPublisher.BookId, book => book.Id,(bp,b) => new 
                                       {
                                           publisher = bp.publisher,
                                           book = b,
                                           bookPublisher = bp.bookPublisher
                                       }).Where(x => x.publisher.Id == publisherId).Select(x => new Book {
                                       
                                           Title = x.book.Title,
                                           Id = x.book.Id,
                                           CoverImagePath = x.book.CoverImagePath,
                                           Price = x.book.Price

                                       }).ToList();
            return books;
        }

        public Publisher GetById(int id)
        {
            return db.Publishers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public IList<Publisher> GetWithCriteria(Expression<Func<Publisher, bool>> criteria)
        {
            return db.Publishers.Where(criteria).ToList();
        }

        public IList<Publisher> GetWithCriteria(Func<Publisher, bool> criteria)
        {
            return db.Publishers.Where(criteria).ToList();
        }

        public IList<Publisher> Search(string name)
        {
            IQueryable<Publisher> query = db.Publishers;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(publisher => publisher.Name.Contains(name));
            }

            return query.ToList();
        }

        public Publisher Update(Publisher publisher)
        {
            db.Entry(publisher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return publisher;
        }
    }
}
