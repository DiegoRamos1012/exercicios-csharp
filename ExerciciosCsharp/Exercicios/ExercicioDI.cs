namespace ExerciciosCsharp.Exercicios;

public class ExercicioDi
{
    private static readonly ExercicioLinq ExercicioLinq = new();

    public interface IProductRepository
    {
        List<Product> GetAll();
    }

    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAll()
        {
            return ExercicioLinq.Products;
        }
    }

    public class ProductService(IProductRepository product)
    {
        public List<Product> GetAllProducts()
        {
            return product.GetAll();
        }
    }

    public void Execute()
    {
        var repository = new ProductRepository();
        var service = new ProductService(repository);

        foreach (var product in service.GetAllProducts())
        {
            Console.WriteLine($"- {product.Name}");
        }
    }
}