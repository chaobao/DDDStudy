using System;
using System.Collections.Generic;
using OnlineStore.Domain.BaseModel;

namespace OnlineStore.Domain.Repositories
{
    public interface IRepository<TAggregateRoot>
         where TAggregateRoot : class, IAggregateRoot
    {
        void Add(TAggregateRoot aggregateRoot);

        IEnumerable<TAggregateRoot> GetAll();

        // 根据聚合根的ID值，从仓储中读取聚合根
        TAggregateRoot GetByKey(Guid key);
    }
}
