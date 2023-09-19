using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProxyPattern
{
    // Pośrednik (Proxy)

    public class CacheProductRepository : CacheEntityRepository<Product>, IProductRepository
    {
        public CacheProductRepository(IProductRepository productRepository) : base(productRepository)
        {
        }
    }

    public class CacheServiceRepository : CacheEntityRepository<Service>, IServiceRepository
    {
        public CacheServiceRepository(IServiceRepository productRepository) : base(productRepository)
        {
        }
    }

}
