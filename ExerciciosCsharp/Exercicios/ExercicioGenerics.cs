namespace ExerciciosCsharp.Exercicios;

public class ExercicioGenerics
{
    
    private static readonly
        ExercicioLinq _products = new();

    public class Repository<T> where T : IWithStock
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
        
        public List<T> EstoqueBaixo()
        {
            return _items.Where(item => item.CurrentStock < 5).ToList();
        }
    }

    public interface IWithStock
    {
        int CurrentStock { get; }
    }

    public T Bigger<T>(T a, T b) where T : IComparable<T>
    {
        if (a.CompareTo(b) > 0)
        {
            return a;
        }

        return b;
    }
    
    

    public void Executar()
    {
        var productRepository = new Repository<Product>();
        /*
        Como Repository<T> agora exige IWithStock, a linha abaixo não irá compilar 
        var repositoryString = new Repository<string>(); 
        */

        foreach (var produto in _products.Products.Take(3))
        {
            productRepository.add(produto);
        }
        
        /*
        repositoryString.add("Olá");
        repositoryString.add("Até mais");
        */
    }

    public void ExecuteBiggerMethod()
    {
        Console.WriteLine(Bigger(2, 3));
    }
    
    
}