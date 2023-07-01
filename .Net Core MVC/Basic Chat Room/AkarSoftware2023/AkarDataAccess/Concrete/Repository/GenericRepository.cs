using AkarDataAccess.Abstract;
using AkarEntities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AkarDataAccess.Concrete.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T item)
        {
            _dbContext.Set<T>().Add(item);
        }

        public bool ForceDelete(T item)
        {
            _dbContext.Set<T>().Remove(item);
            return true;
        }

        public bool SafeDelete(T item)
        {
            item.GecerliFlg = false;
            _dbContext.Set<T>().Update(item);
            return true;

        }
        public void Update(T item)
        {
            _dbContext.Set<T>().Update(item);
        }

        public List<T> GetEnum(Expression<Func<T, bool>> where = null, Expression<Func<T, object>>[] include = null)
        {

            var model = _dbContext.Set<T>().AsQueryable();
            if (include != null)
            {
                foreach (var item in include)
                {
                    model = model.Include(item);
                }
            }
            if (where != null)
            {
                model = model.Where(where);
            }
      
            return model.ToList();
        }

        public T Get(Expression<Func<T, bool>> where = null, Expression<Func<T, object>>[] include = null)
        {
            var model = _dbContext.Set<T>().AsQueryable();

            if (where != null)
            {
                model = model.Where(where);
            }
            if (include != null)
            {
                foreach (var item in include)
                {
                    model = model.Include(item);
                }
            }

            return model.FirstOrDefault();
        }
    }
}
