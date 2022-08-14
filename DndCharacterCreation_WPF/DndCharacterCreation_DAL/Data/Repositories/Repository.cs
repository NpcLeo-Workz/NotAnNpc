using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DndCharacterCreation_DAL.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected DbContext Context { get; }

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public void Edit(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Download()
        {
            return Context.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public IEnumerable<T> Download(Expression<Func<T, bool>> Req,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (Req != null)
            {
                query = query.Where(Req);
            }
            return query.ToList();
        }

        public IEnumerable<T> Download(Expression<Func<T, bool>> voorwaarden)
        {
            return Download(voorwaarden, null).ToList();
        }

        public IEnumerable<T> Download(params Expression<Func<T, object>>[] includes)
        {
            return Download(null, includes).ToList();
        }
    }
}

