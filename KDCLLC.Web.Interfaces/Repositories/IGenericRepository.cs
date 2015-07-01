using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KDCLLC.Web.Interfaces.Repositories
{
    public interface IGenericRepository<TObject> where TObject : class
    {
        #region Get Methods
        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        /// 
        TObject Get(int id);

        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        Task<TObject> GetAsync(int id);

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        ICollection<TObject> GetAll();

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        Task<ICollection<TObject>> GetAllAsync();

        /// <summary>
        /// Get a collection of objects in the database based on filter and properties search
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        ICollection<TObject> GetAll(Expression<Func<TObject, bool>> filter = null, Func<IQueryable<TObject>, IOrderedQueryable<TObject>> orderBy = null, string includeProperties = "");

        /// <summary>
        /// Get async a collection of objects in the database based on filter and properties search
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<ICollection<TObject>> GetAllAnsync(Expression<Func<TObject, bool>> filter = null, Func<IQueryable<TObject>, IOrderedQueryable<TObject>> orderBy = null, string includeProperties = "");

        ICollection<TObject> GetWithRawSql(string query, params object[] parameters);

        Task<ICollection<TObject>> GetWithRawSqlAnsync(string query, params object[] parameters);

        ICollection<TObject> GetAll(params Expression<Func<TObject, object>>[] navigationProperties);

        Task<ICollection<TObject>> GetAllAnsync(params Expression<Func<TObject, object>>[] navigationProperties);

        TObject GetSingle(Expression<Func<TObject, bool>> where, params Expression<Func<TObject, object>>[] navigationProperties);

        Task<TObject> GetSingleAnsync(Expression<Func<TObject, bool>> where, params Expression<Func<TObject, object>>[] navigationProperties);


        #endregion

        #region Find Methods
        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="match">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        TObject Find(Expression<Func<TObject, bool>> match);

        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        Task<TObject> FindAsync(Expression<Func<TObject, bool>> match);

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        ICollection<TObject> FindAll(Expression<Func<TObject, bool>> match);

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match);
        #endregion

        #region Add Methods
        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        TObject Add(TObject t);

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        Task<TObject> AddAsync(TObject t);

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        IEnumerable<TObject> AddAll(IEnumerable<TObject> tList);

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        Task<IEnumerable<TObject>> AddAllAsync(IEnumerable<TObject> tList);

        #endregion

        #region Update Methods
        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="updated">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        TObject Update(TObject updated, int key);

        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="updated">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        Task<TObject> UpdateAsync(TObject updated, int key);
        #endregion

        #region Delete
        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to delete</param>
        void Delete(TObject t);

        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The object to delete</param>
        Task<int> DeleteAsync(TObject t); 
        #endregion

        #region Count Methods
        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        int Count();

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        Task<int> CountAsync(); 
        #endregion

    }
}
