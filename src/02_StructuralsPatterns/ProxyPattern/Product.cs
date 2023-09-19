using System;

namespace ProxyPattern
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int CacheHit { get; set; }

        protected BaseEntity(int id)
        {
            Id = id;
        }
    }

    public class Product : BaseEntity
    {
        public Product(int id, string name, decimal unitPrice)
            : base(id)

        {
            Name = name;
            UnitPrice = unitPrice;
        }

        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

    }

    public class Service : BaseEntity
    {
        public Service(int id) : base(id)
        {
        }

        public TimeSpan Duration { get; set; }
    }


}
