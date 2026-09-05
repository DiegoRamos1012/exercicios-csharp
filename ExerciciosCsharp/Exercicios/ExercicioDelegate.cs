namespace ExerciciosCsharp.Exercicios;

public class ExercicioDelegate
{
// Delegate para validações que recebem uma string e retornam bool.
    private delegate bool Validator(string target);
    private static bool IsValidEmail(string email) =>
        email.Contains('@');

    private static bool IsLongerThan3Characters(string target) =>
        target.Length > 3;

    private static bool IsNoSpaces(string target) =>
        !target.Contains(' ');

    private static bool Test(string value, Validator validator)
    {
        return validator(value);
    }

/*
public void Execute()
{
    Console.WriteLine(Test("teste@email.com", IsValidEmail));
    Console.WriteLine(Test("teste", IsLongerThan3Characters));
    Console.WriteLine(Test("teste sem espaco", IsNoSpaces));
}
*/

// Instância da classe que contém a lista de produtos.
    private static readonly ExercicioLinq _products = new();

// Delegate que recebe uma lista de produtos e retorna uma lista filtrada.
    private delegate List<Product> FilterProducts(List<Product> products);

    private static List<Product> ApplyFilter(
        List<Product> products,
        FilterProducts filter)
    {
        return filter(products);
    }

// Filtros
    private static readonly FilterProducts Expensive =
        list => list.Where(p => p.Price > 300).ToList();

    private static readonly FilterProducts EmptyStock =
        list => list.Where(p => p.Stock == 0).ToList();

    private static readonly FilterProducts Consoles =
        list => list.Where(p => p.Category == ProductCategory.Consoles).ToList();

    public void ExecuteFilters()
    {
        Console.WriteLine("Itens caros: \n");
        var expensiveProducts =
            ApplyFilter(_products.Products, Expensive);

        foreach (var product in expensiveProducts)
        {
            Console.WriteLine(
                $"- {product.Name} - R$ {product.Price:F2}"
            );
        }
        Console.WriteLine();

        var emptyStockProducts =
            ApplyFilter(_products.Products, EmptyStock);

        Console.WriteLine("Itens sem estoque: \n");
        foreach (var product in emptyStockProducts)
        {
            Console.WriteLine(
                $"- {product.Name }");
        }

        var consoleProducts =
            ApplyFilter(_products.Products, Consoles);

        Console.WriteLine("Consoles \n");
        foreach (var product in consoleProducts)
        {
            Console.WriteLine(
                $"- {product.Name}");
        }
    }
}