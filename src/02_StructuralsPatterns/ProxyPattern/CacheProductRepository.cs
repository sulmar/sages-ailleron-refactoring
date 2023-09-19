using System;
using System.Collections.ObjectModel;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;

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
