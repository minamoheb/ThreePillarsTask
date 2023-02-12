using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace RepositoryLayer.Repository
{
    public interface IRepository<T>
    {

        Task<T> Insert(T entity);
        Task<List<T>> InsertRange(List<T> entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);


        Task<T> Find(object id);

        Task<List<T>> GetList(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>,
                IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>,
                IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);

  
        List<T> GetListNotAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>,
            IIncludableQueryable<T, object>> include = null,
        bool disableTracking = true);

    }
}
