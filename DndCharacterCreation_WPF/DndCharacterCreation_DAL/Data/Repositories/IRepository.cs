using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DndCharacterCreation_DAL.Data.Repositories
{
    public interface IRepository<T>
        where T : class, new()
    {
        IEnumerable<T> Download();

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        IEnumerable<T> Download(Expression<Func<T, bool>> voorwaarden);

        IEnumerable<T> Download(params Expression<Func<T, object>>[] includes);

        IEnumerable<T> Download(Expression<Func<T, bool>> voorwaarden,
            params Expression<Func<T, object>>[] includes);
    }

}
