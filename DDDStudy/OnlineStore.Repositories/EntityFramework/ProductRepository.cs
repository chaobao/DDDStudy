using System;
using System.Collections.Generic;
using System.Linq;
using OnlineStore.Domain.Model;
using OnlineStore.Domain.Repositories;

namespace OnlineStore.Repositories.EntityFramework
{
    public class ProductRepository : IProductRepository
    {
        #region Private Fields

        private readonly IEntityFrameworkRepositoryContext _efContext;

        #endregion
        #region Public Properties

        public IEntityFrameworkRepositoryContext EfContext
        {
            get { return this._efContext; }
        }

        #endregion

        #region Ctor

        public ProductRepository(IRepositoryContext context)
        {
            var efContext = context as IEntityFrameworkRepositoryContext;
            if (efContext != null)
                this._efContext = efContext;
        }

        #endregion
        public IEnumerable<Product> GetNewProducts(int count = 0)
        {
            var ctx = this.EfContext.DbContex as OnlineStoreDbContext;
            if (ctx == null)
                return null;
            var query = from p in ctx.Products
                        where p.IsNew == true
                        select p;
            if (count == 0)
                return query.ToList();
            else
                return query.Take(count).ToList();
        }

        public void Add(Product aggregateRoot)
        {
            this.EfContext.DbContex.Products.Add(aggregateRoot);
        }

        public IEnumerable<Product> GetAll()
        {
            var ctx = this.EfContext.DbContex as OnlineStoreDbContext;
            if (ctx == null)
                return null;
            var query = from p in ctx.Products
                        select p;
            return query.ToList();
        }

        public Product GetByKey(Guid key)
        {
            return EfContext.DbContex.Products.First(p => p.Id == key);
        }
    }
}
