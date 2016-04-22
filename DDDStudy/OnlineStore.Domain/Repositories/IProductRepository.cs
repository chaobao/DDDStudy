using System.Collections.Generic;
using OnlineStore.Domain.Model;

namespace OnlineStore.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetNewProducts(int count);
    }
}
