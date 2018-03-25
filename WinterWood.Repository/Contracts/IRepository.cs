using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WinterWood.Repository.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllInvoices();
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
    }
}
