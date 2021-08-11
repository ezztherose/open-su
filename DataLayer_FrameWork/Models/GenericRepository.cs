using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer_FrameWork.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DatabaseContext Context { get; set; }

        // Constructor
        public GenericRepository(DatabaseContext context)
        {
            Context = context;
        }

        // Methods
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Remove(int id)
        {
            Context.Set<T>().Remove(Get(id));
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().SingleOrDefault(predicate);
        }

        public void Update(T entity, int id)
        {
            T existing = Context.Set<T>().Find(id);

            if (existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(entity);
                Context.SaveChanges();
            }
        }
        
    }
}
