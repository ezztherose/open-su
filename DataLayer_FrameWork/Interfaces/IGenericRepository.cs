using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(int id);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity, int id);
    }
}
