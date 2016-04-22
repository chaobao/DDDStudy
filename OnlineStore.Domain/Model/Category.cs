using System;

namespace OnlineStore.Domain.Model
{
    public class Category : AggregateRoot
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
