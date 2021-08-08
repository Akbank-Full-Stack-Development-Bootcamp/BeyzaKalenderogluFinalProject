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
    public class EFCategoryRepository : ICategoryRepository
    {
        private BooksDbContext db;
        public EFCategoryRepository(BooksDbContext booksDbContext)
        {            
            db = booksDbContext; 
        }
        public Category Add(Category entity)
        {
            db.Categories.Add(entity);
            // without SaveChanges, it will not insert the db, just hold it in the RAM
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Categories.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetBookListByCategoryId(int categoryId)
        {

            return db.Categories.Include(category => category.Books).Where(category => category.Id == categoryId).FirstOrDefault();
            
        }

        public Category GetById(int id)
        {
            //Find - track the id value, exception occurs - FirstOrDefault prefered
            //return db.Categories.Find(id);
            return db.Categories.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IList<Category> GetWithCriteria(Expression<Func<Category, bool>> criteria)
        {
            return db.Categories.Where(criteria).ToList();
        }

        public IList<Category> GetWithCriteria(Func<Category, bool> criteria)
        {
            return db.Categories.Where(criteria).ToList();
        }

        public Category Update(Category category)
        {
            //Update Categories SET Name = 'Art' WHERE Id = 4 
            //db.Entry - according to id, gets the entity from db and hold in memory
            //State - flag
            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return category;
        }
    }
}
