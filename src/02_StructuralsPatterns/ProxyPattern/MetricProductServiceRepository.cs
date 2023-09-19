namespace ProxyPattern
{
    public class MetricProductServiceRepository : IProductRepository
    {
        private readonly IProductRepository productRepository;

        public int TotalBytes { get; private set; }

        public MetricProductServiceRepository(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Get(int id)
        {
            var product = productRepository.Get(id);

            if (product!=null)
            {
                TotalBytes += product.ToString().Length;
            }
            

            return product;
        }
    }
}
