using OnlineStore.Domain.Repositories;

namespace OnlineStore.Repositories.EntityFramework
{
    public interface IEntityFrameworkRepositoryContext: IRepositoryContext
    {
        OnlineStoreDbContext DbContex { get; }
    }
}
