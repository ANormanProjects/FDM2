using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    /// <summary>
    /// Generic Interface for Implementing a Data Repository
    /// </summary>
    public interface IRepository<T>
    {
        void Save();
        void Insert(T entity);
        void Remove(T entity);
        void Update(T entity, Func<T, bool> predicate);
        T First(Func<T, bool> predicate);
        IEnumerable<T> Search(Func<T, bool> predicate);        
        IEnumerable<T> GetAll();
    }

    /// <summary>
    /// Responsible for manipulating data from a data source
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext context { get; set; }

        public Repository()
        {
            
        }

        public Repository(DbContext context)
        {
            this.context = context;
        }


        /// <summary>
        /// Adds the data entity to the persistent data context
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(T entity)
        {
            context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Removes the data entity from the persistent data context
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Updates a data entity in the persistent data context with the data in another data entity 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="predicate"></param>
        public virtual void Update(T entity, Func<T, bool> predicate)
        {
            IEnumerable<T> entitiesToUpdate = context.Set<T>().Where<T>(predicate);

            if (entitiesToUpdate.Count() != 0)
            {
                foreach (T t in entitiesToUpdate)
                {
                    context.Entry(t).CurrentValues.SetValues(entity);
                }
            }
        }

        /// <summary>
        /// Returns an IEnumerable of data entities from the persistent data context based on the predicate funtion
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> Search(Func<T, bool> predicate)
        {
            return context.Set<T>().Where<T>(predicate);
        }

        /// <summary>
        /// Returns the first data entity it can find in the database using the predicate function
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T First(Func<T, bool> predicate)
        {
            return context.Set<T>().FirstOrDefault<T>(predicate);
        }

        /// <summary>
        /// Returns an IEnumerable of all the data entities from ther persistent data context
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        /// <summary>
        /// Saves changes made to the data context
        /// </summary>
        public virtual void Save()
        {
            context.SaveChanges();
        }
    }
}
