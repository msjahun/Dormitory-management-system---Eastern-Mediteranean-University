using Dau.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Data.Repository
{
    public class Repository<T> :  IRepository<T> where T : BaseEntity
    {
        private readonly Fees_and_facilitiesContext _dbContext;

        public Repository(Fees_and_facilitiesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IEnumerable<T> Include(string path)
        {
            return _dbContext.Set<T>().Include(path).AsEnumerable();
        }

        public virtual T GetById(long id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> List()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }



        public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                   .Where(predicate)
                   .AsEnumerable();
        }

        public void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
