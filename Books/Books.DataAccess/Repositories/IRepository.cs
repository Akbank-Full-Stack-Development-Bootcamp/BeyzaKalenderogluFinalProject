using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    //TEntity - Entity type will be used, TEntity object implement IEntity
    //new() - able to create instance 
    public interface IRepository<TEntity> where TEntity : IEntity, new()
    {
        // SELECT
        IList<TEntity> GetAll();

        // SELECT by ID
        TEntity GetById(int id);

        // for WHERE criteria 
        IList<TEntity> GetWithCriteria(Func<TEntity, bool> criteria);

        // Returns the added value
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
