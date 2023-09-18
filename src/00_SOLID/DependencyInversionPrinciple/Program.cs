// Zasada odwracania zależności (Dependency Inversion Principle) – DIP
// Wszystkie zależności powinny w jak największym stopniu zależeć od abstrakcji a nie od konkretnego typu.
// Oznacza to, że w kodzie powinny być używane interfejsy lub klasy abstrakcyjne, zamiast bezpośrednio operować na konkretnych klasach.
    

var controller = new ProductController(new CloudProductRepository());
var product = controller.Get(1);

public class ProductController
{
    private readonly IProductRepository repository;

    public ProductController(IProductRepository repository)
    {
        this.repository = repository;
    } 
    
    public Product Get(int id)
    {
        return repository.GetById(id);
    }

    public void Post(Product product) 
    { 
        repository.Add(product);
    }
}


// Szablon
public interface IRepository<T>
{
    T GetById(int id);
    void Add(T product);
}

public interface IProductRepository : IRepository<Product>
{   
}

public class DbProductRepository : IProductRepository
{
    public Product GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Add(Product product)
    {

    }
}

public class CloudProductRepository : IProductRepository
{
    public void Add(Product product)
    {
        Save(product);
    }

    public Product GetById(int id)
    {
        return Load(id);
    }

    private Product Load(int id)
    {
        throw new NotImplementedException();
    }

    private void Save(Product product)
    {

    }
}

public class Product
{

}