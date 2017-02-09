using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

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
        T First(Func<T, bool> lambdaExpression);
        List<T> Search(Func<T, bool> lambdaExpression);        
        List<T> GetAll();
    }

    /// <summary>
    /// Responsible for manipulating data from a data source
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// How much Code could a Code Logger Log if a Code Log Could Log Code
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger("Repository.cs");

        /// <summary>
        /// The Database Context
        /// </summary>
        protected DbContext context { get; set; }

        public Repository() 
        {
            context = new SocialNetworkDataModel();
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
            // Adds the specified entity to the relevant DbSet in the DbContext
            context.Set<T>().Add(entity);
            logger.Info("Entity added to database: " + entity.ToString());
        }

        /// <summary>
        /// Removes the data entity from the persistent data context
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(T entity)
        {
            // Removes the specified entity from the relevant DbSet in the DbContext
            context.Set<T>().Remove(entity);
            logger.Info("Entity removed from database: " + entity.ToString());
        }        

        /// <summary>
        /// Returns an List of data entities from the persistent data context based on the lambdaExpression funtion
        /// </summary>
        /// <param name="lambdaExpression"></param>
        /// <returns></returns>
        public virtual List<T> Search(Func<T, bool> lambdaExpression)
        {
            // Returns a collection of entities that match the lambda expression
            return context.Set<T>().Where<T>(lambdaExpression).ToList();
        }

        /// <summary>
        /// Returns the first data entity it can find in the database using the lambdaExpression function
        /// </summary>
        /// <param name="lambdaExpression"></param>
        /// <returns></returns>
        public virtual T First(Func<T, bool> lambdaExpression)
        {
            // Returns the first entity it can find that matches the lambda expression
            return context.Set<T>().FirstOrDefault<T>(lambdaExpression);
        }

        /// <summary>
        /// Returns an List of all the data entities from ther persistent data context
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetAll()
        {
            // Returns all of the set of entities
            return context.Set<T>().ToList();
        }

        /// <summary>
        /// Saves changes made to the data context
        /// </summary>
        public virtual void Save()
        {
            // Saves changes to the database
            context.SaveChanges();
            logger.Info("Changes saved to database");
        }

        /* ---------------------- ASYNCHRONOUS METHODS ---------------------- */
        /*
        /// <summary>
        /// Asynchronously returns an List of data entities from the persistent data context based on the lambdaExpression funtion
        /// </summary>
        /// <param name="lambdaExpression"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> SearchAsync(Expression<Func<T, bool>> lambdaExpression)
        {
            // Returns a collection of entities that match the lambda expression
            return await context.Set<T>().Where<T>(lambdaExpression).ToListAsync();
        }

        /// <summary>
        /// Asynchronously returns the first data entity it can find in the database using the lambdaExpression function
        /// </summary>
        /// <param name="lambdaExpression"></param>
        /// <returns></returns>
        public virtual async Task<T> FirstAsync(Expression<Func<T, bool>> lambdaExpression)
        {
            // Returns the first entity it can find that matches the lambda expression
            return await context.Set<T>().FirstOrDefaultAsync<T>(lambdaExpression);
        }

        /// <summary>
        /// Asynchronously returns an List of all the data entities from ther persistent data context
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<T>> GetAllAsync()
        {
            // Returns all of the set of entities
            return await context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Asynchronously saves changes made to the data context
        /// </summary>
        public virtual async Task SaveAsync()
        {
            // Saves changes to the database
            await context.SaveChangesAsync();
            logger.Info("Changes saved to database");
        }
        */
    }
}
