using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KDCLLC.Web.Data;
using KDCLLC.Web.Interfaces.Repositories;

namespace KDCLLC.Web.Repositories.Base
{
    public class GenericRepository<TObject> : IGenericRepository<TObject> where TObject : class
    {
        protected DataContext context;
        protected DbSet<TObject> dbSet;

        /// <summary>
        /// The constructor requires an open DataContext to work with
        /// </summary>
        /// <param name="context">An open DataContext</param>
        public GenericRepository(DataContext ctx)
        {
            this.context = ctx;
            this.dbSet = this.context.Set<TObject>();
        }

        #region Get Methods
        public virtual TObject Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual async Task<TObject> GetAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual ICollection<TObject> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual async Task<ICollection<TObject>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        } 
        #endregion

        #region Find
        public virtual TObject Find(Expression<Func<TObject, bool>> match)
        {
            return dbSet.SingleOrDefault(match);
        }

        public virtual async Task<TObject> FindAsync(Expression<Func<TObject, bool>> match)
        {
            return await dbSet.SingleOrDefaultAsync(match);
        }

        public virtual ICollection<TObject> FindAll(Expression<Func<TObject, bool>> match)
        {
            return dbSet.Where(match).ToList();
        }

        public virtual async Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match)
        {
            return await dbSet.Where(match).ToListAsync();
        } 
        #endregion
        
        #region Add Methods
        public virtual TObject Add(TObject t)
        {
            dbSet.Add(t);
            context.SaveChanges();
            return t;
        }

        public virtual async Task<TObject> AddAsync(TObject t)
        {
            dbSet.Add(t);
            await context.SaveChangesAsync();
            return t;
        }

        public virtual IEnumerable<TObject> AddAll(IEnumerable<TObject> tList)
        {
            dbSet.AddRange(tList);
            context.SaveChanges();
            return tList;
        }

        public virtual async Task<IEnumerable<TObject>> AddAllAsync(IEnumerable<TObject> tList)
        {
            dbSet.AddRange(tList);
            await context.SaveChangesAsync();
            return tList;
        } 
        #endregion

        #region Update Methods

        public virtual TObject Update(TObject updated, int key)
        {
            if (updated == null)
                return null;

            TObject existing = dbSet.Find(key);
            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(updated);
                context.SaveChanges();
            }
            return existing;
        }

        public virtual async Task<TObject> UpdateAsync(TObject updated, int key)
        {
            if (updated == null)
                return null;

            TObject existing = await dbSet.FindAsync(key);
            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(updated);
                await context.SaveChangesAsync();
            }
            return existing;
        } 
        #endregion
        
        #region Delete
        public virtual void Delete(TObject t)
        {
            if (context.Entry(t).State == EntityState.Detached)
                dbSet.Attach(t);

            dbSet.Remove(t);
            context.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(TObject t)
        {
            dbSet.Remove(t);
            return await context.SaveChangesAsync();
        } 
        #endregion
        
        #region Count Methods
        public virtual int Count()
        {
            return dbSet.Count();
        }

        public virtual async Task<int> CountAsync()
        {
            return await dbSet.CountAsync();
        } 
        #endregion



        public virtual ICollection<TObject> GetAll(Expression<Func<TObject, bool>> filter = null, Func<IQueryable<TObject>, 
                                           IOrderedQueryable<TObject>> orderBy = null, string includeProperties = "")
        {
             return this.GetAllQuery(filter, orderBy, includeProperties).ToList();
        }

        public virtual async Task<ICollection<TObject>> GetAllAnsync(Expression<Func<TObject, bool>> filter = null,
                                                      Func<IQueryable<TObject>, IOrderedQueryable<TObject>> orderBy = null, string includeProperties = "")
        {

            return await this.GetAllQuery(filter, orderBy, includeProperties).ToListAsync();
        }

        private IQueryable<TObject> GetAllQuery(Expression<Func<TObject, bool>> filter = null, Func<IQueryable<TObject>,
                                           IOrderedQueryable<TObject>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TObject> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return  orderBy(query);
            else
                return query;
        }




        public virtual ICollection<TObject> GetWithRawSql(string query, params object[] parameters)
        {
            return this.GetWithRawSqlQuery(query, parameters).ToList();
        }

        public virtual async Task<ICollection<TObject>> GetWithRawSqlAnsync(string query, params object[] parameters)
        {
            return await this.GetWithRawSqlQuery(query, parameters).ToListAsync();
        }

        private DbSqlQuery<TObject> GetWithRawSqlQuery(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters);
        }



        public virtual ICollection<TObject> GetAll(params Expression<Func<TObject, object>>[] navigationProperties)
        {
            return this.GetAllQuery2(navigationProperties).ToList();
        }

        public virtual async Task<ICollection<TObject>> GetAllAnsync(params Expression<Func<TObject, object>>[] navigationProperties)
        {
            return await this.GetAllQuery2(navigationProperties).ToListAsync();
        }

        private IQueryable<TObject> GetAllQuery2(params Expression<Func<TObject, object>>[] navigationProperties)
        {
            IQueryable<TObject> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TObject, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TObject, object>(navigationProperty);

            return dbQuery.AsNoTracking();
        }



        public virtual TObject GetSingle(Expression<Func<TObject, bool>> where, params Expression<Func<TObject, object>>[] navigationProperties)
        {
            IQueryable<TObject> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TObject, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TObject, object>(navigationProperty);


            return  dbQuery.FirstOrDefault(where);
        }

        public virtual async Task<TObject> GetSingleAnsync(Expression<Func<TObject, bool>> where, params Expression<Func<TObject, object>>[] navigationProperties)
        {

            IQueryable<TObject> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TObject, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TObject, object>(navigationProperty);


            return await dbQuery.FirstOrDefaultAsync(where);

            
        }

        private IQueryable<TObject> GetSingleQuery(params Expression<Func<TObject, object>>[] navigationProperties)
        {
          
            IQueryable<TObject> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TObject, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TObject, object>(navigationProperty);


            return dbQuery;
        }

    }
}
