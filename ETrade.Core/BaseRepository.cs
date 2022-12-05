using ETrade.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        ETradeContext _db;
        public BaseRepository(ETradeContext db)
        {
            _db = db;
        }

        public bool Add(T entity)
        {
            try
            {
                Set().Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                Set().Remove(Find(Id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int Id1, int Id2)
        {
            try
            {
                Set().Remove(Find(Id1, Id2));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Find(int Id)
        {
            return Set().Find(Id);
        }

        public T Find(int Id1, int Id2)
        {
            return Set().Find(Id1, Id2);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return Set().FirstOrDefault(filter);
        }

        public List<T> List(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? Set().ToList() : Set().Where(filter).ToList();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
