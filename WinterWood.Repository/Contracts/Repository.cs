using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WinterWood.Entities;

namespace WinterWood.Repository.Contracts
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        WoodContext context;
        private DbSet<TEntity> DbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected WoodContext DbContext
        {
            get { return context ?? (context = DbFactory.DbContext()); }
        }

        
        public Repository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            DbSet = DbContext.Set<TEntity>();
        }

       public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate) 
            => DbSet.Where(predicate).ToList();

        public IEnumerable<TEntity> GetAllInvoices()
        {
            return DbContext.Set<TEntity>();
        }

        
    }

}
