namespace ExerciciosCsharp.Exercicios;

public class ExercicioGenerics
{
    
    private static readonly
        ExercicioLinq _products = new();
    public class Repository<T>
    { 
        private readonly List<T> _items = new();

        public void add(T item)
        {
            _items.Add(item);
        }

        public void remove(T item)
        {
            _items.Remove(item);
        }

        public List<T> list()
        {
            return _items;
        }

        public int count()
        {
            return _items.Count;
        }
    }

    public void Executar()
    {
        var productRepository = new Repository<Product>();
        var repositoryString = new Repository<string>();

        foreach (var produto in _products.Products.Take(3))
        {
            productRepository.add(produto);
        }
        
        repositoryString.add("Olá");
        repositoryString.add("Até mais");
    }
}